using PswProject.model;
using PswProject.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.service
{
    public class DoctorService
    {
        private DoctorSqlRepository DoctorSqlRepository { get; set; }

        public DoctorService()
        {

        }

        public DoctorService(DoctorSqlRepository doctorSqlRepository)
        {
            DoctorSqlRepository = doctorSqlRepository;
        }

        public List<Doctor> GetGeneralDoctors()
        {
            return DoctorSqlRepository.GetAvalibleGeneralDoctors();
        }
        public string GetDoctorById(int id)
        {
            return DoctorSqlRepository.GetMameAndSurnameById(id);

        }

        public List<Doctor> GetAllDoctors()
        {
            return DoctorSqlRepository.GetAll();
        }
        public List<Doctor> GetDoctorsBySpeciality(int specialityId)
        {
            return DoctorSqlRepository.GetDoctorsBySpeciality(specialityId);
        }
    }
}
