using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interface;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class NoteBl : INoteBl
    {
        private INoteRl noteRl;

        public NoteBl(INoteRl noteRl)
        {
            this.noteRl = noteRl;
        }

        public Notes AddUser(Notes note)
        {
            this.noteRl.AddNotes(user);
            return user;
        }
    }
}
