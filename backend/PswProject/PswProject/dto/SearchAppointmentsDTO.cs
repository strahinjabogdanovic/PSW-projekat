﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.dto
{
    public class SearchAppointmentsDTO
    {
        public String StartInterval { get; set; }
        public String EndInterval { get; set; }
        public int DoctorId { get; set; }
        public int Priority { get; set; }
        public int SpecializationId { get; set; }
        public SearchAppointmentsDTO() { }
    }
}
