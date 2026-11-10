using C_sharp_Project.YoussifMohamed.Model.Database;
using C_sharp_Project.YoussifMohamed.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Services
{
    /// <summary>Today's appointment counts. "Waiting" counts every reservation not marked Done (as the original screens did).</summary>
    public sealed record DashboardStats(int Total, int Waiting, int Done)
    {
        /// <summary>Whole-number percentage of today's appointments that are done; 0 when there are none.</summary>
        public int PercentDone => Total == 0 ? 0 : (int)(Done * 100L / Total);
    }

    public sealed record HomeCounts(int Patients, int Doctors, int Receptionists, int Reservations);

    public sealed record TodayAppointmentRow(string Patient, string Doctor, string Time, string Price, string State);

    public sealed class DashboardService
    {
        private readonly Func<ClinicDB> _createDb;
        private readonly IClock _clock;

        public DashboardService(Func<ClinicDB> createDb, IClock clock)
        {
            _createDb = createDb;
            _clock = clock;
        }

        /// <summary>Admin home page counters, computed with COUNT queries.</summary>
        public HomeCounts GetHomeCounts()
        {
            using var db = _createDb();
            return new HomeCounts(
                db.Patient.Count(),
                db.Doctor.Count(),
                db.Reciptionist.Count(),
                db.ReciptionAddPatientDoc.Count());
        }

        /// <param name="doctorId">Limit to one doctor (doctor dashboard), or null for everyone (receptionist dashboard).</param>
        public DashboardStats GetTodayStats(int? doctorId = null)
        {
            using var db = _createDb();
            var today = Today(db, doctorId);
            int total = today.Count();
            int done = today.Count(r => r.State);
            return new DashboardStats(total, total - done, done);
        }

        public List<TodayAppointmentRow> GetTodayAppointments(
            int? doctorId = null, ReservationSearchField? field = null, string? text = null)
        {
            using var db = _createDb();
            var query = Today(db, doctorId);
            if (!string.IsNullOrEmpty(text))
            {
                query = field switch
                {
                    ReservationSearchField.Doctor => query.Where(r => r.Doctor.Name.StartsWith(text)),
                    ReservationSearchField.Patient => query.Where(r => r.Patient.Name.StartsWith(text)),
                    _ => query.Where(r => r.Doctor.Name.StartsWith(text) || r.Patient.Name.StartsWith(text)),
                };
            }

            DateTime now = _clock.Now;
            return query
                .OrderBy(r => r.Appointment)
                .Select(r => new { Patient = r.Patient.Name, Doctor = r.Doctor.Name, r.Appointment, r.Price, r.State })
                .ToList()
                .Select(r => new TodayAppointmentRow(
                    r.Patient, r.Doctor, r.Appointment.ToString("t"), r.Price + " $",
                    ReservationStatus.Describe(r.State, r.Appointment, now)))
                .ToList();
        }

        private IQueryable<ReciptionAddPatientDoc> Today(ClinicDB db, int? doctorId)
        {
            DateTime start = _clock.Now.Date, end = start.AddDays(1);
            var query = db.ReciptionAddPatientDoc.AsNoTracking()
                .Where(r => r.Appointment >= start && r.Appointment < end);
            if (doctorId is int id)
                query = query.Where(r => r.DoctorID == id);
            return query;
        }
    }
}
