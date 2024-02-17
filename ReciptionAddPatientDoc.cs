using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Project.YoussifMohamed.Model.Entity
{
    public class ReciptionAddPatientDoc
    {
        public int Id { get; set; }
        public bool State { get; set; }
        public int Price { get; set; }
        public DateTime Appointment { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int ReciptionistID { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Reciptionist Reciptionist { get; set; }
    }
}
