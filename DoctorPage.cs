using C_sharp_Project.EmanMetwallyElgharabawy;
using ClinicManagement.Core.Services;

namespace C_sharp_Project
{
    /// <summary>Admin page for doctors. Passwords are never shown; leave the box empty on Update to keep the current one.</summary>
    public partial class DoctorPage : Form
    {
        /// <summary>Id of the doctor loaded by double-clicking the grid; 0 = none.</summary>
        private int selectedId;

        public DoctorPage()
        {
            InitializeComponent();
        }

        private void DoctorPage_Load(object sender, EventArgs e)
        {
            display();
        }

        private void Clear()
        {
            selectedId = 0;
            Doctorname.Text = "";
            DoctorAddress.Text = "";
            Doctorphone.Text = "";
            Doctorspecialation.Text = "";
            DoctorExperiance.Text = "";
            Doctorpassword.Text = "";
            Doctorpassword.PlaceholderText = "";
            DoctorGender.Text = "";
            DoctorBirthofdate.Value = DateTime.Now;
        }

        /// <summary>Always binds the same row type (with Id, without password), so double-click keeps working after Add or Search.</summary>
        public void display(string? exactName = null)
        {
            Ui.Run(() => dataGridView1.DataSource = AppServices.Doctors.Search(exactName));
        }

        private DoctorInput ReadForm() => new(
            Doctorname.Text, DoctorGender.Text, Doctorspecialation.Text, DoctorExperiance.Text,
            DoctorAddress.Text, Doctorphone.Text, DoctorBirthofdate.Value, Doctorpassword.Text);

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (Ui.Run(() => AppServices.Doctors.Add(ReadForm())))
            {
                display();
                Clear();
                MessageBox.Show("Doctor Added successfully!");
            }
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            display(Doctorname.Text);
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedId <= 0)
            {
                MessageBox.Show("Please double-click a doctor in the list first.");
                return;
            }
            if (!Ui.Confirm($"Delete doctor '{Doctorname.Text}'?{Environment.NewLine}" +
                            "Their reservations and visit records will be deleted too."))
                return;
            if (Ui.Run(() => AppServices.Doctors.Delete(selectedId)))
            {
                display();
                Clear();
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (Ui.Run(() => AppServices.Doctors.Update(selectedId, ReadForm())))
            {
                display();
                Clear();
            }
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (Ui.CurrentRowId(dataGridView1) is not int id)
                return;
            Ui.Run(() =>
            {
                var doctor = AppServices.Doctors.Get(id);
                if (doctor == null)
                {
                    MessageBox.Show("This doctor no longer exists.");
                    display();
                    return;
                }
                selectedId = doctor.Id;
                Doctorname.Text = doctor.Name;
                DoctorGender.Text = doctor.Gender;
                DoctorAddress.Text = doctor.Address;
                Doctorphone.Text = doctor.Phone;
                Doctorspecialation.Text = doctor.Specialization;
                DoctorExperiance.Text = doctor.Experience;
                DoctorBirthofdate.Value = doctor.DOB;
                Doctorpassword.Text = "";
                Doctorpassword.PlaceholderText = "unchanged if empty";
            });
        }

        // ---- navigation ----

        private void pictureBox1_Click(object sender, EventArgs e) => Ui.Navigate(this, new Home_Page());
        private void label2_Click(object sender, EventArgs e) => Ui.Navigate(this, new PatientPage());
        private void pictureBox2_Click(object sender, EventArgs e) => Ui.Navigate(this, new PatientPage());
        private void label1_Click(object sender, EventArgs e) => Ui.Navigate(this, new Receptionist());
        private void pictureBox3_Click(object sender, EventArgs e) => Ui.Navigate(this, new Receptionist());
        private void label6_Click(object sender, EventArgs e) => Ui.Navigate(this, new LoginPage());
        private void pictureBox6_Click(object sender, EventArgs e) => Ui.Navigate(this, new LoginPage());

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
