using Microsoft.AspNetCore.Mvc;
using PswProject.repository;
using PswProject.service;

namespace PswProject.controller
{
    [Route("[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly MyDbContext context;
        public UserService userService;

        public PatientsController(MyDbContext context)
        {
            this.context = context;
            userService = new UserService(new UserSqlRepository(context));
        }

        [HttpGet("/findPatients")]
        public IActionResult GetAllPatients()
        {
            return Ok(userService.GetAllPatients());
        }
    }
}