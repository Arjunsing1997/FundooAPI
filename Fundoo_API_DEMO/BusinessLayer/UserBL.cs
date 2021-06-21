using System;
using System.Collections.Generic;
using CommonLayer;
using RepositoryLayer;

namespace BusinessLayer
{
    public class UserBL : IUserBL
    {
        IUserRL userRl;

        public UserBL(IUserRL userRl)
        {
            this.userRl = userRl;
        }

        public User AddUser(User user)
        {
            this.userRl.AddUser(user);
            return user;
        }

        public IEnumerable<User> UserDetails()
        {
            var Details = this.userRl.UserDetails();
            return Details;
        }

        public bool UserAuthentication(string email, string password)
        {
            try
            {
                bool result = this.userRl.UserAuthentication(email, password);
                if (result == true)
                    return true;
                else
                    return false;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}
