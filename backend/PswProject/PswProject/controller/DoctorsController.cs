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
    public class DoctorsController : ControllerBase
    {
        private readonly MyDbContext context;
        public DoctorService doctorService;

        public DoctorsController(MyDbContext context)
        {
            this.context = context;
            doctorService = new DoctorService(new DoctorSqlRepository(context));
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Doctor> result = new List<Doctor>();
            result = doctorService.GetGeneralDoctors();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctorsBySpeciality(int id)
        {
            List<Doctor> result = new List<Doctor>();
            result = doctorService.GetDoctorsBySpeciality(id);
            return Ok(result);
        }

        [HttpGet("/findDoctors")]
        public IActionResult GetAllDoctors()
        {
            return Ok(doctorService.GetAllDoctors());
        }

    }
}
