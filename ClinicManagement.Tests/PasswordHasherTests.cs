using ClinicManagement.Core.Security;

namespace ClinicManagement.Tests
{
    public class PasswordHasherTests
    {
        private readonly PasswordHasher _hasher = TestDatabase.FastHasher;

        [Fact]
        public void Hash_then_verify_round_trips()
        {
            string stored = _hasher.Hash("s3cret-Pass");

            Assert.True(PasswordHasher.IsHashed(stored));
            Assert.DoesNotContain("s3cret-Pass", stored);
            Assert.Equal(PasswordVerificationResult.Success, _hasher.Verify("s3cret-Pass", stored));
            Assert.Equal(PasswordVerificationResult.Failed, _hasher.Verify("wrong", stored));
        }

        [Fact]
        public void Default_hasher_uses_documented_format_and_iterations()
        {
            string stored = new PasswordHasher().Hash("abc12345");

            string[] parts = stored.Split('$');
            Assert.Equal(4, parts.Length);
            Assert.Equal(PasswordHasher.FormatPrefix, parts[0]);
            Assert.Equal("600000", parts[1]);
            Assert.Equal(16, Convert.FromBase64String(parts[2]).Length);
            Assert.Equal(32, Convert.FromBase64String(parts[3]).Length);
            Assert.True(stored.Length <= 256, "hash must fit the widened password column");
        }

        [Fact]
        public void Same_password_gets_a_different_salt_each_time()
        {
            Assert.NotEqual(_hasher.Hash("same-password1"), _hasher.Hash("same-password1"));
        }

        [Fact]
        public void Verify_is_case_sensitive_for_hashes_and_legacy_plain_text()
        {
            string stored = _hasher.Hash("Secret123");

            Assert.Equal(PasswordVerificationResult.Failed, _hasher.Verify("secret123", stored));
            Assert.Equal(PasswordVerificationResult.Failed, _hasher.Verify("SECRET123", stored));
            // SQL Server's default collation would have matched these; the C# check must not.
            Assert.Equal(PasswordVerificationResult.Failed, _hasher.Verify("secret123", "Secret123"));
        }

        [Fact]
        public void Legacy_plain_text_match_requests_rehash()
        {
            Assert.Equal(PasswordVerificationResult.SuccessRehashNeeded, _hasher.Verify("doc12", "doc12"));
            Assert.Equal(PasswordVerificationResult.Failed, _hasher.Verify("doc1", "doc12"));
        }

        [Fact]
        public void Hash_with_fewer_iterations_than_current_setting_requests_rehash()
        {
            string old = new PasswordHasher(1_000).Hash("upgrade-me1");

            Assert.Equal(PasswordVerificationResult.SuccessRehashNeeded, new PasswordHasher(2_000).Verify("upgrade-me1", old));
        }

        [Theory]
        [InlineData("")]
        [InlineData("PBKDF2-SHA256$")]
        [InlineData("PBKDF2-SHA256$abc$c2FsdA==$aGFzaA==")]
        [InlineData("PBKDF2-SHA256$10$c2FsdA==$aGFzaA==")]
        [InlineData("PBKDF2-SHA256$5000$not-base64$aGFzaA==")]
        public void Malformed_hashes_never_verify(string stored)
        {
            Assert.Equal(PasswordVerificationResult.Failed, _hasher.Verify(stored, stored));
        }

        [Fact]
        public void Admin_policy_requires_length_letters_digits_and_matching_confirmation()
        {
            Assert.NotNull(PasswordPolicy.ValidateAdminPassword("short1", "short1"));
            Assert.NotNull(PasswordPolicy.ValidateAdminPassword("onlyletterslong", "onlyletterslong"));
            Assert.NotNull(PasswordPolicy.ValidateAdminPassword("1234567890", "1234567890"));
            Assert.NotNull(PasswordPolicy.ValidateAdminPassword("GoodPass123", "GoodPass124"));
            Assert.Null(PasswordPolicy.ValidateAdminPassword("GoodPass123", "GoodPass123"));
        }
    }
}
