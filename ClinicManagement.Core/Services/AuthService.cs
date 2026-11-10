using C_sharp_Project.YoussifMohamed.Model.Database;
using C_sharp_Project.YoussifMohamed.Model.Entity;
using ClinicManagement.Core.Security;

namespace ClinicManagement.Core.Services
{
    /// <summary>Order matches the role combo box on the login screen.</summary>
    public enum UserRole
    {
        Admin = 0,
        Doctor = 1,
        Receptionist = 2,
    }

    public sealed record LoginResult(bool Succeeded, UserRole Role, int UserId, string? Error)
    {
        public static LoginResult Fail(UserRole role, string error) => new(false, role, 0, error);
        public static LoginResult Success(UserRole role, int userId) => new(true, role, userId, null);
    }

    public sealed class AuthService
    {
        public const string WrongCredentials = "Wrong UserName or Password";
        public const int MaxUsernameLength = 50;

        private readonly Func<ClinicDB> _createDb;
        private readonly PasswordHasher _hasher;

        public AuthService(Func<ClinicDB> createDb, PasswordHasher? hasher = null)
        {
            _createDb = createDb;
            _hasher = hasher ?? new PasswordHasher();
        }

        public bool AdminExists()
        {
            using var db = _createDb();
            return db.Admin.Any();
        }

        /// <summary>First-run setup: creates the single admin account. Fails if one already exists.</summary>
        public void CreateInitialAdmin(string username, string password, string confirmPassword)
        {
            username = (username ?? string.Empty).Trim();
            if (username.Length == 0)
                throw new ClinicValidationException("Please enter an admin user name.");
            if (username.Length > MaxUsernameLength)
                throw new ClinicValidationException($"The user name must be at most {MaxUsernameLength} characters.");
            string? error = PasswordPolicy.ValidateAdminPassword(password, confirmPassword);
            if (error != null)
                throw new ClinicValidationException(error);

            using var db = _createDb();
            if (db.Admin.Any())
                throw new InvalidOperationException("An admin account already exists.");
            db.Admin.Add(new Admin { Username = username, PasswordHash = _hasher.Hash(password) });
            db.SaveChanges();
        }

        public LoginResult Login(UserRole role, string? username, string? password)
        {
            username = (username ?? string.Empty).Trim();
            if (username.Length == 0 || string.IsNullOrEmpty(password))
                return LoginResult.Fail(role, $"Please Enter {role} Name And {role} Password");

            using var db = _createDb();
            switch (role)
            {
                case UserRole.Admin:
                {
                    // Name matching follows the database collation; the password check is always
                    // case-sensitive because it happens here, not in SQL.
                    foreach (var admin in db.Admin.Where(a => a.Username == username).ToList())
                    {
                        if (Check(password, admin.PasswordHash, h => admin.PasswordHash = h, db))
                            return LoginResult.Success(role, admin.Id);
                    }
                    break;
                }
                case UserRole.Doctor:
                {
                    // Names are not unique, so try every doctor with that name.
                    foreach (var doctor in db.Doctor.Where(d => d.Name == username).ToList())
                    {
                        if (Check(password, doctor.password, h => doctor.password = h, db))
                            return LoginResult.Success(role, doctor.Id);
                    }
                    break;
                }
                case UserRole.Receptionist:
                {
                    foreach (var recep in db.Reciptionist.Where(r => r.Name == username).ToList())
                    {
                        if (Check(password, recep.Password, h => recep.Password = h, db))
                            return LoginResult.Success(role, recep.Id);
                    }
                    break;
                }
                default:
                    return LoginResult.Fail(role, "Please Select Your Position");
            }
            return LoginResult.Fail(role, WrongCredentials);
        }

        /// <summary>Verifies and, for legacy plain-text or outdated hashes, transparently upgrades the stored value.</summary>
        private bool Check(string password, string stored, Action<string> setHash, ClinicDB db)
        {
            var result = _hasher.Verify(password, stored);
            if (result == PasswordVerificationResult.Failed)
                return false;
            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                setHash(_hasher.Hash(password));
                db.SaveChanges();
            }
            return true;
        }
    }
}
