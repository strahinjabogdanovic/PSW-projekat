using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.repository
{
    public interface UserRepository: IGenericRepository<User, string>
    {
        User save(User user);
        public User FindByUsernameAndPassword(String username, String password);
    }
}
