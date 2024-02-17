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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C_sharp_Project
{
    public partial class Receptionist : Form
    {
        ClinicDB db = new ClinicDB();
        Reciptionist Recp = new Reciptionist();
        public Receptionist()
        {
            InitializeComponent();
            Display();
        }

        public void Display()
        {
            var model = db.Reciptionist.Select(a => new { ID = a.Id, Name = a.Name, Gender = a.Gender, Address = a.Address, Phone = a.Phone, Password = a.Password }).ToList();
            dataGridView1.DataSource = model;
        }
        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            var searchName = textBox1.Text.Trim();
            var datasearch = db.Reciptionist.Where(s => s.Name == searchName).Select(a => new { ID = a.Id, Name = a.Name, Gender = a.Gender, Address = a.Address, Phone = a.Phone, Password = a.Password }).ToList();
            dataGridView1.DataSource = datasearch;
        }


        private void addbtn_Click(object sender, EventArgs e)
        {
            Recp.Name = textBox1.Text;
            Recp.Gender = comboBox1.Text;
            Recp.Address = textBox3.Text;
            Recp.Phone = textBox2.Text;
            Recp.Password = textBox4.Text;
            db.Reciptionist.Add(Recp);
            db.SaveChanges();
            Display();
            Clear();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            Recp.Name = textBox1.Text;
            Recp.Gender = comboBox1.Text;
            Recp.Address = textBox3.Text;
            Recp.Phone = textBox2.Text;
            Recp.Password = textBox4.Text;
            db.Entry(Recp).State = EntityState.Modified;
            db.SaveChanges();
            Display();
            Clear();
        }



        private void deletebtn_Click(object sender, EventArgs e)
        {
            var entry = db.Entry(Recp);
            if (entry.State == EntityState.Detached)
                db.Reciptionist.Attach(Recp);
            db.Reciptionist.Remove(Recp);
            db.SaveChanges();
            Display();
            Clear();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label11_Click(object sender, EventArgs e)
        { }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home_Page hpage = new Home_Page();
            hpage.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            LoginPage lpage = new LoginPage();
            lpage.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            LoginPage lpage = new LoginPage();
            lpage.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            PatientPage patientPage = new PatientPage();
            patientPage.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PatientPage patientPage = new PatientPage();
            patientPage.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DoctorPage dpage = new DoctorPage();
            dpage.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DoctorPage dpage = new DoctorPage();
            dpage.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //ReservationRel reservation = new ReservationRel();
            //reservation.Show();
            //this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        { }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            //ReservationRel reservation = new ReservationRel();
            //reservation.Show();
            //this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Receptionist receptionist = new Receptionist();
            receptionist.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Receptionist receptionist = new Receptionist();
            receptionist.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                Recp.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                Recp = db.Reciptionist.Where(a => a.Id == Recp.Id).FirstOrDefault();
                textBox1.Text = Recp.Name;
                comboBox1.Text = Recp.Gender;
                textBox3.Text = Recp.Address;
                textBox2.Text = Recp.Phone;
                textBox4.Text = Recp.Password;
            }
        }
    }
}
