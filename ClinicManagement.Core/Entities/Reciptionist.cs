using System.ComponentModel.DataAnnotations;

namespace C_sharp_Project.YoussifMohamed.Model.Entity
{
    public class Reciptionist
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        [MinLength(5) , MaxLength(15)]
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
