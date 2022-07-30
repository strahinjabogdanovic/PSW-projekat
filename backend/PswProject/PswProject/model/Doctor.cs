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

        public Doctor() { }

        public Doctor(int id, string name, string surname, Specialization specialization)
        {
            this.IdD = id;
            this.NameAndSurname = name;
            this.Specialization = specialization;
        }
    }
}