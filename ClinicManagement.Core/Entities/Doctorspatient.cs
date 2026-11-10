using System.ComponentModel.DataAnnotations;

namespace C_sharp_Project.YoussifMohamed.Model.Entity
{
    public class Doctorspatient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Medicine is required")]
        [StringLength(25,MinimumLength = 3, ErrorMessage = "you must enter Medicine between 3 to 25 letter")]
        public string Medicine { get; set; } = string.Empty;
        [Required(ErrorMessage = "Medicine is Diagnosis")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "you must enter Diagnosis between 3 to 25 letter")]
        public string Diagnosis { get; set; } = string.Empty;
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
    }
}
