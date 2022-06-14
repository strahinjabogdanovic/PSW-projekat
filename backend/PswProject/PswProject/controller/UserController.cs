using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PswProject.dto;
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
    public class UserController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public UserService userService;

        
        public UserController(MyDbContext context) 
        {
            dbContext = context;
            userService = new UserService(new UserSqlRepository(context));
            Console.WriteLine("ovdecont");
        }
        
        //[HttpPost]
       [HttpPost("/registration")]
       // [EnableCors("AllowOrigin")]
       //public IActionResult registration([FromBody] RegistrationDTO registrationDTO)
        public IActionResult Post(RegistrationDTO registrationDTO)
        {
            Console.WriteLine("ovdereg");
            try
             {
                 if (userService.registration(registrationDTO))
                 {
                     Console.WriteLine("Registration successfull");
                 }
             }
             catch (Exception e) {
                 Console.WriteLine("Error");
             }
             return Ok(true);
            /*Console.WriteLine("ovde1");
            User user = GenerateUserFromDTO(registrationDTO);
            UserSqlRepository.Add(user, dbContext);
            Console.WriteLine(user);
            return Ok();*/
        }


    }
}
