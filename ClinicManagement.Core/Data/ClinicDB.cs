using C_sharp_Project.YoussifMohamed.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace C_sharp_Project.YoussifMohamed.Model.Database
{
    public class ClinicDB : DbContext
    {
        public const string ConnectionStringVariable = "CLINIC_DB_CONNECTION";
        public const string DefaultConnectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=DBClinicalManagement;Trusted_Connection=True;TrustServerCertificate=True";

        /// <summary>Uses SQL Server with the connection string from <see cref="ConnectionStringVariable"/> (LocalDB by default).</summary>
        public ClinicDB()
        {
        }

        /// <summary>Used by tests (SQLite) or any caller that configures the provider itself.</summary>
        public ClinicDB(DbContextOptions<ClinicDB> options) : base(options)
        {
        }

        public DbSet<Patient> Patient { get; set; } = null!;
        public DbSet<Doctor> Doctor { get; set; } = null!;
        public DbSet<Reciptionist> Reciptionist { get; set; } = null!;
        public DbSet<Doctorspatient> Doctorspatient { get; set; } = null!;
        public DbSet<ReciptionAddPatientDoc> ReciptionAddPatientDoc { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            // Override with the CLINIC_DB_CONNECTION environment variable; defaults to SQL Server LocalDB.
            var connectionString = Environment.GetEnvironmentVariable(ConnectionStringVariable)
                ?? DefaultConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
