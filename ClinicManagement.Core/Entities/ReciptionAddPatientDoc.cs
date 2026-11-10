namespace C_sharp_Project.YoussifMohamed.Model.Entity
{
    /// <summary>A reservation (appointment) booked by a receptionist for a patient with a doctor.</summary>
    public class ReciptionAddPatientDoc
    {
        public int Id { get; set; }
        /// <summary>true = Done (visit recorded), false = waiting / missed.</summary>
        public bool State { get; set; }
        public int Price { get; set; }
        public DateTime Appointment { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int ReciptionistID { get; set; }
        public Patient Patient { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!;
        public Reciptionist Reciptionist { get; set; } = null!;
    }
}
