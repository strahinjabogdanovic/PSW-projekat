using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.dto
{
    public class AppointmentDTO
    {
        public String StartTime { get; set; }
        public String PatientId { get; set; }
        public String DoctorId { get; set; }

        public AppointmentDTO() { }
    }
}