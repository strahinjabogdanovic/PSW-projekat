using PswProject.dto;
using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.repository
{
    public class ObserveAppointmentsSqlRepository : AppointmentRepository
    {
        private MyDbContext context;

        public ObserveAppointmentsSqlRepository(MyDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAll()
        {
            return context.Appointments.ToList();
        }

        public List<Appointment> GetById(int id)
        {   
            return context.Appointments.Where(s => s.UserId == id).ToList();
        }
        
        public List<Appointment> GetDoctorsApById(int id)
        {
            return context.Appointments.Where(s => s.DoctorId == id).ToList();
        }

        public Appointment GetOne(int id)
        {
            Console.WriteLine("ovde2");
            Appointment a = context.Appointments.Where(f => f.IdA == id).FirstOrDefault();
            a.RecipeId = context.Recipes.Count() + 1;
            a.Status = AppointmentStatus.DONE;
            context.SaveChanges();
            return a;
        }

        public void AddRecipeToDB(Recipe r, int IdA)
        {
            Console.WriteLine("ovde4");
            Recipe newR = new Recipe(IdA, r.Medicine, r.Quantity, r.Instructions);
            context.Recipes.Add(newR);
            context.SaveChanges();
        }

        public bool Save(Appointment newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(Appointment editedObject)
        {
            Console.WriteLine("ovde3");
            context.Appointments.Update(editedObject);
            context.SaveChanges();
            return true;
        }

        public Appointment GetByAppointmentId(int appointmentId)
        {
            return context.Appointments.Find(appointmentId);
        }

        public List<Appointment> Get(int doctorId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Create(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public void GetUserByApId(Appointment appointment)
        {
            User u = context.Users.Where(f => f.Id == appointment.UserId).FirstOrDefault();
            u.NumOfC = u.NumOfC + 1;
            context.SaveChanges();
        }
    }
}