using C_sharp_Project.EmanMetwallyElgharabawy;
using C_sharp_Project.RofidaMohamed;
using ClinicManagement.Core.Services;

namespace C_sharp_Project
{
    /// <summary>Patient register. Opened by the admin (no receptionist id) or by a receptionist.</summary>
    public partial class PatientPage : Form
    {
        private const int AdminMode = -1;
        private readonly int RecpId = AdminMode;
        /// <summary>Id of the patient loaded by double-clicking the grid; 0 = none.</summary>
        private int selectedId;

        public PatientPage()
        {
            InitializeComponent();
        }

        public PatientPage(int RecpId)
        {
            this.RecpId = RecpId;
            InitializeComponent();
        }

        private bool IsAdmin => RecpId == AdminMode;

        public void GetData(string? nameFilter = null)
        {
            Ui.Run(() => dataGridView1.DataSource = AppServices.Patients.Search(nameFilter));
        }

        private void PatientPage_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void Clear()
        {
            selectedId = 0;
            textBoxPName.Text = "";
            textBoxPAddress.Text = "";
            textBoxPPhone.Text = "";
            comboBoxPGender.Text = "";
            dateTimePickerPDOB.Value = DateTime.Now;
        }

        private PatientInput ReadForm() => new(
            textBoxPName.Text, textBoxPAddress.Text, textBoxPPhone.Text, comboBoxPGender.Text, dateTimePickerPDOB.Value);

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (Ui.Run(() => AppServices.Patients.Add(ReadForm())))
            {
                GetData();
                Clear();
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (Ui.Run(() => AppServices.Patients.Update(selectedId, ReadForm())))
            {
                GetData();
                Clear();
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedId <= 0)
            {
                MessageBox.Show("Please double-click a patient in the list first.");
                return;
            }
            if (!Ui.Confirm($"Delete patient '{textBoxPName.Text}'?{Environment.NewLine}" +
                            "Their reservations and visit records will be deleted too."))
                return;
            if (Ui.Run(() => AppServices.Patients.Delete(selectedId)))
            {
                GetData();
                Clear();
            }
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            GetData(textBoxPName.Text);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (Ui.CurrentRowId(dataGridView1) is not int id)
                return;
            Ui.Run(() =>
            {
                var ptn = AppServices.Patients.Get(id);
                if (ptn == null)
                {
                    MessageBox.Show("This patient no longer exists.");
                    GetData();
                    return;
                }
                selectedId = ptn.Id;
                textBoxPName.Text = ptn.Name;
                textBoxPAddress.Text = ptn.Address;
                textBoxPPhone.Text = ptn.Phone;
                comboBoxPGender.Text = ptn.Gender;
                dateTimePickerPDOB.Value = ptn.DOB;
            });
        }

        // ---- navigation ----

        private void OpenReservations()
        {
            if (!IsAdmin)
                Ui.Navigate(this, new ReservationRel(RecpId));
        }

        private void OpenPatients() => Ui.Navigate(this, IsAdmin ? new PatientPage() : new PatientPage(RecpId));

        private void OpenDoctors()
        {
            if (IsAdmin)
                Ui.Navigate(this, new DoctorPage());
        }

        private void OpenReceptionists()
        {
            if (IsAdmin)
                Ui.Navigate(this, new Receptionist());
        }

        private void label3_Click(object sender, EventArgs e) => OpenReservations();
        private void pictureBox12_Click(object sender, EventArgs e) => OpenReservations();
        private void label2_Click(object sender, EventArgs e) => OpenPatients();
        private void pictureBox2_Click(object sender, EventArgs e) => OpenPatients();
        private void label4_Click(object sender, EventArgs e) => OpenDoctors();
        private void pictureBox5_Click(object sender, EventArgs e) => OpenDoctors();
        private void label1_Click(object sender, EventArgs e) => OpenReceptionists();
        private void pictureBox3_Click(object sender, EventArgs e) => OpenReceptionists();
        private void label6_Click(object sender, EventArgs e) => Ui.Navigate(this, new LoginPage());
        private void pictureBox6_Click(object sender, EventArgs e) => Ui.Navigate(this, new LoginPage());

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (IsAdmin)
                Ui.Navigate(this, new Home_Page());
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
