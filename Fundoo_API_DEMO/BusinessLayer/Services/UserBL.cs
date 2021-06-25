using System;
using System.Collections.Generic;
using CommonLayer;
using CommonLayer.RequestModel;
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

        public void AddUser(AddUser user)
        {
            this.userRl.AddUser(user);
        }

        public IEnumerable<User> UserDetails()
        {
            var Details = this.userRl.UserDetails();
            return Details;
        }

        public string UserAuthentication(string email, string password)
        {
            try
            {
                return this.userRl.UserAuthentication(email, password);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public bool ForgotPassword(string email)
        {
            try
            {
                return this.userRl.ForgotPassword(email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void ResetPassword(string email, string newPassword)
        {
            try
            {
                this.userRl.ResetPassword(email, newPassword);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
