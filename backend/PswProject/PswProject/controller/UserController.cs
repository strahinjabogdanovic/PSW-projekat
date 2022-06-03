using Microsoft.AspNetCore.Mvc;
using PswProject.dto;
using PswProject.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService userService;

        public UserController(IUserService userService) 
        {
            this.userService = userService;
        }

        public Boolean registration(RegistrationDTO registrationDTO)
        {
            try
            {
                if (userService.registration(registrationDTO))
                    Console.WriteLine("Registration successfull");
                return true;
            }
            catch (Exception e) {
                Console.WriteLine("Error");
            }
            return false;
        }
    }
}
