using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.repository
{
    public interface DoctorRepository : IGenericRepository<Doctor, int>
    { 
        List<Doctor> GetDoctorsWithSpeciality(Specialization specialization);
        List<Doctor> GetDoctorsBySpeciality(int specialityId);
        public Doctor GetDoctorBy(int id);
        public Doctor FindDoctorsByUsernameAndPassword(String username, String password);
    }
}
