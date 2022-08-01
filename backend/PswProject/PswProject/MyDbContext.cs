using Microsoft.EntityFrameworkCore;
using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(mb =>
            {

                mb.HasData(
                new User(1, "Marko", "Markovic", "miki98", "miki985@", "0641664608", "3009998805138", Role.ADMIN,
                "Bulevar Oslobodjenja 8", Gender.MALE, false),
                new User(2, "Milica", "Mikic", "mici97", "mici789@", "0652459871", "3009998805137", Role.PATIENT,
                "Kisacka 5", Gender.FEMALE, false)
                );

                /*mb.OwnsOne(p => p.MedicalRecord).HasData(
                  new { PatientId = 1, HealthInsuranceNumber = "1ab", CompanyName = "WellCare" },
                  new { PatientId = 2, HealthInsuranceNumber = "2ab", CompanyName = "WellCare" });*/
            });

            modelBuilder.Entity<Doctor>(mb =>
            {
                mb.HasData(
                new Doctor(1, "Milan", "Popovic", Specialization.GENERAL),
                new Doctor(2, "Milana", "Pilipovic", Specialization.CARDIOLOGIST)
                );

            });

            modelBuilder.Entity<Appointment>(mb =>
            { 
                mb.HasData(
                new Appointment(1, new DateTime(2021, 12, 07, 16, 30, 00), 30, "All good", 1, 1, AppointmentStatus.UPCOMING, 123),
                new Appointment(2, new DateTime(2021, 12, 31, 16, 30, 00), 30, "", 1, 1, AppointmentStatus.UPCOMING, 124),
                new Appointment(3, new DateTime(2021, 12, 07, 14, 30, 00), 30, "All good", 2, 2, AppointmentStatus.UPCOMING, 125),
                new Appointment(4, new DateTime(2022, 01, 30, 14, 00, 00), 30, "All good", 1, 0, AppointmentStatus.UPCOMING, 126)
                );
            });

        }
    }
}
