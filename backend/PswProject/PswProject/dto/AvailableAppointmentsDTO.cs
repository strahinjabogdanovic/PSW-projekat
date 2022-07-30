using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.dto
{
    public class AvailableAppointmentsDTO
    {
        public DateTime Start { get; set; }
        public int DoctorId { get; set; }
        public AvailableAppointmentsDTO() { }
    }
}
