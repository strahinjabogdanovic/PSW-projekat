using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.repository
{
    public interface AppointmentRepository : IGenericRepository<Appointment, int>
    {
        public List<Appointment> Get(int doctorId, DateTime date);
        public void Create(Appointment appointment);
        public Appointment GetByAppointmentId(int appointmentId);
    
    }
}