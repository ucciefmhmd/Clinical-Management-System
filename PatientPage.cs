using C_sharp_Project.EmanMetwallyElgharabawy;
using C_sharp_Project.RofidaMohamed;
using C_sharp_Project.YoussifMohamed.Model.Database;
using C_sharp_Project.YoussifMohamed.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C_sharp_Project
{
    public partial class PatientPage : Form
    {
        ClinicDB db = new ClinicDB();
        Patient ptn = new Patient();
        private int RecpId = -1;
        public PatientPage()
        {
            InitializeComponent();
        }
        public PatientPage(int RecpId)
        {
            this.RecpId = RecpId;
            InitializeComponent();
        }

        public void GetData()
        {
            var patientData = db.Patient.Select(p => new { Id = p.Id, Name = p.Name, Address = p.Address, DOB = p.DOB, Phone = p.Phone, Gender = p.Gender }).ToList();
            dataGridView1.DataSource = patientData;
        }

        private void PatientPage_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void Clear()
        {
            textBoxPName.Text = "";
            textBoxPAddress.Text = "";
            textBoxPPhone.Text = "";
            comboBoxPGender.Text = "";
            dateTimePickerPDOB.Value = DateTime.Now;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            ptn.Name = textBoxPName.Text;
            ptn.Address = textBoxPAddress.Text;
            ptn.Phone = textBoxPPhone.Text;
            ptn.Gender = comboBoxPGender.Text;
            ptn.DOB = dateTimePickerPDOB.Value;

            db.Patient.Add(ptn);
            db.SaveChanges();
            GetData();
            Clear();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            ptn.Name = textBoxPName.Text;
            ptn.Address = textBoxPAddress.Text;
            ptn.Phone = textBoxPPhone.Text;
            ptn.Gender = comboBoxPGender.Text;
            ptn.DOB = dateTimePickerPDOB.Value;

            db.Entry(ptn).State = EntityState.Modified;
            db.SaveChanges();
            GetData();
            Clear();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            var data = db.Entry(ptn);
            if (data.State == EntityState.Detached)
                db.Patient.Attach(ptn);
            db.Patient.Remove(ptn);
            db.SaveChanges();
            GetData();
            Clear();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            string SearchName = textBoxPName.Text;
            var SearchResult = db.Patient.Where(a => a.Name.Contains(SearchName))
                .Select(p => new { Id = p.Id, Name = p.Name, Address = p.Address, DOB = p.DOB, Phone = p.Phone, Gender = p.Gender })
                .ToList();

            dataGridView1.DataSource = SearchResult;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }


        private void label3_Click(object sender, EventArgs e)
        {
            if (RecpId != -1)
            {
                ReservationRel reservation = new ReservationRel(RecpId);
                reservation.Show();
                this.Hide();
            }

        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (RecpId != -1)
            {
                ReservationRel reservation = new ReservationRel(RecpId);
                reservation.Show();
                this.Hide();
            }
        }
        private void label10_Click(object sender, EventArgs e)
        { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }

        private void label2_Click(object sender, EventArgs e)
        {
            PatientPage ppage = new PatientPage();
            ppage.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (RecpId == -1)
            {
                DoctorPage dpage = new DoctorPage();
                dpage.Show();
                this.Hide();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PatientPage ppage = new PatientPage();
            ppage.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (RecpId == -1)
            {
                DoctorPage dpage = new DoctorPage();
                dpage.Show();
                this.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (RecpId == -1)
            {
                Receptionist rep = new Receptionist();
                rep.Show();
                this.Hide();
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (RecpId == -1)
            {
                Receptionist rep = new Receptionist();
                rep.Show();
                this.Hide();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (RecpId == -1)
            {
                Home_Page home_Page = new Home_Page();
                home_Page.Show();
                this.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                ptn.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                ptn = db.Patient.Where(a => a.Id == ptn.Id).FirstOrDefault();
                textBoxPName.Text = ptn.Name;
                textBoxPAddress.Text = ptn.Address;
                textBoxPPhone.Text = ptn.Phone;
                comboBoxPGender.Text = ptn.Gender;
                dateTimePickerPDOB.Value = ptn.DOB;
            }
        }
    }
}
