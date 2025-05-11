using Microsoft.EntityFrameworkCore;
using SchoolVaccinationPortalAPI.Migrations;
using SchoolVaccinationPortalAPI.Models;
using System.Reflection.PortableExecutable;

namespace SchoolVaccinationPortalAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
       // private readonly string _defaultSchema;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) {

            //_defaultSchema = configuration["ConnectionStrings:DefaultSchema"];
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<VaccinationDrive> VaccinationDrives { get; set; }
        public DbSet<VaccinationRecord> VaccinationRecords { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vaccines> Vaccines { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set the default schema
            modelBuilder.HasDefaultSchema("vaccination_portal_db");
            base.OnModelCreating(modelBuilder);


        }

    }


}
