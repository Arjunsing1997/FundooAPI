using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;

namespace BusinessLayer.Services
{
    public class NoteBl : INoteBl
    {
        public INoteRl noteRl;

        public NoteBl(INoteRl noteRl)
        {
            this.noteRl = noteRl;
        }
        public List<NoteResponse> NoteDetails(long UserID)
        {

            return this.noteRl.NoteDetails(UserID).FindAll(e => e.UserId == UserID);
            
        }

        public void AddNote(AddNote note)
        {
            this.noteRl.AddNote(note);
        }

        public void UpdateNote(AddNote note)
        {
            this.noteRl.UpdateNote(note);
        }

    }
}
