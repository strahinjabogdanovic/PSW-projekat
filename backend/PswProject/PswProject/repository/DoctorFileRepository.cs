using Newtonsoft.Json;
using PswProject.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.repository
{
    public class DoctorFileRepository : DoctorRepository
    {
        public String FileName { get; set; }

        public DoctorFileRepository()
        {
            this.FileName = "../../doctors.json";
        }

        public List<Doctor> GetAll()
        {
            List<Doctor> storedDoctors = ReadFromFile();
            List<Doctor> doctors = new List<Doctor>();
            for (int i = 0; i < storedDoctors.Count; i++)
            {
                // if (storedDoctors[i].IsDeleted == false)
                doctors.Add(storedDoctors[i]);
            }
            return doctors;
        }

        

        public Doctor GetOne(int jmbg)
        {
            List<Doctor> doctors = GetAll();
            foreach (Doctor doctor in doctors)
            {
                if (doctor.IdD.Equals(jmbg))
                    return doctor;
            }
            return null;
        }


        private List<Doctor> ReadFromFile()
        {
            try
            {
                String jsonFromFile = File.ReadAllText(this.FileName);
                List<Doctor> doctors = JsonConvert.DeserializeObject<List<Doctor>>(jsonFromFile);
                return doctors;
            }
            catch { }
            return new List<Doctor>();
        }

        public Boolean Save(Doctor newDoctor)
        {
            List<Doctor> storedDoctors = ReadFromFile();

            foreach (Doctor doctor in storedDoctors)
            {
                if (doctor.IdD == newDoctor.IdD)
                    return false;
            }
            storedDoctors.Add(newDoctor);

            WriteToFile(storedDoctors);
            return true;
        }

        public Boolean Delete(int jmbg)
        {
            List<Doctor> storedDoctors = ReadFromFile();
            foreach (Doctor doctor in storedDoctors)
            {
                if (doctor.IdD == jmbg)
                {

                    WriteToFile(storedDoctors);
                    return true;

                }
            }
            return false;
        }

        private void WriteToFile(List<Doctor> doctors)
        {
            try
            {
                var jsonToFile = JsonConvert.SerializeObject(doctors, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(this.FileName))
                {
                    writer.Write(jsonToFile);
                }
            }
            catch
            {
            }
        }



        public List<Doctor> GetDoctorsWithSpeciality(Specialization speciality)
        {
            List<Doctor> doctors = GetAll();
            List<Doctor> doctorsWithSpeciality = new List<Doctor>();
            foreach (Doctor d in doctors)
            {
                if (!d.Specialization.Equals("GENERAL"))
                    doctorsWithSpeciality.Add(d);
            }
            return doctorsWithSpeciality;
        }

        public List<Doctor> GetDoctorsBySpeciality(int specialityId)
        {
            List<Doctor> doctors = GetAll();
            List<Doctor> doctorsWithSpeciality = new List<Doctor>();
            foreach (Doctor d in doctors)
            {
                //?!?
                if (d.Specialization.Equals(specialityId))
                    doctorsWithSpeciality.Add(d);
            }
            return doctorsWithSpeciality;
        }

        public Doctor GetDoctorBy(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Doctor editedObject)
        {
            throw new NotImplementedException();
        }

        public Doctor FindDoctorsByUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
