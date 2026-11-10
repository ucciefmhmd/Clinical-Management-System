using C_sharp_Project.YoussifMohamed.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Project.YoussifMohamed.Model.Database
{
    public class ClinicDB : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Reciptionist> Reciptionist { get; set; }
        public DbSet<Doctorspatient> Doctorspatient { get; set; }
        public DbSet<ReciptionAddPatientDoc> ReciptionAddPatientDoc { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Override with the CLINIC_DB_CONNECTION environment variable; defaults to SQL Server LocalDB.
            var connectionString = Environment.GetEnvironmentVariable("CLINIC_DB_CONNECTION")
                ?? "Server=(localdb)\\MSSQLLocalDB;Database=DBClinicalManagement;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
 
    }

}
