using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.dto
{
    public class SearchAppointmentsDTO
    {
        public DateTime StartInterval { get; set; }
        public DateTime EndInterval { get; set; }
        public int DoctorId { get; set; }
        public int Priority { get; set; }
        public int SpecializationId { get; set; }
        public SearchAppointmentsDTO() { }
    }
}
