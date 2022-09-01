using PswProject.dto;
using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.repository
{
    public class AppointmentSqlRepository : AppointmentRepository
    {
        public MyDbContext dbContext { get; set; }
        public AppointmentSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public AppointmentSqlRepository()
        {
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAll()
        {
            return dbContext.Appointments.ToList();
        }

        public Appointment GetOne(int id)
        {
            Console.WriteLine("ofdg");
            Appointment a = dbContext.Appointments.Where(f => f.IdA == id).FirstOrDefault();
            a.RecipeId = GetAll().Count + 1;
            return a;
        }

        public void AddRecipeToDB(Recipe r, int IdA)
        {
            List<Recipe> recipes = dbContext.Recipes.ToList();
            foreach(Recipe rr in recipes)
            {
                rr.Medicine = r.Medicine;
                rr.Quantity = r.Quantity;
                rr.Instructions = r.Instructions;
                rr.IdR = IdA;
                dbContext.Recipes.Add(rr);
            }
            dbContext.SaveChanges();
        }

        public bool Save(Appointment appointment)
        {
            var ret = dbContext.Appointments.Add(appointment);
            dbContext.SaveChanges();
            if (ret == null)
                return false;
            return true;
        }

        public bool Update(Appointment editedObject)
        {
            dbContext.Appointments.Update(editedObject);
            dbContext.SaveChanges();
            return true;
        }
        //popraviti
        public List<Appointment> GetOccupiedAppointmentsByDoctorAndDate(int idDoctor, DateTime chosenDate)
        {
            Console.WriteLine("ovde");
            List<Appointment> newList = new List<Appointment>();
            List<Appointment> n2 = new List<Appointment>();
            try
            {
                newList = dbContext.Appointments.ToList().Where(s => s.StartTime.Date == chosenDate.Date)
                    .Where(s => s.DoctorId == idDoctor).ToList();
            }
            catch (Exception e)
            {

            }
            return n2;
        }

        public List<Appointment> Get(int doctorId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Create(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Appointment GetByAppointmentId(int appointmentId)
        {
            throw new NotImplementedException();
        }


    }
}
