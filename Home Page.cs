using C_sharp_Project.RofidaMohamed;
using C_sharp_Project.YoussifMohamed.Model.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharp_Project.EmanMetwallyElgharabawy
{
    public partial class Home_Page : Form
    {
        ClinicDB db = new ClinicDB();
        public Home_Page()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            PatientPage patient = new PatientPage();
            patient.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PatientPage patient = new PatientPage();
            patient.Show();
            this.Hide();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            DoctorPage doctorPage = new DoctorPage();
            doctorPage.Show();
            this.Hide();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DoctorPage doctorPage = new DoctorPage();
            doctorPage.Show();
            this.Hide();
        }

        private void numPatient_Click(object sender, EventArgs e)
        { }

        private void Home_Page_Load(object sender, EventArgs e)
        {
            numPatient.Text = db.Patient.Select(a => a).ToList().Count().ToString();
            numDoc.Text = db.Doctor.Select(a => a).ToList().Count().ToString();
            numRecep.Text = db.Reciptionist.Select(a => a).ToList().Count().ToString();
            numReserv.Text = db.ReciptionAddPatientDoc.Select(a => a).ToList().Count().ToString();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Receptionist recp = new Receptionist();
            recp.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Receptionist recp = new Receptionist();
            recp.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        { }

        private void label6_Click(object sender, EventArgs e)
        {
            LoginPage loPage = new LoginPage();
            loPage.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            LoginPage loPage = new LoginPage();
            loPage.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            LoginPage login = new LoginPage();
            login.Show();
            this.Hide();
        }
    }
}
