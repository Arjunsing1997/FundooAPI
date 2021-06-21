using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;

namespace RepositoryLayer
{
    public interface IUserRL
    {
        User AddUser(User user);
        IEnumerable<User> UserDetails();

        bool UserAuthentication(string email, string password);
    }
}
