using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PswProject;
using PswProject.model;
using PswProject.repository;
using PswProject.service;
using PswProject.dto;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PswProject.controller
{
    [Route("[controller]")]
    [ApiController]
    public class RecommendedAppointmentController : ControllerBase
    {
        private readonly MyDbContext context;
        public AppointmentService appointmentService;

        public RecommendedAppointmentController(MyDbContext context)
        {
            this.context = context;
            appointmentService = new AppointmentService(new RecommendedAppointmentSqlRepository(context), new DoctorSqlRepository(context));
        }


        [HttpPost("/recommendedAppointment")]
        public IActionResult Post(SearchAppointmentsDTO searchAppointments)
        {
            List<Appointment> appointments = appointmentService.GetAvailableAppointment(searchAppointments).ToList();
            List<AvailableAppointmentsDTO> dto = AppointmentService.AvailableAppointmentsDTODoctor(appointments);

            return Ok(dto);
        }


        [HttpPost("schedule")]
        public IActionResult Schedule(ScheduleDTO scheduleDTO)
        {
            Appointment appointment = AppointmentService.ScheduleAppointmentDTOToAppointment(scheduleDTO.Start, scheduleDTO.Id, scheduleDTO.PatientId);
            appointmentService.Schedule(appointment);

            return Ok();
        }


    }
}