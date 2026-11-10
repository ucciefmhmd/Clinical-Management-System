namespace C_sharp_Project.EmanMetwallyElgharabawy
{
    /// <summary>Admin home: counters plus links to the patient, doctor and receptionist pages.</summary>
    public partial class Home_Page : Form
    {
        public Home_Page()
        {
            InitializeComponent();
        }

        private void Home_Page_Load(object sender, EventArgs e)
        {
            Ui.Run(() =>
            {
                var counts = AppServices.Dashboard.GetHomeCounts();
                numPatient.Text = counts.Patients.ToString();
                numDoc.Text = counts.Doctors.ToString();
                numRecep.Text = counts.Receptionists.ToString();
                numReserv.Text = counts.Reservations.ToString();
            });
        }

        private void OpenPatients() => Ui.Navigate(this, new PatientPage());
        private void OpenDoctors() => Ui.Navigate(this, new DoctorPage());
        private void OpenReceptionists() => Ui.Navigate(this, new Receptionist());
        private void Logout() => Ui.Navigate(this, new LoginPage());

        private void label2_Click(object sender, EventArgs e) => OpenPatients();
        private void pictureBox2_Click(object sender, EventArgs e) => OpenPatients();
        private void label4_Click(object sender, EventArgs e) => OpenDoctors();
        private void pictureBox5_Click(object sender, EventArgs e) => OpenDoctors();
        private void label1_Click(object sender, EventArgs e) => OpenReceptionists();
        private void pictureBox3_Click(object sender, EventArgs e) => OpenReceptionists();
        private void label6_Click(object sender, EventArgs e) => Logout();
        private void pictureBox6_Click(object sender, EventArgs e) => Logout();

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
