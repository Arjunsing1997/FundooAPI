using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using CommonLayer.RequestModel;

namespace BusinessLayer.Services
{
    public class NoteBl : INoteBl
    {
        public INoteRl noteRl;

        public NoteBl(INoteRl noteRl)
        {
            this.noteRl = noteRl;
        }
        public IEnumerable<Notes> NoteDetails()
        {
   
            var Details = this.noteRl.NoteDetails();
            return Details;
        }

        public void AddNote(AddNote note)
        {
            this.noteRl.AddNote(note);
        }

    }
}
