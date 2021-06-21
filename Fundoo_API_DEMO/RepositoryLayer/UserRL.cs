using System;
using System.Collections.Generic;
using System.Linq;
using CommonLayer;

namespace RepositoryLayer
{
    public class UserRL : IUserRL
    {

        private FundooContext _userDbContext;
        public UserRL(FundooContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public User AddUser(User newuser)
        {
            _userDbContext.Users.Add(newuser);  //"Users" is a Data base name
            _userDbContext.SaveChanges();
            return newuser;
        }

        public IEnumerable<User> UserDetails()
        {
            var Details = _userDbContext.Users.ToList();
            return Details;
        }

        public bool UserAuthentication(string email, string password)
        {
            try
            {
                var result = _userDbContext.Users.FirstOrDefault(s => s.Email == email && s.Password == password);
                if(result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
