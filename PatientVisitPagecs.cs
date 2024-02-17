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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C_sharp_Project.EmanMetwallyElgharabawy
{
    public partial class PatientVisitPagecs : Form
    {
        private int doctorId;
        ClinicDB db = new ClinicDB();
        private int SelectedId;
        public PatientVisitPagecs(int DoctorId)
        {
            InitializeComponent();
            doctorId = DoctorId;
            editbtn.Enabled = false;
            delBtn.Enabled = false;
        }

        private void load()
        {
            var patientWait = db.ReciptionAddPatientDoc
                .Where(r => r.Appointment.Date == DateTime.Now.Date && r.DoctorID == doctorId && r.State == false)
                .Select(p => new { name = p.Patient.Name, id = p.PatientID }).ToList();

            PatientBox.DisplayMember = "name";
            PatientBox.ValueMember = "id";
            PatientBox.DataSource = patientWait;
            PatientBox.SelectedIndex = -1;


            var patientDone = db.ReciptionAddPatientDoc
            .Where(r => r.Appointment.Date == DateTime.Now.Date && r.DoctorID == doctorId && r.State == true)
            .Select(p => new { Name = p.Patient.Name, Id = p.PatientID })
            .ToList();

            var prescriptionData = db.Doctorspatient
                .Where(p => p.DoctorID == doctorId)
                .GroupBy(p => p.PatientID)
                .Select(group => group.OrderByDescending(p => p.Id).FirstOrDefault())
                .ToList(); // Fetch data from the database

            var prescription = prescriptionData
                .Join(patientDone,
                    presc => presc.PatientID,
                    done => done.Id,
                    (presc, done) => new
                    {
                        ID = presc.Id,
                        Patient = done.Name,
                        Medicine = presc.Medicine,
                        Diagnosis = presc.Diagnosis
                    })
                .ToList();

            dataGridView1.DataSource = prescription;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Tag = row.Cells["ID"].Value;

            }
            dataGridView1.Columns["ID"].Visible = false;


            dataGridView1.ClearSelection();

        }

        private void PatientVisitPagecs_Load(object sender, EventArgs e)
        {
            load();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            Doctorspatient prescription = new Doctorspatient();

            prescription.DoctorID = doctorId;
            prescription.PatientID = Convert.ToInt32(PatientBox.SelectedValue);
            prescription.Medicine = medText.Text;
            prescription.Diagnosis = DiagText.Text;

            var reser = db.ReciptionAddPatientDoc
                .Where(
                        p =>
                        p.PatientID == prescription.PatientID &&
                        p.DoctorID == prescription.DoctorID &&
                        p.Appointment.Date == DateTime.Now.Date
                    ).FirstOrDefault();

            if (reser != null)
            {
                reser.State = true;
                db.ReciptionAddPatientDoc.Update(reser);

            }


            db.Doctorspatient.Add(prescription);
            db.SaveChanges();
            load();
            Clear();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];



                if (selectedRow.Tag != null && int.TryParse(selectedRow.Tag.ToString(), out int ResId))
                {
                    SelectedId = ResId;
                    PatientBox.SelectedText = null;
                    PatientBox.SelectedText = selectedRow.Cells["Patient"].Value.ToString();
                    medText.Text = selectedRow.Cells["Medicine"].Value.ToString();
                    DiagText.Text = selectedRow.Cells["Diagnosis"].Value.ToString();
                    editbtn.Enabled = true;
                    delBtn.Enabled = true;
                    addbtn.Enabled = false;
                    PatientBox.Enabled = false;
                }
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            Doctorspatient ToDelete = db.Doctorspatient.Find(SelectedId);

            if (ToDelete != null)
            {

                var reser = db.ReciptionAddPatientDoc
               .Where(
                       p =>
                       p.PatientID == ToDelete.PatientID &&
                       p.DoctorID == ToDelete.DoctorID &&
                       p.Appointment.Date == DateTime.Now.Date
                   ).FirstOrDefault();

                if (reser != null)
                {
                    reser.State = false;
                    db.ReciptionAddPatientDoc.Update(reser);

                }

                db.Doctorspatient.Entry(ToDelete).State = EntityState.Modified;
                db.Doctorspatient.Remove(ToDelete);



                db.SaveChanges();

                Clear();
                load();
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            Doctorspatient ToEdit = db.Doctorspatient.Find(SelectedId);

            if (ToEdit != null)
            {
                ToEdit.Medicine = medText.Text;
                ToEdit.Diagnosis = DiagText.Text;
            }
            db.Doctorspatient.Update(ToEdit);
            db.SaveChanges();
            Clear();
            load();

        }

        private void Clear()
        {
            dataGridView1.ClearSelection();
            medText.Text = DiagText.Text = string.Empty;

            PatientBox.SelectedText = null;
            PatientBox.Enabled = true;
            addbtn.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string str = textBox1.Text.ToLower();

            var patientDone = db.ReciptionAddPatientDoc
         .Where(r => r.Appointment.Date == DateTime.Now.Date && r.DoctorID == doctorId && r.State == true)
         .Select(p => new { Name = p.Patient.Name, Id = p.PatientID })
         .ToList();

            var prescriptionData = db.Doctorspatient
                .Where(p => p.DoctorID == doctorId)
                .GroupBy(p => p.PatientID)
                .Select(group => group.OrderByDescending(p => p.Id).FirstOrDefault())
                .ToList(); // Fetch data from the database

            var prescription = prescriptionData
                .Join(patientDone,
                    presc => presc.PatientID,
                    done => done.Id,
                    (presc, done) => new
                    {
                        ID = presc.Id,
                        Patient = done.Name,
                        Medicine = presc.Medicine,
                        Diagnosis = presc.Diagnosis
                    })
                .Where(S => S.Patient.ToLower().StartsWith(str))
                .ToList();

            dataGridView1.DataSource = prescription;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Tag = row.Cells["ID"].Value;

            }
            dataGridView1.Columns["ID"].Visible = false;


            dataGridView1.ClearSelection();
        }

        private void PatientVisitPagecs_Click(object sender, EventArgs e)
        {
            Clear();
            textBox1.Clear();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            drDash drdash = new drDash(doctorId);
            drdash.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
