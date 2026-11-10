using C_sharp_Project.YoussifMohamed.Model.Entity;
using ClinicManagement.Core;
using ClinicManagement.Core.Security;
using ClinicManagement.Core.Services;

namespace ClinicManagement.Tests
{
    public class ClinicServiceTests : IDisposable
    {
        private readonly TestDatabase _db = new();
        private readonly PatientService _patients;
        private readonly DoctorService _doctors;
        private readonly ReceptionistService _receptionists;
        private readonly ReservationService _reservations;
        private readonly DashboardService _dashboard;
        private readonly VisitService _visits;

        public ClinicServiceTests()
        {
            _patients = new PatientService(_db.Create);
            _doctors = new DoctorService(_db.Create, TestDatabase.FastHasher);
            _receptionists = new ReceptionistService(_db.Create, TestDatabase.FastHasher);
            _reservations = new ReservationService(_db.Create, _db.Clock);
            _dashboard = new DashboardService(_db.Create, _db.Clock);
            _visits = new VisitService(_db.Create, _db.Clock);
        }

        public void Dispose() => _db.Dispose();

        private DateTime Today(int hour, int minute = 0) => _db.Clock.Now.Date.AddHours(hour).AddMinutes(minute);

        private int AddPatient(string name = "Patient One") =>
            _patients.Add(new PatientInput(name, "Cairo", "0100", "Male", new DateTime(1990, 5, 1)));

        private int AddDoctor(string name = "Dr Sara", string password = "doc12") =>
            _doctors.Add(new DoctorInput(name, "Female", "Cardiology", "10 years", "Giza", "0111", new DateTime(1980, 1, 1), password));

        private int AddReceptionist(string name = "Mona") =>
            _receptionists.Add(new ReceptionistInput(name, "Female", "Cairo", "0122", "desk1"));

        private int Book(int recep, int patient, int doctor, DateTime when, string price = "200") =>
            _reservations.Add(recep, new ReservationInput(patient, doctor, when, price));

        // ---------- add-twice regression (PatientPage / Receptionist reused one entity) ----------

        [Fact]
        public void Adding_twice_creates_two_rows_for_patients_and_receptionists()
        {
            int first = AddPatient("Ahmed");
            int second = AddPatient("Laila");
            int r1 = AddReceptionist("Mona");
            int r2 = AddReceptionist("Hana");

            Assert.NotEqual(first, second);
            Assert.Equal(2, _patients.Search().Count);
            Assert.NotEqual(r1, r2);
            Assert.Equal(2, _receptionists.Search().Count);
        }

        [Fact]
        public void Adding_after_updating_a_selected_patient_inserts_a_new_row()
        {
            int id = AddPatient("Ahmed");
            _patients.Update(id, new PatientInput("Ahmed Ali", "Alex", "0100", "Male", new DateTime(1990, 5, 1)));

            AddPatient("Laila");

            var all = _patients.Search();
            Assert.Equal(2, all.Count);
            Assert.Equal("Ahmed Ali", all.Single(p => p.Id == id).Name);
        }

        // ---------- update / delete with no selection ----------

        [Fact]
        public void Update_or_delete_without_a_selection_gives_a_friendly_error()
        {
            var patient = new PatientInput("Ahmed", "Cairo", "0100", "Male", DateTime.Today);
            Assert.Throws<ClinicValidationException>(() => _patients.Update(0, patient));
            Assert.Throws<ClinicValidationException>(() => _patients.Delete(0));
            Assert.Throws<ClinicValidationException>(() => _doctors.Delete(0));
            Assert.Throws<ClinicValidationException>(() => _receptionists.Delete(0));
            Assert.Throws<ClinicValidationException>(() => _patients.Delete(999));
        }

        [Fact]
        public void Patient_rules_from_the_entity_are_enforced()
        {
            var ex = Assert.Throws<ClinicValidationException>(() =>
                _patients.Add(new PatientInput("Al", "Cairo", "0100", "Male", DateTime.Today)));
            Assert.Contains("between 3 to 15", ex.Message);
            Assert.Throws<ClinicValidationException>(() =>
                _patients.Add(new PatientInput("Ahmed", "", "0100", "Male", DateTime.Today)));
        }

        // ---------- doctor update keeps fields and password ----------

        [Fact]
        public void Doctor_password_is_hashed_and_update_with_blank_password_keeps_it()
        {
            int id = AddDoctor(password: "doc12");
            string hash;
            using (var db = _db.Create())
                hash = db.Doctor.Single().password;
            Assert.True(PasswordHasher.IsHashed(hash));

            _doctors.Update(id, new DoctorInput("Dr Sara", "Female", "Neurology", "12 years", "Giza", "0111", new DateTime(1981, 2, 2), Password: ""));

            using (var db = _db.Create())
            {
                var d = db.Doctor.Single();
                Assert.Equal(hash, d.password);
                Assert.Equal("Neurology", d.Specialization);
                Assert.Equal("12 years", d.Experience);
                Assert.Equal(new DateTime(1981, 2, 2), d.DOB);
            }
            var row = _doctors.Get(id)!;
            Assert.Equal("Neurology", row.Specialization);
            Assert.Equal(id, row.Id);
        }

        [Fact]
        public void Staff_password_must_meet_minimum_length_when_adding()
        {
            Assert.Throws<ClinicValidationException>(() => AddDoctor(password: "abc"));
            Assert.Throws<ClinicValidationException>(() =>
                _receptionists.Add(new ReceptionistInput("Mona", "F", "Cairo", "0122", "")));
        }

        [Fact]
        public void Doctor_created_by_admin_can_log_in()
        {
            AddDoctor("Dr Ali", "secret1");
            var auth = new AuthService(_db.Create, TestDatabase.FastHasher);

            Assert.True(auth.Login(UserRole.Doctor, "Dr Ali", "secret1").Succeeded);
            Assert.False(auth.Login(UserRole.Doctor, "Dr Ali", "Secret1").Succeeded);
        }

        // ---------- dashboards ----------

        [Fact]
        public void Dashboard_with_zero_appointments_reports_zero_percent()
        {
            var stats = _dashboard.GetTodayStats();

            Assert.Equal(new DashboardStats(0, 0, 0), stats);
            Assert.Equal(0, stats.PercentDone);
            Assert.Equal(0, _dashboard.GetTodayStats(doctorId: 42).PercentDone);
        }

        [Fact]
        public void Dashboard_counts_only_today_and_per_doctor()
        {
            int recep = AddReceptionist();
            int p1 = AddPatient("Ahmed"), p2 = AddPatient("Laila"), p3 = AddPatient("Omar");
            int d1 = AddDoctor("Dr Sara"), d2 = AddDoctor("Dr Ali");
            Book(recep, p1, d1, Today(9));
            Book(recep, p2, d1, Today(15));
            Book(recep, p3, d2, Today(16));
            Book(recep, p1, d1, Today(9).AddDays(1)); // tomorrow: not counted
            Book(recep, p1, d1, Today(9).AddDays(-1)); // yesterday: not counted
            _visits.AddVisit(d1, p1, "Aspirin", "Headache");

            var all = _dashboard.GetTodayStats();
            Assert.Equal(new DashboardStats(3, 2, 1), all);
            Assert.Equal(33, all.PercentDone);

            var doctor1 = _dashboard.GetTodayStats(d1);
            Assert.Equal(new DashboardStats(2, 1, 1), doctor1);
            Assert.Equal(50, doctor1.PercentDone);

            var rows = _dashboard.GetTodayAppointments(d1);
            Assert.Equal(new[] { "Done", "Waiting" }, rows.Select(r => r.State));
            // Clock is 12:00, so a waiting 09:00 appointment would be "Missed".
            Assert.Single(_dashboard.GetTodayAppointments(field: ReservationSearchField.Doctor, text: "Dr A"));
            Assert.Single(_dashboard.GetTodayAppointments(field: ReservationSearchField.Patient, text: "Lai"));
        }

        [Fact]
        public void Home_counts_use_all_tables()
        {
            int recep = AddReceptionist();
            int p = AddPatient();
            AddPatient("Second");
            int d = AddDoctor();
            Book(recep, p, d, Today(18));

            Assert.Equal(new HomeCounts(2, 1, 1, 1), _dashboard.GetHomeCounts());
        }

        // ---------- reservations ----------

        [Fact]
        public void Reservation_without_selected_patient_or_doctor_is_rejected_before_saving()
        {
            int recep = AddReceptionist();
            int p = AddPatient();
            int d = AddDoctor();

            Assert.Throws<ClinicValidationException>(() => _reservations.Add(recep, new ReservationInput(null, d, Today(14), "100")));
            Assert.Throws<ClinicValidationException>(() => _reservations.Add(recep, new ReservationInput(p, null, Today(14), "100")));
            Assert.Throws<ClinicValidationException>(() => _reservations.Add(recep, new ReservationInput(p, d, Today(14), "abc")));
            Assert.Throws<ClinicValidationException>(() => _reservations.Add(recep, new ReservationInput(p, 999, Today(14), "100")));
            Assert.Empty(_reservations.Search());
        }

        [Fact]
        public void Reservation_status_depends_on_the_injected_clock()
        {
            int recep = AddReceptionist();
            int p = AddPatient();
            int d = AddDoctor();
            Book(recep, p, d, Today(14));

            Assert.Equal("Waiting", _reservations.Search().Single().State);
            _db.Clock.Now = Today(15);
            Assert.Equal("Missed", _reservations.Search().Single().State);
        }

        [Fact]
        public void Reservation_edit_and_delete_by_id()
        {
            int recep = AddReceptionist();
            int p = AddPatient("Ahmed"), p2 = AddPatient("Laila");
            int d = AddDoctor();
            int id = Book(recep, p, d, Today(14));

            _reservations.Update(id, recep, new ReservationInput(p2, d, Today(16), "350", Done: true));

            var row = _reservations.Search().Single();
            Assert.Equal("Laila", row.Patient);
            Assert.Equal("350 $", row.Price);
            Assert.Equal("Done", row.State);
            Assert.Single(_reservations.OnDate(_db.Clock.Now));
            Assert.Single(_reservations.Search(null, "Lai"));
            Assert.Empty(_reservations.Search(ReservationSearchField.Doctor, "Lai"));

            _reservations.Delete(id);
            Assert.Empty(_reservations.Search());
            Assert.Throws<ClinicValidationException>(() => _reservations.Delete(id));
        }

        // ---------- visits ----------

        [Fact]
        public void Adding_a_visit_marks_todays_reservation_done()
        {
            int recep = AddReceptionist();
            int p = AddPatient("Ahmed");
            int d = AddDoctor();
            int resId = Book(recep, p, d, Today(14));
            Assert.Single(_visits.GetWaitingPatientsToday(d));

            int visitId = _visits.AddVisit(d, p, "Paracetamol", "Fever");

            Assert.True(_reservations.Get(resId)!.State);
            Assert.Empty(_visits.GetWaitingPatientsToday(d));
            var visit = Assert.Single(_visits.GetTodayVisits(d));
            Assert.Equal(visitId, visit.ID);
            Assert.Equal("Ahmed", visit.Patient);
            Assert.Equal("Fever", visit.Diagnosis);
        }

        [Fact]
        public void Visit_requires_a_selected_patient_with_a_waiting_appointment_and_valid_text()
        {
            int recep = AddReceptionist();
            int p = AddPatient();
            int d = AddDoctor();

            Assert.Throws<ClinicValidationException>(() => _visits.AddVisit(d, null, "Paracetamol", "Fever"));
            Assert.Throws<ClinicValidationException>(() => _visits.AddVisit(d, p, "Paracetamol", "Fever")); // no reservation
            Book(recep, p, d, Today(14));
            Assert.Throws<ClinicValidationException>(() => _visits.AddVisit(d, p, "P", "Fever")); // too short
            using var db = _db.Create();
            Assert.Empty(db.Doctorspatient.ToList());
            Assert.False(db.ReciptionAddPatientDoc.Single().State);
        }

        [Fact]
        public void Editing_and_deleting_a_visit()
        {
            int recep = AddReceptionist();
            int p = AddPatient();
            int d = AddDoctor();
            int resId = Book(recep, p, d, Today(14));
            int visitId = _visits.AddVisit(d, p, "Paracetamol", "Fever");

            _visits.UpdateVisit(visitId, "Ibuprofen", "Flu");
            Assert.Equal("Ibuprofen", _visits.GetTodayVisits(d).Single().Medicine);
            Assert.Throws<ClinicValidationException>(() => _visits.UpdateVisit(0, "Ibuprofen", "Flu"));

            _visits.DeleteVisit(visitId);
            Assert.Empty(_visits.GetTodayVisits(d));
            Assert.False(_reservations.Get(resId)!.State);
            Assert.Single(_visits.GetWaitingPatientsToday(d));
        }

        [Fact]
        public void Deleting_a_patient_cascades_to_reservations_and_visits()
        {
            int recep = AddReceptionist();
            int p = AddPatient();
            int d = AddDoctor();
            Book(recep, p, d, Today(14));
            _visits.AddVisit(d, p, "Paracetamol", "Fever");

            _patients.Delete(p);

            using var db = _db.Create();
            Assert.Empty(db.ReciptionAddPatientDoc.ToList());
            Assert.Empty(db.Doctorspatient.ToList());
        }
    }
}
