using PswProject.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.service
{
    public interface IUserService
    {
        Boolean registration(RegistrationDTO registrationDTO);
    }
}
