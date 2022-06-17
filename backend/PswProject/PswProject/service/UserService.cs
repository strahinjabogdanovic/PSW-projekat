using PswProject.dto;
using PswProject.model;
using PswProject.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace PswProject.service
{
    public class UserService
    {
        private UserRepository userRepository { get; set; }
        private UserSqlRepository userSqlRepositorys { get; set; }

        public UserService() { }

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserService(UserSqlRepository userSqlRepository)
        {
            userSqlRepositorys = userSqlRepository;
        }

        public Boolean registration(RegistrationDTO registrationDTO) 
        {
            User user = new User(registrationDTO);
            user.Role = Role.PATIENT;
            userSqlRepositorys.Add(user);

            return true;
	    }

        public User FindByUsernameAndPassword(String username, String password)
        {
            return userSqlRepositorys.FindByUsernameAndPassword(username, password);
        }

        public String GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            if (user.Role.Equals(Role.PATIENT))
                return GenerateJwtTokenPatient(tokenHandler, user);
            else
                return "Ok";

        }

        private string GenerateJwtTokenPatient(JwtSecurityTokenHandler tokenHandler, User user)
        {
            IdentityOptions options = new IdentityOptions();
            SecurityTokenDescriptor tokenDeskriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Role", "PATIENT"),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("QKcOa8xPopVOliV6tpvuWmoKn4MOydSeIzUt4W4r1UlU2De7dTUYMlrgv3rU")), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDeskriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
