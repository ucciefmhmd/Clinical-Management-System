using C_sharp_Project.YoussifMohamed.Model.Database;
using C_sharp_Project.YoussifMohamed.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Services
{
    public sealed record VisitRow(int ID, string Patient, string Medicine, string Diagnosis);

    /// <summary>The doctor's side of a visit: diagnosis + medicine, which marks today's reservation as Done.</summary>
    public sealed class VisitService
    {
        private readonly Func<ClinicDB> _createDb;
        private readonly IClock _clock;

        public VisitService(Func<ClinicDB> createDb, IClock clock)
        {
            _createDb = createDb;
            _clock = clock;
        }

        /// <summary>Patients with a reservation today for this doctor that is not yet Done.</summary>
        public List<LookupItem> GetWaitingPatientsToday(int doctorId)
        {
            using var db = _createDb();
            return Today(db, doctorId)
                .Where(r => !r.State)
                .Select(r => new { r.PatientID, r.Patient.Name })
                .Distinct()
                .ToList()
                .OrderBy(p => p.Name)
                .Select(p => new LookupItem(p.PatientID, p.Name))
                .ToList();
        }

        /// <summary>For each patient whose reservation today is Done: the latest visit record this doctor wrote for them.</summary>
        public List<VisitRow> GetTodayVisits(int doctorId, string? patientNameStartsWith = null)
        {
            using var db = _createDb();
            var donePatients = Today(db, doctorId)
                .Where(r => r.State)
                .Select(r => new { r.PatientID, r.Patient.Name })
                .Distinct()
                .ToList();
            var ids = donePatients.Select(p => p.PatientID).ToList();

            var latest = db.Doctorspatient.AsNoTracking()
                .Where(v => v.DoctorID == doctorId && ids.Contains(v.PatientID))
                .ToList()
                .GroupBy(v => v.PatientID)
                .Select(g => g.OrderByDescending(v => v.Id).First());

            var rows = latest
                .Join(donePatients, v => v.PatientID, p => p.PatientID,
                    (v, p) => new VisitRow(v.Id, p.Name, v.Medicine, v.Diagnosis));
            if (!string.IsNullOrEmpty(patientNameStartsWith))
                rows = rows.Where(r => r.Patient.StartsWith(patientNameStartsWith, StringComparison.OrdinalIgnoreCase));
            return rows.OrderBy(r => r.Patient).ToList();
        }

        public int AddVisit(int doctorId, int? patientId, string medicine, string diagnosis)
        {
            if (patientId is not int pid || pid <= 0)
                throw new ClinicValidationException("Please select a patient.");

            using var db = _createDb();
            var reservation = Tracked(db, doctorId, pid)
                .Where(r => !r.State)
                .OrderBy(r => r.Appointment)
                .FirstOrDefault()
                ?? throw new ClinicValidationException("This patient has no waiting appointment with you today.");

            var visit = new Doctorspatient
            {
                DoctorID = doctorId,
                PatientID = pid,
                Medicine = (medicine ?? string.Empty).Trim(),
                Diagnosis = (diagnosis ?? string.Empty).Trim(),
            };
            EntityRules.Validate(visit);

            reservation.State = true;
            db.Doctorspatient.Add(visit);
            db.SaveChanges();
            return visit.Id;
        }

        public void UpdateVisit(int visitId, string medicine, string diagnosis)
        {
            EntityRules.RequireSelection(visitId, "visit record");
            using var db = _createDb();
            var visit = db.Doctorspatient.Find(visitId) ?? throw EntityRules.NotFound("visit record");
            visit.Medicine = (medicine ?? string.Empty).Trim();
            visit.Diagnosis = (diagnosis ?? string.Empty).Trim();
            EntityRules.Validate(visit);
            db.SaveChanges();
        }

        /// <summary>Deletes the visit record and puts today's reservation back to waiting.</summary>
        public void DeleteVisit(int visitId)
        {
            EntityRules.RequireSelection(visitId, "visit record");
            using var db = _createDb();
            var visit = db.Doctorspatient.Find(visitId) ?? throw EntityRules.NotFound("visit record");
            var reservation = Tracked(db, visit.DoctorID, visit.PatientID)
                .Where(r => r.State)
                .OrderBy(r => r.Appointment)
                .FirstOrDefault();
            if (reservation != null)
                reservation.State = false;
            db.Doctorspatient.Remove(visit);
            db.SaveChanges();
        }

        private IQueryable<ReciptionAddPatientDoc> Today(ClinicDB db, int doctorId) =>
            Tracked(db, doctorId, patientId: null).AsNoTracking();

        private IQueryable<ReciptionAddPatientDoc> Tracked(ClinicDB db, int doctorId, int? patientId)
        {
            DateTime start = _clock.Now.Date, end = start.AddDays(1);
            var query = db.ReciptionAddPatientDoc
                .Where(r => r.DoctorID == doctorId && r.Appointment >= start && r.Appointment < end);
            if (patientId is int pid)
                query = query.Where(r => r.PatientID == pid);
            return query;
        }
    }
}
