using Microsoft.EntityFrameworkCore;
using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.repository
{
    public class UserSqlRepository : UserRepository
    {/*
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public User findOneByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetOne(string id)
        {
            throw new NotImplementedException();
        }

        public User save(User user)
        {
            throw new NotImplementedException();
        }

        public bool Save(User newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(User editedObject)
        {
            throw new NotImplementedException();
        }
        */
       
        public MyDbContext dbContext { get; set; }

        public UserSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserSqlRepository() { }

        public void Add(User user)
        {
            int id = dbContext.Users.ToList().Count > 0 ? dbContext.Users.ToList().Max(user => user.Id) + 1 : 1;
            user.Id = id;
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            
        }

        /*public List<User> GetAll()
        {
            return dbContext.User.ToList();
        }/*

        public User GetOne(string id)
        {
            throw new NotImplementedException();
        }*/

        /*blic void SaveUser(User user)
        {
            Doctor d = (from n in dbContext.Doctors where n.Id == patient.DoctorId select n).FirstOrDefault();
            if (d != null)
                d.NumberOfPatients++;
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }*/

        /*public User GetOne(int id)
        {
            Patient patientWithThatId = (from n in dbContext.Patients where n.Id == id select n).FirstOrDefault();
            return patientWithThatId;
        }*/

        public bool Update(User editedObject)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool Save(User newObject)
        {
            throw new NotImplementedException();
        }

        public User save(User user)
        {
            throw new NotImplementedException();
        }

        public User findOneByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetOne(string id)
        {
            throw new NotImplementedException();
        }

        /*public bool activateAccount(int userId, string token)
        {
            Patient patientToChange = dbContext.Patients.Find(userId);
            if (patientToChange.Token.Equals(token))
            {
                patientToChange.IsActive = true;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }*/

        /* public bool saveToken(Patient tokenPatient)
         {
             Patient patientToChange = dbContext.Patients.Find(tokenPatient.Id);
             patientToChange.Token = tokenPatient.Token;
             dbContext.SaveChanges();
             return true;
         }*/

        /*public bool CheckToken(string token)
        {
            try
            {
                Patient patientToChange = (from n in dbContext.Patients where n.IsActive != true && n.Token == token select n).First();
                if (patientToChange != null)
                {
                    patientToChange.IsActive = true;
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;

            }

            return false;
        }*/

        /*public Patient FindByUsernameAndPassword(String username, String password)
        {
            Patient patient = (from n in dbContext.Patients where n.Username == username && n.Password == password select n).FirstOrDefault();
            return patient;
        }*/
    }
}
