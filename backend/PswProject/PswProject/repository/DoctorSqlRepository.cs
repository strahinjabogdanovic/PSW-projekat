using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.repository
{
    public class DoctorSqlRepository : DoctorRepository
    {
        public MyDbContext dbContext { get; set; }

        public DoctorSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public DoctorSqlRepository()
        {
        }

        public List<Doctor> GetDoctorsWithSpeciality(Specialization speciality)
        {
            throw new System.NotImplementedException();
        }

        public Doctor GetDoctorBy(int id)
        {
            return dbContext.Doctors.Where(d => d.IdD == id).FirstOrDefault();
        }

        public List<Doctor> GetDoctorsBySpeciality(int specialityId)
        {
            //return (from n in dbContext.Doctors where n.SpecialityId == specialityId select n).ToList();
            return (from n in dbContext.Doctors where n.IdD == specialityId select n).ToList();
        }

        public List<Doctor> GetAll()
        {
            foreach(Doctor d in dbContext.Doctors)
            {
                Console.WriteLine(d);
            }
             return dbContext.Doctors.ToList();
        }

        public Doctor GetOne(int id)
        {
            throw new System.NotImplementedException();
        }
        //kod nas u modelu su ime i prezime zasebno
        public string GetMameAndSurnameById(int id)
        {
            return (from n in dbContext.Doctors where n.IdD == id select n.NameAndSurname).FirstOrDefault();
        }

        public bool Save(Doctor newObject)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Doctor editedObject)
        {
            throw new System.NotImplementedException();
        }

        public List<Doctor> GetAvalibleGeneralDoctors()
        {
            /*var d = dbContext.Doctors.OrderBy(p => p.NumberOfPatients).FirstOrDefault();
            List<Doctor> retVal = (List<Doctor>)dbContext.Doctors.ToList().Where(s => s.Specialization.Equals("GENERAL")).Where(s => s.NumberOfPatients <= d.NumberOfPatients + 2).ToList();
            */
            List<Doctor> retVal = (List<Doctor>)dbContext.Doctors.ToList().Where(s => s.Specialization.Equals("GENERAL"));
            return retVal;
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }



    }
}
