using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace C_sharp_Project.YoussifMohamed.Model.Entity
{
    public class Patient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(15,MinimumLength =3, ErrorMessage = "you must enter name between 3 to 15 letter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }

    }
}
