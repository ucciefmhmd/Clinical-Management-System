using C_sharp_Project.YoussifMohamed.Model.Database;
using C_sharp_Project.YoussifMohamed.Model.Entity;
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

namespace C_sharp_Project.RofidaMohamed
{
    public partial class ResrveData : Form
    {
        private bool isDragging = false;
        private Point lastCursorPosition;
        private int receptionistId;
        private ReciptionAddPatientDoc SelectedResrve;

        ClinicDB db = new ClinicDB();
        public ResrveData(int respId)
        {
            InitializeComponent();
            receptionistId = respId;
            //to moveable 
            this.MouseDown += MainForm_MouseDown;
            this.MouseMove += MainForm_MouseMove;
            this.MouseUp += MainForm_MouseUp;

            label1.Text = "Add New An Appointment";
            okbtn.Text = "Add";


        }

        public ResrveData(int respId, ReciptionAddPatientDoc Reseve) : this(respId)
        {
            SelectedResrve = Reseve;
            label1.Text = "Edit this An Appointment";
            okbtn.Text = "Edit";
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPosition = new Point(e.X, e.Y);
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newCursorPosition = new Point(e.X, e.Y);
                int deltaX = newCursorPosition.X - lastCursorPosition.X;
                int deltaY = newCursorPosition.Y - lastCursorPosition.Y;

                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void load()
        {
            var patients = db.Patient.Select(p => new { name = p.Name, id = p.Id }).ToList();


            PatientBox.DisplayMember = "name";
            PatientBox.ValueMember = "id";
            PatientBox.DataSource = patients;
            PatientBox.SelectedIndex = -1;

            var doctors = db.Doctor.Select(d => new { name = d.Name, id = d.Id }).ToList();

            drBox.DisplayMember = "name";
            drBox.ValueMember = "id";
            drBox.DataSource = doctors;
            drBox.SelectedIndex = -1;


            StateBox.DisplayMember = "Text";
            StateBox.ValueMember = "Value";

            var items = new[] {
                new { Text = "Waiting", Value = false },
                new { Text = "Done", Value = true },

            };
            StateBox.DataSource = items;

            if (SelectedResrve != null)
            {
                PatientBox.SelectedValue = SelectedResrve.PatientID;
                drBox.SelectedValue = SelectedResrve.DoctorID;
                dtp1.Value = SelectedResrve.Appointment;
                priceTextBox.Text = SelectedResrve.Price.ToString();
                StateBox.SelectedValue = SelectedResrve.State;
            }
            else
            {
                dtp1.MinDate = DateTime.Now;
                StateBox.Enabled = false;
            }





        }

        private void okbtn_Click(object sender, EventArgs e)
        {
            

            int price;
            bool check = int.TryParse(priceTextBox.Text, out price);
            if (check)
            {
                if (SelectedResrve != null)
                {
                    SelectedResrve.PatientID = Convert.ToInt32(PatientBox.SelectedValue);
                    SelectedResrve.DoctorID = Convert.ToInt32(drBox.SelectedValue);
                    SelectedResrve.ReciptionistID = receptionistId;

                    SelectedResrve.Appointment = dtp1.Value;
                    SelectedResrve.Price = int.Parse(priceTextBox.Text);
                    SelectedResrve.State = Convert.ToBoolean(StateBox.SelectedValue);
                    db.ReciptionAddPatientDoc.Update(SelectedResrve);
                    

                } else 
                {
                    ReciptionAddPatientDoc resrve = new ReciptionAddPatientDoc();
                    resrve.PatientID = Convert.ToInt32(PatientBox.SelectedValue);
                    resrve.DoctorID = Convert.ToInt32(drBox.SelectedValue);
                    resrve.ReciptionistID = receptionistId;

                    resrve.Appointment = dtp1.Value;
                    resrve.Price = int.Parse(priceTextBox.Text);
                    resrve.State = false;

                    db.ReciptionAddPatientDoc.Add(resrve);
                    
                }
                db.SaveChanges();
                this.Close();

            }
            else
            {
                MessageBox.Show("Plz Enter Right Price");
            }





        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResrveData_Load(object sender, EventArgs e)
        {
            load();
        }
    }


}
