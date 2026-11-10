using C_sharp_Project.EmanMetwallyElgharabawy;
using C_sharp_Project.RofidaMohamed;
using ClinicManagement.Core.Services;

namespace C_sharp_Project
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            // Role combo order: Admin, Doctor, Receptionist (same as UserRole).
            if (Role.SelectedIndex < 0 || !Enum.IsDefined(typeof(UserRole), Role.SelectedIndex))
            {
                MessageBox.Show("Please Select Your Position");
                return;
            }

            var role = (UserRole)Role.SelectedIndex;
            LoginResult? result = null;
            if (!Ui.Run(() => result = AppServices.Auth.Login(role, txtUsername.Text, txtPassword.Text)) || result == null)
                return;

            txtPassword.Clear();
            if (!result.Succeeded)
            {
                MessageBox.Show(result.Error);
                return;
            }

            Form next = result.Role switch
            {
                // The admin home page links to the patient, doctor and receptionist pages.
                UserRole.Admin => new Home_Page(),
                UserRole.Doctor => new drDash(result.UserId),
                _ => new PatientPage(result.UserId),
            };
            Ui.Navigate(this, next);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Role.SelectedIndex = -1;
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
