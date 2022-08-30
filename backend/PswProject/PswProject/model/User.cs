using PswProject.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Phone { get; set; }
        public String Jmbg { get; set; }
        public Role Role { get; set; }
        public String Address { get; set; }
        public Gender Gender { get; set; }
        public Boolean Blocked { get; set; }
        public int NumOfC { get; set; }

        public User() { }

        public User(String username, String password, User p)
        {
            Id = p.Id;
            Name = p.Name;
            Surname = p.Surname;
            Username = username;
            Password = password;
            Phone = p.Phone;
            Jmbg = p.Jmbg;
            Role = p.Role;
            Address = p.Address;
            Gender = p.Gender;
            Blocked = p.Blocked;
        }

        public User(RegistrationDTO registrationDTO) 
        {
            Name = registrationDTO.Name;
            Surname = registrationDTO.Surname;
            Username = registrationDTO.Username;
            Password = registrationDTO.Password;
            Phone = registrationDTO.Phone;
            Jmbg = registrationDTO.Jmbg;
            Address = registrationDTO.Address;
            if (registrationDTO.Gender.ToLower().Equals(Gender.MALE.ToString().ToLower()))
            {
                Gender = Gender.MALE;
            }
            else 
            {
                Gender = Gender.FEMALE;
            }
            Blocked = registrationDTO.Blocked;
        }

        public User(int id, string name, string surname, string username, string password, string phone, string jmbg, Role role, string address, Gender gender, bool blocked)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Phone = phone;
            Jmbg = jmbg;
            Role = role;
            Address = address;
            Gender = gender;
            Blocked = blocked;
        }

        public User(int id, string name, string surname, string username, string password, string phone, string jmbg, string address, Gender gender, bool blocked)
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
