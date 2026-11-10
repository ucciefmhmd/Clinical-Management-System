using C_sharp_Project.YoussifMohamed.Model.Database;
using C_sharp_Project.YoussifMohamed.Model.Entity;
using ClinicManagement.Core.Security;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Services
{
    /// <param name="Password">Plain text from the form. Required when adding; on update, empty keeps the current password.</param>
    public sealed record DoctorInput(
        string Name, string Gender, string Specialization, string Experience,
        string Address, string Phone, DateTime DOB, string? Password);

    /// <summary>Grid row without the password column.</summary>
    public sealed record DoctorRow(
        int Id, string Name, string Address, string Specialization, string Phone,
        string Experience, string Gender, DateTime DOB);

    public sealed class DoctorService
    {
        private readonly Func<ClinicDB> _createDb;
        private readonly PasswordHasher _hasher;

        public DoctorService(Func<ClinicDB> createDb, PasswordHasher? hasher = null)
        {
            _createDb = createDb;
            _hasher = hasher ?? new PasswordHasher();
        }

        /// <param name="exactName">Original behaviour: search matches the full name.</param>
        public List<DoctorRow> Search(string? exactName = null)
        {
            using var db = _createDb();
            var query = db.Doctor.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(exactName))
            {
                string name = exactName.Trim();
                query = query.Where(d => d.Name == name);
            }
            return query
                .OrderBy(d => d.Id)
                .Select(d => new DoctorRow(d.Id, d.Name, d.Address, d.Specialization, d.Phone, d.Experience, d.Gender, d.DOB))
                .ToList();
        }

        public DoctorRow? Get(int id)
        {
            using var db = _createDb();
            return db.Doctor.AsNoTracking()
                .Where(d => d.Id == id)
                .Select(d => new DoctorRow(d.Id, d.Name, d.Address, d.Specialization, d.Phone, d.Experience, d.Gender, d.DOB))
                .FirstOrDefault();
        }

        public int Add(DoctorInput input)
        {
            string? error = PasswordPolicy.ValidateStaffPassword(input.Password);
            if (error != null)
                throw new ClinicValidationException(error);
            var doctor = new Doctor();
            Apply(doctor, input);
            doctor.password = _hasher.Hash(input.Password!);
            EntityRules.Validate(doctor);

            using var db = _createDb();
            db.Doctor.Add(doctor);
            db.SaveChanges();
            return doctor.Id;
        }

        public void Update(int id, DoctorInput input)
        {
            EntityRules.RequireSelection(id, "doctor");
            using var db = _createDb();
            var doctor = db.Doctor.Find(id) ?? throw EntityRules.NotFound("doctor");
            Apply(doctor, input);
            if (!string.IsNullOrEmpty(input.Password))
            {
                string? error = PasswordPolicy.ValidateStaffPassword(input.Password);
                if (error != null)
                    throw new ClinicValidationException(error);
                doctor.password = _hasher.Hash(input.Password);
            }
            EntityRules.Validate(doctor);
            db.SaveChanges();
        }

        /// <summary>Deletes the doctor; their reservations and visit records are removed by the cascade in the schema.</summary>
        public void Delete(int id)
        {
            EntityRules.RequireSelection(id, "doctor");
            using var db = _createDb();
            var doctor = db.Doctor.Find(id) ?? throw EntityRules.NotFound("doctor");
            db.Doctor.Remove(doctor);
            db.SaveChanges();
        }

        private static void Apply(Doctor doctor, DoctorInput input)
        {
            doctor.Name = input.Name.Trim();
            doctor.Gender = input.Gender.Trim();
            doctor.Specialization = input.Specialization.Trim();
            doctor.Experience = input.Experience.Trim();
            doctor.Address = input.Address.Trim();
            doctor.Phone = input.Phone.Trim();
            doctor.DOB = input.DOB;
        }
    }

    /// <param name="Password">Plain text from the form. Required when adding; on update, empty keeps the current password.</param>
    public sealed record ReceptionistInput(string Name, string Gender, string Address, string Phone, string? Password);

    /// <summary>Grid row without the password column.</summary>
    public sealed record ReceptionistRow(int Id, string Name, string Gender, string Address, string Phone);

    public sealed class ReceptionistService
    {
        private readonly Func<ClinicDB> _createDb;
        private readonly PasswordHasher _hasher;

        public ReceptionistService(Func<ClinicDB> createDb, PasswordHasher? hasher = null)
        {
            _createDb = createDb;
            _hasher = hasher ?? new PasswordHasher();
        }

        /// <param name="exactName">Original behaviour: search matches the full name.</param>
        public List<ReceptionistRow> Search(string? exactName = null)
        {
            using var db = _createDb();
            var query = db.Reciptionist.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(exactName))
            {
                string name = exactName.Trim();
                query = query.Where(r => r.Name == name);
            }
            return query
                .OrderBy(r => r.Id)
                .Select(r => new ReceptionistRow(r.Id, r.Name, r.Gender, r.Address, r.Phone))
                .ToList();
        }

        public ReceptionistRow? Get(int id)
        {
            using var db = _createDb();
            return db.Reciptionist.AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new ReceptionistRow(r.Id, r.Name, r.Gender, r.Address, r.Phone))
                .FirstOrDefault();
        }

        public int Add(ReceptionistInput input)
        {
            string? error = PasswordPolicy.ValidateStaffPassword(input.Password);
            if (error != null)
                throw new ClinicValidationException(error);
            var recep = new Reciptionist();
            Apply(recep, input);
            recep.Password = _hasher.Hash(input.Password!);
            EntityRules.Validate(recep);

            using var db = _createDb();
            db.Reciptionist.Add(recep);
            db.SaveChanges();
            return recep.Id;
        }

        public void Update(int id, ReceptionistInput input)
        {
            EntityRules.RequireSelection(id, "receptionist");
            using var db = _createDb();
            var recep = db.Reciptionist.Find(id) ?? throw EntityRules.NotFound("receptionist");
            Apply(recep, input);
            if (!string.IsNullOrEmpty(input.Password))
            {
                string? error = PasswordPolicy.ValidateStaffPassword(input.Password);
                if (error != null)
                    throw new ClinicValidationException(error);
                recep.Password = _hasher.Hash(input.Password);
            }
            EntityRules.Validate(recep);
            db.SaveChanges();
        }

        /// <summary>Deletes the receptionist; reservations they booked are removed by the cascade in the schema.</summary>
        public void Delete(int id)
        {
            EntityRules.RequireSelection(id, "receptionist");
            using var db = _createDb();
            var recep = db.Reciptionist.Find(id) ?? throw EntityRules.NotFound("receptionist");
            db.Reciptionist.Remove(recep);
            db.SaveChanges();
        }

        private static void Apply(Reciptionist recep, ReceptionistInput input)
        {
            recep.Name = input.Name.Trim();
            recep.Gender = input.Gender.Trim();
            recep.Address = input.Address.Trim();
            recep.Phone = input.Phone.Trim();
        }
    }
}
