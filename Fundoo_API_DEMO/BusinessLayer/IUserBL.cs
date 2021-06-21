﻿using CommonLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IUserBL
    {
        
        User AddUser(User newUser);
        IEnumerable<User> UserDetails();

        bool UserAuthentication(string email, string password);
    }
}
