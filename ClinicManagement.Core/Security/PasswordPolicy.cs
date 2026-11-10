namespace ClinicManagement.Core.Security
{
    public static class PasswordPolicy
    {
        /// <summary>Same minimum the original schema declared for doctor / receptionist passwords.</summary>
        public const int StaffMinimumLength = 5;
        public const int AdminMinimumLength = 10;
        public const int MaximumLength = 128;

        /// <returns>An error message, or null when the password is acceptable.</returns>
        public static string? ValidateStaffPassword(string? password)
        {
            if (string.IsNullOrEmpty(password))
                return "Please enter a password.";
            if (password.Length < StaffMinimumLength)
                return $"The password must be at least {StaffMinimumLength} characters.";
            if (password.Length > MaximumLength)
                return $"The password must be at most {MaximumLength} characters.";
            return null;
        }

        /// <returns>An error message, or null when the admin password is acceptable.</returns>
        public static string? ValidateAdminPassword(string? password, string? confirmation)
        {
            if (string.IsNullOrEmpty(password))
                return "Please enter a password.";
            if (password.Length < AdminMinimumLength)
                return $"The admin password must be at least {AdminMinimumLength} characters.";
            if (password.Length > MaximumLength)
                return $"The password must be at most {MaximumLength} characters.";
            if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit))
                return "The admin password must contain at least one letter and one digit.";
            if (!string.Equals(password, confirmation, StringComparison.Ordinal))
                return "The password and its confirmation do not match.";
            return null;
        }
    }
}
