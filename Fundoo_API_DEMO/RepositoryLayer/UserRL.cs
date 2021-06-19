using System;
using CommonLayer;

namespace RepositoryLayer
{
    public class UserRL : IUserRL
    {
        FundooContext fundooContext;

        public UserRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        public User RegisterUser(User user)
        {
            try
            {
                fundooContext.Users.Add(user);
                fundooContext.SaveChanges();
                return user;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
