using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.dto
{
    public class RegistrationDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Phone { get; set; }
        public String Jmbg { get; set; }
        public String Address { get; set; }
        public String Gender { get; set; }
        public Boolean Blocked { get; set; }

        public RegistrationDTO() { }

        public RegistrationDTO(int id, string name, string surname, string username, string password, string phone, string jmbg, string address, string gender, bool blocked)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Phone = phone;
            Jmbg = jmbg;
            Address = address;
            Gender = gender;
            Blocked = blocked;
        }
    }
}
