using CommonLayer;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;


namespace BusinessLayer.Interface
{
    public interface INoteBl
    {
        List<NoteResponse> NoteDetails(int Note_Id);
        void AddNote(AddNote note);
        void UpdateNote(NoteUpdateModel note);

        void ColourUpdate(int Note_Id, string Colour);
    }
}
