using C_sharp_Project.RofidaMohamed;
using ClinicManagement.Core.Services;

namespace C_sharp_Project.EmanMetwallyElgharabawy
{
    /// <summary>Doctor page: record diagnosis + medicine for today's waiting patients (marks the reservation Done).</summary>
    public partial class PatientVisitPagecs : Form
    {
        private readonly int doctorId;
        /// <summary>Id of the visit record selected in the grid; 0 = none.</summary>
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
            Ui.Run(() =>
            {
                PatientBox.DisplayMember = nameof(LookupItem.Name);
                PatientBox.ValueMember = nameof(LookupItem.Id);
                PatientBox.DataSource = AppServices.Visits.GetWaitingPatientsToday(doctorId);
                PatientBox.SelectedIndex = -1;

                BindVisits(AppServices.Visits.GetTodayVisits(doctorId));
            });
        }

        private void BindVisits(List<VisitRow> rows)
        {
            dataGridView1.DataSource = rows;
            if (dataGridView1.Columns.Contains("ID"))
                dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.ClearSelection();
        }

        private void PatientVisitPagecs_Load(object sender, EventArgs e)
        {
            load();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            int? patientId = Ui.SelectedId(PatientBox);
            if (Ui.Run(() => AppServices.Visits.AddVisit(doctorId, patientId, medText.Text, DiagText.Text)))
            {
                load();
                Clear();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 || !dataGridView1.Columns.Contains("ID"))
                return;
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            if (selectedRow.Cells["ID"].Value is not int visitId)
                return;

            SelectedId = visitId;
            PatientBox.SelectedIndex = -1;
            PatientBox.Text = selectedRow.Cells["Patient"].Value?.ToString();
            medText.Text = selectedRow.Cells["Medicine"].Value?.ToString();
            DiagText.Text = selectedRow.Cells["Diagnosis"].Value?.ToString();
            editbtn.Enabled = true;
            delBtn.Enabled = true;
            addbtn.Enabled = false;
            PatientBox.Enabled = false;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (SelectedId <= 0)
            {
                MessageBox.Show("Please select a visit record first.");
                return;
            }
            if (!Ui.Confirm("Delete this visit record? Today's appointment goes back to waiting."))
                return;
            if (Ui.Run(() => AppServices.Visits.DeleteVisit(SelectedId)))
            {
                Clear();
                load();
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (Ui.Run(() => AppServices.Visits.UpdateVisit(SelectedId, medText.Text, DiagText.Text)))
            {
                Clear();
                load();
            }
        }

        private void Clear()
        {
            SelectedId = 0;
            dataGridView1.ClearSelection();
            medText.Text = DiagText.Text = string.Empty;

            PatientBox.SelectedIndex = -1;
            PatientBox.Text = string.Empty;
            PatientBox.Enabled = true;
            addbtn.Enabled = true;
            editbtn.Enabled = false;
            delBtn.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Ui.Run(() => BindVisits(AppServices.Visits.GetTodayVisits(doctorId, textBox1.Text)));
        }

        private void PatientVisitPagecs_Click(object sender, EventArgs e)
        {
            Clear();
            textBox1.Clear();
        }

        private void pictureBox4_Click(object sender, EventArgs e) => Ui.Navigate(this, new drDash(doctorId));
        private void label6_Click(object sender, EventArgs e) => Ui.Navigate(this, new LoginPage());
        // The icon next to "Logout" (its handler used to be empty).
        private void pictureBox6_Click(object sender, EventArgs e) => Ui.Navigate(this, new LoginPage());

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
