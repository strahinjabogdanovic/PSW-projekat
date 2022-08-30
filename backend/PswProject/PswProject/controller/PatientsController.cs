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
        [HttpPost("/block")]
        public IActionResult BlockUser([FromBody] int IdU)
        {
            userService.BlockUser(IdU);
            return Ok();
        }

        [HttpPost("/unblock")]
        public IActionResult UnblockUser([FromBody] int IdU)
        {
            userService.UnblockUser(IdU);
            return Ok();
        }

    }
}