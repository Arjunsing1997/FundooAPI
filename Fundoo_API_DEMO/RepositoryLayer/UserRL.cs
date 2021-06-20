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
            _userDbContext.Users.Add(newuser);
            _userDbContext.SaveChanges();
            return newuser;
        }

        public IEnumerable<User> UserDetails()
        {
            var Details = _userDbContext.Users.ToList();
            return Details;
        }
    }
}
