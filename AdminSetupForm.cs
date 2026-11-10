using ClinicManagement.Core.Security;

namespace C_sharp_Project
{
    /// <summary>
    /// First-run setup: shown before the login screen while no admin account exists,
    /// so the application never ships with a default or known admin password.
    /// </summary>
    [System.ComponentModel.DesignerCategory("Code")] // built in code, no .Designer.cs / .resx
    internal sealed class AdminSetupForm : Form
    {
        private readonly TextBox _username = new() { Text = "Admin", Width = 260, MaxLength = 50 };
        private readonly TextBox _password = new() { Width = 260, UseSystemPasswordChar = true, MaxLength = PasswordPolicy.MaximumLength };
        private readonly TextBox _confirm = new() { Width = 260, UseSystemPasswordChar = true, MaxLength = PasswordPolicy.MaximumLength };

        public AdminSetupForm()
        {
            Text = "Clinic Management - first-run setup";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Padding = new Padding(16);

            var layout = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                WrapContents = false,
                Dock = DockStyle.Fill,
            };
            layout.Controls.Add(new Label
            {
                AutoSize = true,
                MaximumSize = new Size(300, 0),
                Text = "No admin account exists yet. Choose the admin user name and password. " +
                       $"The password needs at least {PasswordPolicy.AdminMinimumLength} characters, " +
                       "including a letter and a digit.",
                Margin = new Padding(0, 0, 0, 12),
            });
            layout.Controls.Add(new Label { AutoSize = true, Text = "Admin user name" });
            layout.Controls.Add(_username);
            layout.Controls.Add(new Label { AutoSize = true, Text = "Password" });
            layout.Controls.Add(_password);
            layout.Controls.Add(new Label { AutoSize = true, Text = "Confirm password" });
            layout.Controls.Add(_confirm);

            var create = new Button { Text = "Create admin", AutoSize = true };
            var cancel = new Button { Text = "Exit", AutoSize = true, DialogResult = DialogResult.Cancel };
            create.Click += Create_Click;
            var buttons = new FlowLayoutPanel { AutoSize = true, Margin = new Padding(0, 12, 0, 0) };
            buttons.Controls.Add(create);
            buttons.Controls.Add(cancel);
            layout.Controls.Add(buttons);

            Controls.Add(layout);
            AcceptButton = create;
            CancelButton = cancel;
        }

        private void Create_Click(object? sender, EventArgs e)
        {
            bool created = Ui.Run(() => AppServices.Auth.CreateInitialAdmin(_username.Text, _password.Text, _confirm.Text));
            if (!created)
                return;
            _password.Clear();
            _confirm.Clear();
            MessageBox.Show("Admin account created. You can now log in with the Admin role.",
                "Setup complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
