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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
