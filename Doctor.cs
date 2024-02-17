using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Project.YoussifMohamed.Model.Entity
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Specialization { get; set; }
        public string Experience { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        [MinLength(5) , MaxLength(15)]
        [Required]
        public string password { get; set; }
    }
}
