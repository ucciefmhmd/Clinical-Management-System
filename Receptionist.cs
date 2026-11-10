using C_sharp_Project.EmanMetwallyElgharabawy;
using ClinicManagement.Core.Services;

namespace C_sharp_Project
{
    /// <summary>Admin page for receptionists. Passwords are never shown; leave the box empty on Update to keep the current one.</summary>
    public partial class Receptionist : Form
    {
        /// <summary>Id of the receptionist loaded by double-clicking the grid; 0 = none.</summary>
        private int selectedId;

        public Receptionist()
        {
            InitializeComponent();
        }

        private void Receptionist_Load(object sender, EventArgs e)
        {
            Display();
        }

        public void Display(string? exactName = null)
        {
            Ui.Run(() => dataGridView1.DataSource = AppServices.Receptionists.Search(exactName));
        }

        public void Clear()
        {
            selectedId = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox4.PlaceholderText = "";
            comboBox1.Text = "";
        }

        private ReceptionistInput ReadForm() =>
            new(textBox1.Text, comboBox1.Text, textBox3.Text, textBox2.Text, textBox4.Text);

        private void searchbtn_Click(object sender, EventArgs e)
        {
            Display(textBox1.Text);
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (Ui.Run(() => AppServices.Receptionists.Add(ReadForm())))
            {
                Display();
                Clear();
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (Ui.Run(() => AppServices.Receptionists.Update(selectedId, ReadForm())))
            {
                Display();
                Clear();
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedId <= 0)
            {
                MessageBox.Show("Please double-click a receptionist in the list first.");
                return;
            }
            if (!Ui.Confirm($"Delete receptionist '{textBox1.Text}'?{Environment.NewLine}" +
                            "Reservations they booked will be deleted too."))
                return;
            if (Ui.Run(() => AppServices.Receptionists.Delete(selectedId)))
            {
                Display();
                Clear();
            }
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (Ui.CurrentRowId(dataGridView1) is not int id)
                return;
            Ui.Run(() =>
            {
                var recp = AppServices.Receptionists.Get(id);
                if (recp == null)
                {
                    MessageBox.Show("This receptionist no longer exists.");
                    Display();
                    return;
                }
                selectedId = recp.Id;
                textBox1.Text = recp.Name;
                comboBox1.Text = recp.Gender;
                textBox3.Text = recp.Address;
                textBox2.Text = recp.Phone;
                textBox4.Text = "";
                textBox4.PlaceholderText = "unchanged if empty";
            });
        }

        // ---- navigation ----

        private void pictureBox1_Click(object sender, EventArgs e) => Ui.Navigate(this, new Home_Page());
        private void label6_Click(object sender, EventArgs e) => Ui.Navigate(this, new LoginPage());
        private void pictureBox6_Click(object sender, EventArgs e) => Ui.Navigate(this, new LoginPage());
        private void label2_Click(object sender, EventArgs e) => Ui.Navigate(this, new PatientPage());
        private void pictureBox2_Click(object sender, EventArgs e) => Ui.Navigate(this, new PatientPage());
        private void label4_Click(object sender, EventArgs e) => Ui.Navigate(this, new DoctorPage());
        private void pictureBox5_Click(object sender, EventArgs e) => Ui.Navigate(this, new DoctorPage());
        private void label1_Click(object sender, EventArgs e) => Ui.Navigate(this, new Receptionist());
        private void pictureBox3_Click(object sender, EventArgs e) => Ui.Navigate(this, new Receptionist());

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
