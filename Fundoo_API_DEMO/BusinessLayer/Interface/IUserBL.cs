using CommonLayer;
using CommonLayer.RequestModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IUserBL
    {
        
        void AddUser(AddUser user);
        IEnumerable<User> UserDetails();
        string UserAuthentication(string email, string password);
        bool ForgotPassword(string email); //forget Password Method
        void ResetPassword(string email, string newPassword);
    }
}
