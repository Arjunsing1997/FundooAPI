using System;
using CommonLayer;


namespace BusinessLayer
{
    public class UserBL : IUserBL
    {
        IUserBL userBL;

        public UserBL(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        public User RegisterUser(User user)
        {
            try
            {
               return this.userBL.RegisterUser(user);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
