using ClinicManagement.Core.Services;

namespace C_sharp_Project.RofidaMohamed
{
    /// <summary>Receptionist dashboard: today's appointments for every doctor.</summary>
    public partial class RespDash : Form
    {
        private readonly int recepID;

        public RespDash(int recepID)
        {
            InitializeComponent();
            this.recepID = recepID;
            SelSearchbox.Items.Add("Doctor");
            SelSearchbox.Items.Add("Patient");
        }

        private void RespDash_Load(object sender, EventArgs e)
        {
            Ui.Run(() =>
            {
                dataGridView1.DataSource = AppServices.Dashboard.GetTodayAppointments();
                ShowStats(AppServices.Dashboard.GetTodayStats());
            });

            //search part
            searchBox.Focus();
            SelSearchbox.SelectedIndex = -1;
        }

        private void ShowStats(DashboardStats stats)
        {
            allLabel.Text = stats.Total.ToString();
            waitLabel.Text = stats.Waiting.ToString();
            DoneLabel.Text = stats.Done.ToString();

            progressBar1.Value = 0;
            progressBar1.Maximum = Math.Max(stats.Total, 1);
            progressBar1.Value = stats.Done;
            perclabel.Text = $"{stats.PercentDone}%";
        }

        /// <summary>Filters as you type. With no column chosen, matches either the doctor's or the patient's name.</summary>
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            ReservationSearchField? field = SelSearchbox.SelectedIndex switch
            {
                0 => ReservationSearchField.Doctor,
                1 => ReservationSearchField.Patient,
                _ => null,
            };
            Ui.Run(() => dataGridView1.DataSource = AppServices.Dashboard.GetTodayAppointments(null, field, searchBox.Text));
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e) => Ui.Navigate(this, new LoginPage());
        private void label5_Click_1(object sender, EventArgs e) => Ui.Navigate(this, new PatientPage(recepID));
        private void pictureBox14_Click_1(object sender, EventArgs e) => Ui.Navigate(this, new PatientPage(recepID));
        private void label1_Click_1(object sender, EventArgs e) => Ui.Navigate(this, new ReservationRel(recepID));
        private void pictureBox12_Click(object sender, EventArgs e) => Ui.Navigate(this, new ReservationRel(recepID));
    }
}
