using Microsoft.AspNetCore.Mvc;
using PswProject.model;
using PswProject.repository;
using PswProject.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.controller
{
    [Route("[controller]")]
    [ApiController]
    public class ObserveAppointmentsController : ControllerBase
    {
        private MyDbContext context;
        public ObserveAppointmentsService observeAppointmentsService;

        public ObserveAppointmentsController(MyDbContext context)
        {
            this.context = context;
            observeAppointmentsService = new ObserveAppointmentsService(new ObserveAppointmentsSqlRepository(context));
        }

        [HttpGet]
        //[HttpGet("/observeAppointments/{id}")]
        public IActionResult Get([FromQuery] int id)
        {
            //int idPatient = Int32.Parse(id);
            List<Appointment> appointments = observeAppointmentsService.GetAppointmentsById(id);
            return Ok(appointments);
        }
    }
}