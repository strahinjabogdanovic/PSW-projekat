using PswProject.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.model
{
    public class User
    {
        private int id;
        private String name;
        private String surname;
        private String username;
        private String password;
        private String phone;
        private String jmbg;
        private Role role;
        private String address;
        private Gender gender;
        private Boolean blocked;

        public User(RegistrationDTO registrationDTO) 
        {
            this.username = registrationDTO.getUsername();
            this.password = registrationDTO.getPassword();
        }

        public User(int id, string name, string surname, string username, string password, string phone, string jmbg, Role role, string address, Gender gender, bool blocked)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.username = username;
            this.password = password;
            this.phone = phone;
            this.jmbg = jmbg;
            this.role = role;
            this.address = address;
            this.gender = gender;
            this.blocked = blocked;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

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

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getSurname()
        {
            return surname;
        }

        public void setSurname(String surname)
        {
            this.surname = surname;
        }

        public Role getRole()
        {
            return role;
        }

        public void setRole(Role role)
        {
            this.role = role;
        }

        public String getPhone()
        {
            return phone;
        }

        public void setPhone(String phone)
        {
            this.phone = phone;
        }

        public Gender getGender()
        {
            return gender;
        }

        public void setGender(Gender gender)
        {
            this.gender = gender;
        }

        public Boolean getBlocked()
        {
            return blocked;
        }

        public void setBlocked(Boolean blocked)
        {
            this.blocked = blocked;
        }

    }
}
