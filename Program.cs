namespace C_sharp_Project
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Last line of defence: any exception a handler did not catch is shown instead of crashing the app.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (_, e) => Ui.ShowError(e.Exception);

            // First run: no admin account yet -> create one before anyone can log in.
            bool adminExists = false;
            if (!Ui.Run(() => adminExists = AppServices.Auth.AdminExists()))
                return;
            if (!adminExists)
            {
                using var setup = new AdminSetupForm();
                if (setup.ShowDialog() != DialogResult.OK)
                    return;
            }

            var login = new LoginPage();
            Ui.Track(login);
            login.Show();
            // No main form: the app ends when the last window is closed (or on Application.Exit).
            Application.Run(new ApplicationContext());
        }
    }
}
