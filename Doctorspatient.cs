using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Project.YoussifMohamed.Model.Entity
{
    public class Doctorspatient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Medicine is required")]
        [StringLength(25,MinimumLength = 3, ErrorMessage = "you must enter Medicine between 3 to 25 letter")]
        public string Medicine { get; set; }
        [Required(ErrorMessage = "Medicine is Diagnosis")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "you must enter Diagnosis between 3 to 25 letter")]
        public string Diagnosis { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
