using PswProject.dto;
using PswProject.model;
using PswProject.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.service
{
    public class ObserveAppointmentsService
    {
        private MyDbContext dbContext { get; set; }
        private ObserveAppointmentsSqlRepository ObserveAppointmentsSqlRepository;
        private AppointmentRepository AppointmentRepository { get; set; }
        private Appointment Appointment = new Appointment();

        public ObserveAppointmentsService(ObserveAppointmentsSqlRepository observeAppointmentsSqlRepository)
        {
            this.ObserveAppointmentsSqlRepository = observeAppointmentsSqlRepository;
            AppointmentRepository = observeAppointmentsSqlRepository;
        }

        public ObserveAppointmentsService(AppointmentRepository iAppointmentRepository)
        {
            AppointmentRepository = iAppointmentRepository;
        }

        public List<Appointment> GetAppointmentsById(int id)
        {
            List<Appointment> appointments = ObserveAppointmentsSqlRepository.GetById(id);
            //return appointments;
            return Appointment.StatusAppointment(appointments);
        }
        public List<Appointment> GetDoctorsAppointmentsById(int id)
        {
            List<Appointment> appointments = ObserveAppointmentsSqlRepository.GetDoctorsApById(id);

            return Appointment.StatusAppointment(appointments);
        }

        public bool CancelAppointment(int appointmentId)
        {
            Appointment appointment = AppointmentRepository.GetByAppointmentId(appointmentId);
            ObserveAppointmentsSqlRepository.GetUserByApId(appointment);
            appointment.isCancelled = true;
            appointment.canCancel = false;
            appointment.Status = AppointmentStatus.CANCELLED;
            bool retVal = AppointmentRepository.Update(appointment);
            return retVal;
        }

        public bool SendRecipe(Recipe recipe)
        {
            Appointment a = ObserveAppointmentsSqlRepository.GetOne(recipe.IdR);
            bool retVal = ObserveAppointmentsSqlRepository.Update(a);
            Console.WriteLine(a.Status);
            ObserveAppointmentsSqlRepository.AddRecipeToDB(recipe, a.RecipeId);
            return retVal;
        }
    }
}