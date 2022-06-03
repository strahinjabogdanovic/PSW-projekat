using PswProject.dto;
using PswProject.model;
using PswProject.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.service
{
    public class UserService: IUserService
    {
        private UserRepository userRepository;

        public Boolean registration(RegistrationDTO registrationDTO) 
        {
            User user = new User(registrationDTO);
        
            user.setRole(Role.PATIENT);
            userRepository.save(user);

            return true;
	    }
    }
}
