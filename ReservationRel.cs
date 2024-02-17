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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace C_sharp_Project.RofidaMohamed
{
    public partial class ReservationRel : Form
    {
        ClinicDB db = new ClinicDB();
        private int SelectedReserv;
        private int recepID;
        public ReservationRel(int recepID)
        {
            InitializeComponent();
            editbtn.Enabled = false;
            delbtn.Enabled = false;
            this.recepID = recepID;
        }

        private void load()
        {
            var reservations = db.ReciptionAddPatientDoc.OrderBy(res => res.Appointment).Select(
                res => new
                {
                    ID = res.Id,
                    Patient = res.Patient.Name,
                    Doctor = res.Doctor.Name,
                    Date = res.Appointment.ToString("d"),
                    Time = res.Appointment.ToString("t"),
                    Price = res.Price.ToString() + " $",
                    State = res.State == true ? "Done" : res.Appointment > DateTime.Now ? "Waiting" : "Missed"
                }).ToList();

            dataGridView1.DataSource = reservations;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Tag = row.Cells["ID"].Value;

            }
            dataGridView1.Columns["ID"].Visible = false;
            searchBox.Focus();
            searchBox.Text = string.Empty;
            SelSearchbox.SelectedIndex = -1;
            SelSearchbox.Items.Clear();
            SelSearchbox.Items.Add("Doctor");
            SelSearchbox.Items.Add("Patient");
            dataGridView1.ClearSelection();

        }

        private void ReservationRel_Load(object sender, EventArgs e)
        {
            load();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void ReservationRel_Activated(object sender, EventArgs e)
        {
            load();
            



        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            ResrveData rd = new ResrveData(recepID);
            rd.ShowDialog();

        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            ReciptionAddPatientDoc reserv = db.ReciptionAddPatientDoc.Find(SelectedReserv);
            ResrveData rd = new ResrveData(recepID, reserv);
            rd.ShowDialog();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];


                if (selectedRow.Tag != null && int.TryParse(selectedRow.Tag.ToString(), out int ResId))
                {
                    SelectedReserv = ResId;
                    editbtn.Enabled = true;
                    delbtn.Enabled = true;
                }

            }

        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            ReciptionAddPatientDoc reserv = db.ReciptionAddPatientDoc.Find(SelectedReserv);

            if (reserv != null)
            {

                db.Entry(reserv).State = EntityState.Modified;


                db.ReciptionAddPatientDoc.Remove(reserv);


                db.SaveChanges();


                load();
            }
        }


        private void searchBox_TextChanged(object sender, EventArgs e)
        {

            string str = searchBox.Text;
            if (SelSearchbox.SelectedIndex == -1)
            {
                MessageBox.Show("Please Selected what Column Wanna to Search ");
            }
            else
            {
                string selectedColumn = SelSearchbox.SelectedItem.ToString();
                if (selectedColumn == "Doctor")
                {
                    var reservations = db.ReciptionAddPatientDoc.OrderBy(res => res.Appointment)
                        .Where(R => R.Doctor.Name.StartsWith(str))
                        .Select(
                        res => new
                        {
                            ID = res.Id,
                            Patient = res.Patient.Name,
                            Doctor = res.Doctor.Name,
                            Date = res.Appointment.ToString("d"),
                            Time = res.Appointment.ToString("t"),
                            Price = res.Price.ToString() + " $",
                            State = res.State == true ? "Done" : res.Appointment > DateTime.Now ? "Waiting" : "Missed"

                        }
                        ).ToList();

                    dataGridView1.DataSource = reservations;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Tag = row.Cells["ID"].Value;

                    }
                    dataGridView1.Columns["ID"].Visible = false;
                }
                else if (selectedColumn == "Patient")
                {
                    var reservations = db.ReciptionAddPatientDoc.OrderBy(res => res.Appointment)
                        .Where(R => R.Patient.Name.StartsWith(str))
                        .Select(
                        res => new
                        {
                            ID = res.Id,
                            Patient = res.Patient.Name,
                            Doctor = res.Doctor.Name,
                            Date = res.Appointment.ToString("d"),
                            Time = res.Appointment.ToString("t"),
                            Price = res.Price.ToString() + " $",
                            State = res.State == true ? "Done" : res.Appointment > DateTime.Now ? "Waiting" : "Missed"

                        }
                        ).ToList();

                    dataGridView1.DataSource = reservations;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Tag = row.Cells["ID"].Value;

                    }
                    dataGridView1.Columns["ID"].Visible = false;

                }
            }

            dataGridView1.ClearSelection();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {

            var reservations = db.ReciptionAddPatientDoc.OrderBy(res => res.Appointment)
                .Where(r => r.Appointment.Date == dtpSearch.Value.Date)
                .Select(
                res => new
                {
                    ID = res.Id,
                    Patient = res.Patient.Name,
                    Doctor = res.Doctor.Name,
                    Date = res.Appointment.ToString("d"),
                    Time = res.Appointment.ToString("t"),
                    Price = res.Price.ToString() + " $",
                    State = res.State == true ? "Done" : res.Appointment > DateTime.Now ? "Waiting" : "Missed"

                }
                ).ToList();

            dataGridView1.DataSource = reservations;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Tag = row.Cells["ID"].Value;

            }
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.ClearSelection();

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            PatientPage ppage = new PatientPage(recepID);
            ppage.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            RespDash rec = new RespDash(recepID);
            rec.Show();
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

