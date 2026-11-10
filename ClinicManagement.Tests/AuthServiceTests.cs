using C_sharp_Project.YoussifMohamed.Model.Entity;
using ClinicManagement.Core;
using ClinicManagement.Core.Security;
using ClinicManagement.Core.Services;

namespace ClinicManagement.Tests
{
    public class AuthServiceTests : IDisposable
    {
        private readonly TestDatabase _db = new();
        private readonly AuthService _auth;

        public AuthServiceTests() => _auth = new AuthService(_db.Create, TestDatabase.FastHasher);

        public void Dispose() => _db.Dispose();

        private int SeedDoctor(string name, string storedPassword)
        {
            using var db = _db.Create();
            var d = new Doctor { Name = name, password = storedPassword, DOB = new DateTime(1980, 1, 1) };
            db.Doctor.Add(d);
            db.SaveChanges();
            return d.Id;
        }

        private int SeedReceptionist(string name, string storedPassword)
        {
            using var db = _db.Create();
            var r = new Reciptionist { Name = name, Password = storedPassword };
            db.Reciptionist.Add(r);
            db.SaveChanges();
            return r.Id;
        }

        [Fact]
        public void First_run_has_no_admin_and_setup_creates_a_hashed_one()
        {
            Assert.False(_auth.AdminExists());

            _auth.CreateInitialAdmin(" Admin ", "ClinicAdmin2026", "ClinicAdmin2026");

            Assert.True(_auth.AdminExists());
            using var db = _db.Create();
            var admin = Assert.Single(db.Admin.ToList());
            Assert.Equal("Admin", admin.Username);
            Assert.True(PasswordHasher.IsHashed(admin.PasswordHash));
            Assert.DoesNotContain("ClinicAdmin2026", admin.PasswordHash);
        }

        [Fact]
        public void First_run_setup_rejects_weak_or_mismatched_passwords_and_runs_only_once()
        {
            Assert.Throws<ClinicValidationException>(() => _auth.CreateInitialAdmin("Admin", "Admin123", "Admin123"));
            Assert.Throws<ClinicValidationException>(() => _auth.CreateInitialAdmin("Admin", "ClinicAdmin2026", "ClinicAdmin2025"));
            Assert.Throws<ClinicValidationException>(() => _auth.CreateInitialAdmin("  ", "ClinicAdmin2026", "ClinicAdmin2026"));
            Assert.False(_auth.AdminExists());

            _auth.CreateInitialAdmin("Admin", "ClinicAdmin2026", "ClinicAdmin2026");
            Assert.Throws<InvalidOperationException>(() => _auth.CreateInitialAdmin("Other", "OtherAdmin2026", "OtherAdmin2026"));
        }

        [Fact]
        public void Admin_login_succeeds_only_with_the_configured_password()
        {
            _auth.CreateInitialAdmin("Admin", "ClinicAdmin2026", "ClinicAdmin2026");

            Assert.True(_auth.Login(UserRole.Admin, "Admin", "ClinicAdmin2026").Succeeded);
            Assert.False(_auth.Login(UserRole.Admin, "Admin", "clinicadmin2026").Succeeded);
            // The old hard-coded demo passwords no longer work.
            Assert.False(_auth.Login(UserRole.Admin, "Admin", "Admin123").Succeeded);
            Assert.False(_auth.Login(UserRole.Admin, "Admin", "Home123").Succeeded);
            Assert.False(_auth.Login(UserRole.Admin, "Admin", "Doctor123").Succeeded);
        }

        [Fact]
        public void Login_requires_user_name_and_password()
        {
            var result = _auth.Login(UserRole.Doctor, "", "x");

            Assert.False(result.Succeeded);
            Assert.Contains("Doctor", result.Error);
        }

        [Fact]
        public void Doctor_with_legacy_plain_text_password_logs_in_and_is_upgraded_to_a_hash()
        {
            int id = SeedDoctor("Sara", "doc12");

            var result = _auth.Login(UserRole.Doctor, "Sara", "doc12");

            Assert.True(result.Succeeded);
            Assert.Equal(id, result.UserId);
            using (var db = _db.Create())
            {
                string stored = db.Doctor.Single().password;
                Assert.True(PasswordHasher.IsHashed(stored));
            }
            // Still works after the upgrade, and stays case-sensitive.
            Assert.True(_auth.Login(UserRole.Doctor, "Sara", "doc12").Succeeded);
            Assert.False(_auth.Login(UserRole.Doctor, "Sara", "DOC12").Succeeded);
        }

        [Fact]
        public void Wrong_case_of_legacy_password_is_rejected_and_not_upgraded()
        {
            SeedReceptionist("Mona", "Desk123");

            Assert.False(_auth.Login(UserRole.Receptionist, "Mona", "desk123").Succeeded);

            using var db = _db.Create();
            Assert.Equal("Desk123", db.Reciptionist.Single().Password);
        }

        [Fact]
        public void Roles_are_separate_a_doctor_cannot_log_in_as_receptionist_or_admin()
        {
            SeedDoctor("Ali", TestDatabase.FastHasher.Hash("pass1"));

            Assert.True(_auth.Login(UserRole.Doctor, "Ali", "pass1").Succeeded);
            Assert.False(_auth.Login(UserRole.Receptionist, "Ali", "pass1").Succeeded);
            Assert.False(_auth.Login(UserRole.Admin, "Ali", "pass1").Succeeded);
        }

        [Fact]
        public void Receptionist_login_returns_their_id()
        {
            SeedReceptionist("Other", TestDatabase.FastHasher.Hash("aaaaa"));
            int id = SeedReceptionist("Mona", TestDatabase.FastHasher.Hash("desk1"));

            var result = _auth.Login(UserRole.Receptionist, "Mona", "desk1");

            Assert.True(result.Succeeded);
            Assert.Equal(UserRole.Receptionist, result.Role);
            Assert.Equal(id, result.UserId);
        }

        [Fact]
        public void Doctors_sharing_a_name_are_told_apart_by_password()
        {
            SeedDoctor("Omar", TestDatabase.FastHasher.Hash("first1"));
            int second = SeedDoctor("Omar", TestDatabase.FastHasher.Hash("second2"));

            var result = _auth.Login(UserRole.Doctor, "Omar", "second2");

            Assert.True(result.Succeeded);
            Assert.Equal(second, result.UserId);
        }
    }
}
