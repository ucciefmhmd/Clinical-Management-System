using C_sharp_Project.YoussifMohamed.Model.Database;
using C_sharp_Project.YoussifMohamed.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Services
{
    public enum ReservationSearchField
    {
        Doctor,
        Patient,
    }

    /// <param name="PatientId">null when nothing is selected in the combo box.</param>
    /// <param name="DoctorId">null when nothing is selected in the combo box.</param>
    /// <param name="Price">Raw text from the price box.</param>
    /// <param name="Done">Only used when editing; new reservations always start as waiting.</param>
    public sealed record ReservationInput(int? PatientId, int? DoctorId, DateTime Appointment, string Price, bool Done = false);

    public sealed record ReservationRow(int ID, string Patient, string Doctor, string Date, string Time, string Price, string State);

    public static class ReservationStatus
    {
        public const string Done = "Done";
        public const string Waiting = "Waiting";
        public const string Missed = "Missed";

        public static string Describe(bool done, DateTime appointment, DateTime now) =>
            done ? Done : appointment > now ? Waiting : Missed;
    }

    public sealed class ReservationService
    {
        private readonly Func<ClinicDB> _createDb;
        private readonly IClock _clock;

        public ReservationService(Func<ClinicDB> createDb, IClock clock)
        {
            _createDb = createDb;
            _clock = clock;
        }

        public List<LookupItem> GetPatientOptions()
        {
            using var db = _createDb();
            return db.Patient.AsNoTracking().OrderBy(p => p.Name).Select(p => new LookupItem(p.Id, p.Name)).ToList();
        }

        public List<LookupItem> GetDoctorOptions()
        {
            using var db = _createDb();
            return db.Doctor.AsNoTracking().OrderBy(d => d.Name).Select(d => new LookupItem(d.Id, d.Name)).ToList();
        }

        /// <summary>All reservations, optionally filtered by the start of the doctor's or patient's name
        /// (no field selected = either name matches).</summary>
        public List<ReservationRow> Search(ReservationSearchField? field = null, string? text = null)
        {
            using var db = _createDb();
            var query = db.ReciptionAddPatientDoc.AsNoTracking();
            if (!string.IsNullOrEmpty(text))
            {
                query = field switch
                {
                    ReservationSearchField.Doctor => query.Where(r => r.Doctor.Name.StartsWith(text)),
                    ReservationSearchField.Patient => query.Where(r => r.Patient.Name.StartsWith(text)),
                    _ => query.Where(r => r.Doctor.Name.StartsWith(text) || r.Patient.Name.StartsWith(text)),
                };
            }
            return ToRows(query);
        }

        public List<ReservationRow> OnDate(DateTime date)
        {
            DateTime start = date.Date, end = start.AddDays(1);
            using var db = _createDb();
            return ToRows(db.ReciptionAddPatientDoc.AsNoTracking().Where(r => r.Appointment >= start && r.Appointment < end));
        }

        public ReciptionAddPatientDoc? Get(int id)
        {
            using var db = _createDb();
            return db.ReciptionAddPatientDoc.AsNoTracking().FirstOrDefault(r => r.Id == id);
        }

        public int Add(int receptionistId, ReservationInput input)
        {
            using var db = _createDb();
            var reservation = new ReciptionAddPatientDoc { State = false };
            Apply(db, reservation, receptionistId, input);
            reservation.State = false;
            db.ReciptionAddPatientDoc.Add(reservation);
            db.SaveChanges();
            return reservation.Id;
        }

        public void Update(int id, int receptionistId, ReservationInput input)
        {
            EntityRules.RequireSelection(id, "reservation");
            using var db = _createDb();
            var reservation = db.ReciptionAddPatientDoc.Find(id) ?? throw EntityRules.NotFound("reservation");
            Apply(db, reservation, receptionistId, input);
            reservation.State = input.Done;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            EntityRules.RequireSelection(id, "reservation");
            using var db = _createDb();
            var reservation = db.ReciptionAddPatientDoc.Find(id) ?? throw EntityRules.NotFound("reservation");
            db.ReciptionAddPatientDoc.Remove(reservation);
            db.SaveChanges();
        }

        private static void Apply(ClinicDB db, ReciptionAddPatientDoc reservation, int receptionistId, ReservationInput input)
        {
            if (input.PatientId is not int patientId || patientId <= 0)
                throw new ClinicValidationException("Please select a patient.");
            if (input.DoctorId is not int doctorId || doctorId <= 0)
                throw new ClinicValidationException("Please select a doctor.");
            if (!int.TryParse(input.Price?.Trim(), out int price) || price < 0)
                throw new ClinicValidationException("Please enter a valid price (a whole number, 0 or more).");
            if (!db.Patient.Any(p => p.Id == patientId))
                throw EntityRules.NotFound("patient");
            if (!db.Doctor.Any(d => d.Id == doctorId))
                throw EntityRules.NotFound("doctor");
            if (!db.Reciptionist.Any(r => r.Id == receptionistId))
                throw new ClinicValidationException("Your receptionist account no longer exists. Please log in again.");

            reservation.PatientID = patientId;
            reservation.DoctorID = doctorId;
            reservation.ReciptionistID = receptionistId;
            reservation.Appointment = input.Appointment;
            reservation.Price = price;
        }

        private List<ReservationRow> ToRows(IQueryable<ReciptionAddPatientDoc> query)
        {
            DateTime now = _clock.Now;
            return query
                .OrderBy(r => r.Appointment)
                .Select(r => new { r.Id, Patient = r.Patient.Name, Doctor = r.Doctor.Name, r.Appointment, r.Price, r.State })
                .ToList()
                .Select(r => new ReservationRow(
                    r.Id, r.Patient, r.Doctor,
                    r.Appointment.ToString("d"), r.Appointment.ToString("t"),
                    r.Price + " $",
                    ReservationStatus.Describe(r.State, r.Appointment, now)))
                .ToList();
        }
    }
}
