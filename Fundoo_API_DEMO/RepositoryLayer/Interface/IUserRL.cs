﻿using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;

namespace RepositoryLayer
{
    public interface IUserRL
    {
        User AddUser(User user);
        IEnumerable<User> UserDetails();
        string UserAuthentication(string email, string password);
        bool ForgotPassword(string email);
    }
}