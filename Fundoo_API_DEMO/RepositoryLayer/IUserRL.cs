using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;

namespace RepositoryLayer
{
    public interface IUserRL
    {
        User RegisterUser(User newUser);

    }
}
