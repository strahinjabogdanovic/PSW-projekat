using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.repository
{
    public class UserSqlRepository : UserRepository
    {
        public MyDbContext dbContext { get; set; }

        public UserSqlRepository() { }

        public UserSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(User user)
        {
            int id = dbContext.Users.ToList().Count > 0 ? dbContext.Users.ToList().Max(user => user.Id) + 1 : 1;
            user.Id = id;
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public User FindByUsernameAndPassword(String username, String password)
        {
            //User user = (from n in dbContext.Users where n.Username.Equals(username) select n).FirstOrDefault();
            // Console.WriteLine((from n in dbContext.Users.Where(n => n.Username == username && n.Password == password) select n).FirstOrDefault());
            User user = new User();

            foreach (User users in dbContext.Users) 
            {
                if (users.Username.Equals(username))
                {
                    user = new User(username, password, users);
                }
            }
           
            return user;
        }

        public List<User> GetAll()
        {
            //foreach (Doctor doctors in dbContext.Doctors)
            //{
            //    if (doctors.Username.Equals(username))
            //    {
            //        doctor = new Doctor(username, password, doctors);
            //    }
            //}
            //List<User> userList = new List<User>();
            //foreach (User users in dbContext.Users)
            //{
            //    if (users.Role.Equals("PATIENT"))
            //    {
            //        userList.Add(users);
            //        Console.WriteLine(users);
            //    }
            //}
            //return dbContext.Users.ToList();
            return dbContext.Users.ToList();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public User findOneByUsername(string username)
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
    }
}
