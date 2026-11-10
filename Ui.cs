using ClinicManagement.Core;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace C_sharp_Project
{
    /// <summary>Small helpers shared by the forms: error handling, confirmation, navigation.</summary>
    internal static class Ui
    {
        /// <summary>Runs a UI action and turns any failure into a user-friendly message instead of a crash.</summary>
        /// <returns>true if the action completed.</returns>
        public static bool Run(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return false;
            }
        }

        public static void ShowError(Exception ex)
        {
            switch (ex)
            {
                case ClinicValidationException:
                    MessageBox.Show(ex.Message, "Please check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                case DbUpdateException:
                    MessageBox.Show(
                        "The change could not be saved to the database. No data was changed." +
                        Environment.NewLine + Environment.NewLine + "Details: " + ex.GetBaseException().Message,
                        "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            if (ex.GetBaseException() is SqlException || ex is InvalidOperationException { InnerException: SqlException })
            {
                MessageBox.Show(
                    "The database could not be reached or returned an error." + Environment.NewLine +
                    "Check the CLINIC_DB_CONNECTION setting and that the schema was created with " +
                    "'dotnet ef database update' (see README)." +
                    Environment.NewLine + Environment.NewLine + "Details: " + ex.GetBaseException().Message,
                    "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(
                "Something went wrong: " + ex.GetBaseException().Message,
                "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirm(string question) =>
            MessageBox.Show(question, "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;

        /// <summary>Opens <paramref name="next"/> and closes <paramref name="current"/> (previously forms were only
        /// hidden and piled up for the lifetime of the app).</summary>
        public static void Navigate(Form current, Form next)
        {
            Track(next);
            next.Show();
            current.Close();
        }

        private static readonly HashSet<Form> OpenWindows = new();

        /// <summary>Ends the application when the last tracked window is closed.</summary>
        public static void Track(Form form)
        {
            if (!OpenWindows.Add(form))
                return;
            form.FormClosed += (_, _) =>
            {
                OpenWindows.Remove(form);
                if (OpenWindows.Count == 0)
                    Application.ExitThread();
            };
        }

        /// <summary>The selected value of a data-bound combo box, or null when nothing is selected.</summary>
        public static int? SelectedId(ComboBox box) =>
            box.SelectedIndex >= 0 && box.SelectedValue is int id ? id : null;

        /// <summary>The Id of the grid's current row, or null when there is none.</summary>
        public static int? CurrentRowId(DataGridView grid, string column = "Id")
        {
            var row = grid.CurrentRow;
            if (row == null || row.Index < 0 || !grid.Columns.Contains(column))
                return null;
            return row.Cells[column].Value is int id ? id : null;
        }
    }
}
