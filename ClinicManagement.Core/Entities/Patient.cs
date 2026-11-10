using System.ComponentModel.DataAnnotations;

namespace C_sharp_Project.YoussifMohamed.Model.Entity
{
    public class Patient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(15,MinimumLength =3, ErrorMessage = "you must enter name between 3 to 15 letter")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DOB { get; set; }
        public string Gender { get; set; } = string.Empty;
    }
}
