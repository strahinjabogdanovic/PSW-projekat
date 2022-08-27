using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.model
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdD { get; set; }
        public String NameAndSurname { get; set; }
        
        public Specialization Specialization { get; set; }

        public int SpecializationId { get; set; }

        public String Username { get; set; }
        public String Password { get; set; }
        public Doctor() { }

        public Doctor(String username, String password, Doctor d)
        {
            IdD = d.IdD;
            NameAndSurname = d.NameAndSurname;
            Specialization = d.Specialization;
            SpecializationId = d.SpecializationId;
            Username = username;
            Password = password;
        }

        public Doctor(int id, string name, int specializationId)
        {
            this.IdD = id;
            this.NameAndSurname = name;
            this.SpecializationId = specializationId;
        }

        public Doctor(int id, string name, int specializationId, string username, string password)
        {
            this.IdD = id;
            this.NameAndSurname = name;
            this.SpecializationId = specializationId;
            this.Username = username;
            this.Password = password;
        }
    }
}