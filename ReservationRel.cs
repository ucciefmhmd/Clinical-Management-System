using ClinicManagement.Core.Services;

namespace C_sharp_Project.RofidaMohamed
{
    /// <summary>Receptionist page listing all reservations, with add / edit / delete and search.</summary>
    public partial class ReservationRel : Form
    {
        /// <summary>Id of the selected reservation; 0 = none.</summary>
        private int SelectedReserv;
        private readonly int recepID;
        /// <summary>Set while load() resets the search box, so that reset does not trigger a search.</summary>
        private bool reloading;

        public ReservationRel(int recepID)
        {
            InitializeComponent();
            this.recepID = recepID;
            SelSearchbox.Items.Add("Doctor");
            SelSearchbox.Items.Add("Patient");
            SetSelection(0);
        }

        private void load()
        {
            reloading = true;
            searchBox.Text = string.Empty;
            reloading = false;
            SelSearchbox.SelectedIndex = -1;
            Ui.Run(() => Bind(AppServices.Reservations.Search()));
            searchBox.Focus();
        }

        private void Bind(List<ReservationRow> rows)
        {
            dataGridView1.DataSource = rows;
            if (dataGridView1.Columns.Contains("ID"))
                dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.ClearSelection();
            SetSelection(0);
        }

        private void SetSelection(int id)
        {
            SelectedReserv = id;
            editbtn.Enabled = id > 0;
            delbtn.Enabled = id > 0;
        }

        private void ReservationRel_Load(object sender, EventArgs e)
        {
            load();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            using var rd = new ResrveData(recepID);
            if (rd.ShowDialog(this) == DialogResult.OK)
                load();
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (SelectedReserv <= 0)
            {
                MessageBox.Show("Please select a reservation first.");
                return;
            }
            using var rd = new ResrveData(recepID, SelectedReserv);
            if (rd.ShowDialog(this) == DialogResult.OK)
                load();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int id = 0;
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.Columns.Contains("ID")
                && dataGridView1.SelectedRows[0].Cells["ID"].Value is int value)
                id = value;
            SetSelection(id);
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            if (SelectedReserv <= 0)
            {
                MessageBox.Show("Please select a reservation first.");
                return;
            }
            if (!Ui.Confirm("Delete the selected reservation?"))
                return;
            if (Ui.Run(() => AppServices.Reservations.Delete(SelectedReserv)))
                load();
        }

        /// <summary>Filters as you type. With no column chosen, matches either the doctor's or the patient's name.</summary>
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (reloading)
                return;
            ReservationSearchField? field = SelSearchbox.SelectedIndex switch
            {
                0 => ReservationSearchField.Doctor,
                1 => ReservationSearchField.Patient,
                _ => null,
            };
            Ui.Run(() => Bind(AppServices.Reservations.Search(field, searchBox.Text)));
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            Ui.Run(() => Bind(AppServices.Reservations.OnDate(dtpSearch.Value)));
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e) => Ui.Navigate(this, new PatientPage(recepID));
        private void bunifuThinButton21_Click(object sender, EventArgs e) => Ui.Navigate(this, new RespDash(recepID));
        private void label6_Click(object sender, EventArgs e) => Ui.Navigate(this, new LoginPage());
    }
}
