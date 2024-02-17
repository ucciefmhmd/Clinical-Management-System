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
            optionsBuilder.UseSqlServer("Server=DESKTOP-7DE5S9C\\SQLEXPRESS;Database=DBClinicalManagement;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True");
        }
 
    }

}
