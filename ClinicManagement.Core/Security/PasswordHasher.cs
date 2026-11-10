using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace ClinicManagement.Core.Security
{
    public enum PasswordVerificationResult
    {
        Failed,
        Success,
        /// <summary>The password is correct but the stored value should be replaced with a fresh hash
        /// (legacy plain-text value, or a hash made with fewer iterations than the current setting).</summary>
        SuccessRehashNeeded,
    }

    /// <summary>
    /// PBKDF2 (HMAC-SHA256) password hashing using only the .NET base library.
    /// Stored format: <c>PBKDF2-SHA256$iterations$base64(salt)$base64(hash)</c>.
    /// Values without that prefix are treated as legacy plain-text passwords from the original schema.
    /// </summary>
    public sealed class PasswordHasher
    {
        public const string FormatPrefix = "PBKDF2-SHA256";
        /// <summary>OWASP's current recommendation for PBKDF2-HMAC-SHA256.</summary>
        public const int DefaultIterations = 600_000;
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int MinimumAcceptedIterations = 1_000;

        public PasswordHasher(int iterations = DefaultIterations)
        {
            if (iterations < MinimumAcceptedIterations)
                throw new ArgumentOutOfRangeException(nameof(iterations));
            Iterations = iterations;
        }

        public int Iterations { get; }

        public string Hash(string password)
        {
            ArgumentNullException.ThrowIfNull(password);
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);
            return string.Join('$',
                FormatPrefix,
                Iterations.ToString(CultureInfo.InvariantCulture),
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash));
        }

        public static bool IsHashed(string? stored) =>
            stored != null && stored.StartsWith(FormatPrefix + "$", StringComparison.Ordinal);

        /// <summary>Case-sensitive, constant-time verification.</summary>
        public PasswordVerificationResult Verify(string password, string? stored)
        {
            ArgumentNullException.ThrowIfNull(password);
            if (string.IsNullOrEmpty(stored))
                return PasswordVerificationResult.Failed;

            if (!IsHashed(stored))
            {
                // Legacy plain-text value written by the original application.
                bool equal = CryptographicOperations.FixedTimeEquals(
                    Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(stored));
                return equal ? PasswordVerificationResult.SuccessRehashNeeded : PasswordVerificationResult.Failed;
            }

            string[] parts = stored.Split('$');
            if (parts.Length != 4
                || !int.TryParse(parts[1], NumberStyles.None, CultureInfo.InvariantCulture, out int iterations)
                || iterations < MinimumAcceptedIterations)
                return PasswordVerificationResult.Failed;

            byte[] salt, expected;
            try
            {
                salt = Convert.FromBase64String(parts[2]);
                expected = Convert.FromBase64String(parts[3]);
            }
            catch (FormatException)
            {
                return PasswordVerificationResult.Failed;
            }
            if (salt.Length == 0 || expected.Length == 0)
                return PasswordVerificationResult.Failed;

            byte[] actual = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, expected.Length);
            if (!CryptographicOperations.FixedTimeEquals(actual, expected))
                return PasswordVerificationResult.Failed;

            return iterations < Iterations
                ? PasswordVerificationResult.SuccessRehashNeeded
                : PasswordVerificationResult.Success;
        }
    }
}
