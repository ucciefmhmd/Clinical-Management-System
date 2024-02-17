using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Project.YoussifMohamed.Model.Entity
{
    public class Reciptionist
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [MinLength(5) , MaxLength(15)]
        [Required]
        public string Password { get; set; }
    }
}
