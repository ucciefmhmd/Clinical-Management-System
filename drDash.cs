using C_sharp_Project.EmanMetwallyElgharabawy;
using ClinicManagement.Core.Services;

namespace C_sharp_Project.RofidaMohamed
{
    /// <summary>Doctor dashboard: the logged-in doctor's appointments for today.</summary>
    public partial class drDash : Form
    {
        private readonly int DocId;

        public drDash(int DocId)
        {
            InitializeComponent();
            this.DocId = DocId;
        }

        private void load()
        {
            Ui.Run(() =>
            {
                ShowRows(AppServices.Dashboard.GetTodayAppointments(DocId));
                var stats = AppServices.Dashboard.GetTodayStats(DocId);

                allLabel.Text = stats.Total.ToString();
                waitLabel.Text = stats.Waiting.ToString();
                DoneLabel.Text = stats.Done.ToString();

                progressBar1.Value = 0;
                progressBar1.Maximum = Math.Max(stats.Total, 1);
                progressBar1.Value = stats.Done;
                perclabel.Text = $"{stats.PercentDone}%";
            });

            //search part
            searchBox.Focus();
        }

        // The doctor column is always this doctor, so it is not shown.
        private void ShowRows(List<TodayAppointmentRow> rows) =>
            dataGridView1.DataSource = rows.Select(r => new { r.Patient, r.Time, r.Price, r.State }).ToList();

        private void drDash_Load(object sender, EventArgs e)
        {
            load();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            Ui.Run(() => ShowRows(AppServices.Dashboard.GetTodayAppointments(DocId, ReservationSearchField.Patient, searchBox.Text)));
        }

        private void addbtn_Click(object sender, EventArgs e) => Ui.Navigate(this, new PatientVisitPagecs(DocId));
        private void pictureBox11_Click(object sender, EventArgs e) => Ui.Navigate(this, new LoginPage());
        private void label6_Click(object sender, EventArgs e) => Ui.Navigate(this, new LoginPage());

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
