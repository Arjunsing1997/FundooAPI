using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;
using CommonLayer.RequestModel;

namespace RepositoryLayer
{
    public interface IUserRL
    {
        void AddUser(AddUser user);
        IEnumerable<User> UserDetails();
        string UserAuthentication(string email, string password);
        bool ForgotPassword(string email);
        void ResetPassword(string email, string newPassword);
    }
}
