using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.dto
{
    public class ScheduleDTO
    {
            public DateTime Start { get; set; }
            public int Id { get; set; }
            public int PatientId { get; set; }
            public ScheduleDTO() { }
    }
}
