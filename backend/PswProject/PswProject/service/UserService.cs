using PswProject.dto;
using PswProject.model;
using PswProject.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace PswProject.service
{
    public class UserService
    {
        private UserRepository userRepository { get; set; }

        private UserSqlRepository userSqlRepositorys { get; set; }

        public UserService(UserSqlRepository userSqlRepository) {
            userSqlRepositorys = userSqlRepository;
        }
        public UserService() { }

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Boolean registration(RegistrationDTO registrationDTO) 
        {
            User user = new User(registrationDTO);
            
            user.Role = Role.PATIENT;
            userSqlRepositorys.Add(user);

            return true;
	    }

        /*private static User GenerateUserFromDTO(RegistrationDTO p)
        {
            Console.WriteLine("ovde1");
            User usern = new User(p.Id, p.Name, p.Surname, p.Username, p.Password, p.Phone, p.Jmbg, p.Address, p.Gender, p.Blocked);
            usern.Role = Role.PATIENT;
            Console.WriteLine(usern);
            return usern;
        }*/

    }
}
