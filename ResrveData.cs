using ClinicManagement.Core.Services;

namespace C_sharp_Project.RofidaMohamed
{
    /// <summary>Add / edit dialog for one reservation. Returns DialogResult.OK when something was saved.</summary>
    public partial class ResrveData : Form
    {
        private bool isDragging = false;
        private Point lastCursorPosition;
        private readonly int receptionistId;
        /// <summary>Reservation being edited; 0 = adding a new one.</summary>
        private readonly int reservationId;

        public ResrveData(int respId)
        {
            InitializeComponent();
            receptionistId = respId;
            //to moveable
            this.MouseDown += MainForm_MouseDown;
            this.MouseMove += MainForm_MouseMove;
            this.MouseUp += MainForm_MouseUp;

            label1.Text = "Add New An Appointment";
            okbtn.Text = "Add";
        }

        public ResrveData(int respId, int reservationId) : this(respId)
        {
            this.reservationId = reservationId;
            label1.Text = "Edit this An Appointment";
            okbtn.Text = "Edit";
        }

        private bool IsEdit => reservationId > 0;

        private void MainForm_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPosition = new Point(e.X, e.Y);
            }
        }

        private void MainForm_MouseMove(object? sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newCursorPosition = new Point(e.X, e.Y);
                int deltaX = newCursorPosition.X - lastCursorPosition.X;
                int deltaY = newCursorPosition.Y - lastCursorPosition.Y;

                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void MainForm_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void load()
        {
            var service = AppServices.Reservations;

            PatientBox.DisplayMember = nameof(LookupItem.Name);
            PatientBox.ValueMember = nameof(LookupItem.Id);
            PatientBox.DataSource = service.GetPatientOptions();
            PatientBox.SelectedIndex = -1;

            drBox.DisplayMember = nameof(LookupItem.Name);
            drBox.ValueMember = nameof(LookupItem.Id);
            drBox.DataSource = service.GetDoctorOptions();
            drBox.SelectedIndex = -1;

            StateBox.DisplayMember = "Text";
            StateBox.ValueMember = "Value";
            StateBox.DataSource = new[]
            {
                new { Text = "Waiting", Value = false },
                new { Text = "Done", Value = true },
            };

            if (IsEdit)
            {
                var reservation = service.Get(reservationId);
                if (reservation == null)
                {
                    MessageBox.Show("This reservation no longer exists.");
                    DialogResult = DialogResult.OK; // let the list refresh
                    Close();
                    return;
                }
                PatientBox.SelectedValue = reservation.PatientID;
                drBox.SelectedValue = reservation.DoctorID;
                if (reservation.Appointment < dtp1.MinDate)
                    dtp1.MinDate = reservation.Appointment;
                dtp1.Value = reservation.Appointment;
                priceTextBox.Text = reservation.Price.ToString();
                StateBox.SelectedValue = reservation.State;
            }
            else
            {
                dtp1.MinDate = DateTime.Now;
                StateBox.Enabled = false;
            }
        }

        private void okbtn_Click(object sender, EventArgs e)
        {
            var input = new ReservationInput(
                Ui.SelectedId(PatientBox),
                Ui.SelectedId(drBox),
                dtp1.Value,
                priceTextBox.Text,
                Done: StateBox.SelectedValue is true);

            bool saved = Ui.Run(() =>
            {
                if (IsEdit)
                    AppServices.Reservations.Update(reservationId, receptionistId, input);
                else
                    AppServices.Reservations.Add(receptionistId, input);
            });
            if (saved)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ResrveData_Load(object sender, EventArgs e)
        {
            if (!Ui.Run(load))
                Close();
        }
    }
}
