﻿using System;
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
    }
}