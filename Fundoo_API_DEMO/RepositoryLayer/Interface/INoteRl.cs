using CommonLayer;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INoteRl
    {
         void AddNote(AddNote note);
        List<NoteResponse> NoteDetails(int Note_ID);
        void UpdateNote(NoteUpdateModel note);

        void ColourUpdate(int Note_Id, string Colour);

    }
}
