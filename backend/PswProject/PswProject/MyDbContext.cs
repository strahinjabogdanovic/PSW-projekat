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
        public DbSet<Survey> Survey { get; set; }
        public DbSet<AnsweredQuestion> AnsweredQuestion { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestion { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
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
            });

            modelBuilder.Entity<Doctor>(mb =>
            {
                mb.HasData(
                new Doctor(1, "Milan Popovic", 0),
                new Doctor(2, "Milana Pilipovic", 2)
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

            modelBuilder.Entity<SurveyQuestion>(mb =>
            {
                mb.HasData(
                new SurveyQuestion(1, "How satisfied are you with the work of your doctor?", 0, 0),
                new SurveyQuestion(2, "How satisfied were you with the time that your doctor spent with you?", 0, 0)
                );
            });

            modelBuilder.Entity<Comment>(mb =>
            {
                mb.HasData(
                new Comment(1, DateTime.Now, "Good!", "Mika Mikic", false, 3),
                new Comment(2, DateTime.Now, "I didn't like it.", "Anonymus", true, 5),
                new Comment(3, DateTime.Now, "Super service!", "Sara Saric", true, 4)
                );
            });


        }
    }
}
