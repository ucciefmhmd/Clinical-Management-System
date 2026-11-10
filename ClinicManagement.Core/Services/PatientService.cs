using C_sharp_Project.YoussifMohamed.Model.Database;
using C_sharp_Project.YoussifMohamed.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Services
{
    public sealed record PatientInput(string Name, string Address, string Phone, string Gender, DateTime DOB);

    public sealed record PatientRow(int Id, string Name, string? Address, DateTime DOB, string? Phone, string Gender);

    public sealed class PatientService
    {
        private readonly Func<ClinicDB> _createDb;

        public PatientService(Func<ClinicDB> createDb) => _createDb = createDb;

        public List<PatientRow> Search(string? name = null)
        {
            using var db = _createDb();
            var query = db.Patient.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Name.Contains(name));
            return query
                .OrderBy(p => p.Id)
                .Select(p => new PatientRow(p.Id, p.Name, p.Address, p.DOB, p.Phone, p.Gender))
                .ToList();
        }

        public Patient? Get(int id)
        {
            using var db = _createDb();
            return db.Patient.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        /// <summary>Always inserts a new row (a fresh entity per call).</summary>
        public int Add(PatientInput input)
        {
            var patient = new Patient();
            Apply(patient, input);
            using var db = _createDb();
            db.Patient.Add(patient);
            db.SaveChanges();
            return patient.Id;
        }

        public void Update(int id, PatientInput input)
        {
            EntityRules.RequireSelection(id, "patient");
            using var db = _createDb();
            var patient = db.Patient.Find(id) ?? throw EntityRules.NotFound("patient");
            Apply(patient, input);
            db.SaveChanges();
        }

        /// <summary>Deletes the patient; their reservations and visit records are removed by the cascade in the schema.</summary>
        public void Delete(int id)
        {
            EntityRules.RequireSelection(id, "patient");
            using var db = _createDb();
            var patient = db.Patient.Find(id) ?? throw EntityRules.NotFound("patient");
            db.Patient.Remove(patient);
            db.SaveChanges();
        }

        private static void Apply(Patient patient, PatientInput input)
        {
            patient.Name = input.Name.Trim();
            patient.Address = input.Address.Trim();
            patient.Phone = input.Phone.Trim();
            patient.Gender = input.Gender.Trim();
            patient.DOB = input.DOB;
            EntityRules.Validate(patient);
        }
    }
}
