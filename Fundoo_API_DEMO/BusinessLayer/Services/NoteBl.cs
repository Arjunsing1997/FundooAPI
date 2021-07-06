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
        public List<NoteResponse> NoteDetails(int Note_ID)
        {

            return this.noteRl.NoteDetails(Note_ID).FindAll(e => e.Note_ID == Note_ID);
            
        }

        public void AddNote(AddNote note)
        {
            this.noteRl.AddNote(note);
        }

        public void UpdateNote(NoteUpdateModel note)
        {
            this.noteRl.UpdateNote(note);
        }

        public void ColourUpdate(int Note_Id, string Colour)
        {
            this.noteRl.ColourUpdate(Note_Id, Colour);
        }

    }
}
