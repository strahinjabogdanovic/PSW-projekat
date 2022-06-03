using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.dto
{
    public class RegistrationDTO
    {
        private String name;
        private String surname;
        private String username;
        private String password;
        private String repeatPassword;
        private String phone;
        private String jmbg;
        private String address;
        private Gender gender;

        public RegistrationDTO() { }

        public String getUsername()
        {
            return username;
        }

        public void setUsername(String username)
        {
            this.username = username;
        }
        public String getPassword()
        {
            return password;
        }

        public void setPassword(String password)
        {
            this.password = password;
        }

        public String Name { get => name; set => name = value; }
        public String Surname { get => surname; set => surname = value; }
        public String Phone { get => phone; set => phone = value; }
        public String Jmbg { get => jmbg; set => jmbg = value; }
        public String Address { get => address; set => address = value; }
        public Gender Gender { get => gender; set => gender = value; }
    }
}
