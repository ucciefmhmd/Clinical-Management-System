using C_sharp_Project.EmanMetwallyElgharabawy;
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

namespace C_sharp_Project.RofidaMohamed
{
    public partial class drDash : Form
    {
        ClinicDB db = new ClinicDB();
        private int DocId;
        public drDash(int DocId)
        {
            InitializeComponent();
            this.DocId = DocId;
        }

        private void load()
        {
            var list = db.ReciptionAddPatientDoc
               .Where(r => r.Appointment.Date == DateTime.Now.Date && r.DoctorID == DocId)
               .OrderBy(r => r.Appointment)
               .Select(
                   res => new
                   {
                       Patient = res.Patient.Name,
                       Time = res.Appointment.ToString("t"),
                       State = res.State == true ? "Done" : res.Appointment > DateTime.Now ? "Waiting" : "Missed"
                   }
               ).ToList();

            dataGridView1.DataSource = list;

            var wait = db.ReciptionAddPatientDoc.Where(r => r.Appointment.Date == DateTime.Now.Date && r.State == false && r.DoctorID == DocId).ToList();

            int allNo = list.Count;
            int waitNo = wait.Count;
            int doneNo = list.Count - wait.Count;

            //lable

            allLabel.Text = allNo.ToString();
            waitLabel.Text = waitNo.ToString();
            DoneLabel.Text = doneNo.ToString();

            //progress bar
            progressBar1.Maximum = allNo;
            progressBar1.Value = doneNo;
            int num = (int)(((float)doneNo / allNo) * 100);
            perclabel.Text = $"{num}%";

            //search part
            searchBox.Focus();
            searchBox.Text = string.Empty;

        }

        private void drDash_Load(object sender, EventArgs e)
        {
            load();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string str = searchBox.Text;
            var reservations = db.ReciptionAddPatientDoc
                        .OrderBy(res => res.Appointment)
                        .Where(R => R.Patient.Name.StartsWith(str) && R.Appointment.Date == DateTime.Now.Date && R.DoctorID == DocId)
                        .Select(
                        res => new
                        {

                            Patient = res.Patient.Name,
                            Doctor = res.Doctor.Name,

                            Time = res.Appointment.ToString("t"),
                            Price = res.Price.ToString() + " $",
                            State = res.State == true ? "Done" : res.Appointment > DateTime.Now ? "Waiting" : "Missed"

                        }
                        ).ToList();

            dataGridView1.DataSource = reservations;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PatientVisitPagecs f = new PatientVisitPagecs(DocId);

            f.Show();
            this.Hide();

        }



        private void addbtn_Click(object sender, EventArgs e)
        {
            PatientVisitPagecs vistipage = new PatientVisitPagecs(DocId);
            vistipage.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        { }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }
    }
}
