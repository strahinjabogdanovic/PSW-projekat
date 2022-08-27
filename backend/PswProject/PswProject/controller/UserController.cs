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
        public UserService userService;
        public DoctorService doctorService;
        private readonly MyDbContext dbContext;

        public UserController(MyDbContext context) 
        {
            dbContext = context;
            userService = new UserService(new UserSqlRepository(context));
            doctorService = new DoctorService(new DoctorSqlRepository(context));
        }

        [HttpPost("/registration")]
        public IActionResult Post(RegistrationDTO registrationDTO)
        {
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
        }

        [HttpPost("/login")]
        public IActionResult Login(UserDTO userDTO)
        {
            User user = userService.FindByUsernameAndPassword(userDTO.Username, userDTO.Password);

            foreach (User u in dbContext.Users)
            {
                if (userDTO.Password == u.Password)
                {
                    if (user != null)
                    {
                        String jwtToken = userService.GenerateJwtToken(user);
                        Console.WriteLine(user);
                        return Ok(jwtToken);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
            }
            return Unauthorized();
        }

    }
}
