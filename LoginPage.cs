using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using C_sharp_Project.YoussifMohamed.Model.Database;
using C_sharp_Project.YoussifMohamed.Model.Entity;
using C_sharp_Project.EmanMetwallyElgharabawy;
using C_sharp_Project.RofidaMohamed;

namespace C_sharp_Project
{
    public partial class LoginPage : Form
    {
        ClinicDB db = new ClinicDB();


        public LoginPage()
        {
            InitializeComponent();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (Role.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Your Position");
            }
            else if (Role.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Please Enter Admin Name And Admin Password");
                }
                else if (txtUsername.Text == "Admin" && txtPassword.Text == "Admin123")
                {
                    PatientPage patientPage = new PatientPage();
                    patientPage.Show();
                    this.Hide();
                }
                else if (txtUsername.Text == "Admin" && txtPassword.Text == "Doctor123")
                {
                    DoctorPage DoctorPage = new DoctorPage();
                    DoctorPage.Show();
                    this.Hide();
                }
                else if (txtUsername.Text == "Admin" && txtPassword.Text == "Home123")
                {
                    Home_Page homePage = new Home_Page();
                    homePage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong UserName or Password");
                }
            }
            else if (Role.SelectedIndex == 1)
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Please Enter Doctor Name And Doctor Password");
                }
                else
                {
                    var checkDoctor = db.Doctor.FirstOrDefault(a => a.Name == txtUsername.Text && a.password == txtPassword.Text);
                    if (checkDoctor != null && checkDoctor.Name == txtUsername.Text)
                    {
                        drDash drdash = new drDash(checkDoctor.Id);
                        drdash.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Wrong UserName or Password");
                }
            }

            else if (Role.SelectedIndex == 2)
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Please Enter Reciptionist Name And Reciptionist Password");
                }
                else
                {
                    var checkRecep = db.Reciptionist.FirstOrDefault(a => a.Name == txtUsername.Text && a.Password == txtPassword.Text);
                    if (checkRecep != null)
                    {
                        PatientPage PatientPage = new PatientPage(checkRecep.Id);
                        PatientPage.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong UserName or Password");
                    }
                }
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Role.SelectedIndex = -1;
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
