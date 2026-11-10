using C_sharp_Project.YoussifMohamed.Model.Database;
using ClinicManagement.Core;
using ClinicManagement.Core.Services;

namespace C_sharp_Project
{
    /// <summary>
    /// Creates the services the forms use. Every service opens a new, short-lived ClinicDB per
    /// operation, so forms no longer keep a DbContext (and its stale tracked entities) alive.
    /// </summary>
    internal static class AppServices
    {
        private static readonly Func<ClinicDB> CreateDb = () => new ClinicDB();
        private static readonly IClock Clock = SystemClock.Instance;

        public static AuthService Auth => new(CreateDb);
        public static PatientService Patients => new(CreateDb);
        public static DoctorService Doctors => new(CreateDb);
        public static ReceptionistService Receptionists => new(CreateDb);
        public static ReservationService Reservations => new(CreateDb, Clock);
        public static VisitService Visits => new(CreateDb, Clock);
        public static DashboardService Dashboard => new(CreateDb, Clock);
    }
}
