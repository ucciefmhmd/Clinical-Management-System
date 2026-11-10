using System.ComponentModel.DataAnnotations;

namespace C_sharp_Project.YoussifMohamed.Model.Entity
{
    /// <summary>Administrator account. Created on first run; the password is stored as a PBKDF2 hash.</summary>
    public class Admin
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;
        [Required, MaxLength(256)]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
