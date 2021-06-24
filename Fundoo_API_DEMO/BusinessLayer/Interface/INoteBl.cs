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
        List<NoteResponse> NoteDetails(long UserId);
        void AddNote(AddNote note);

        void UpdateNote(Notes note);
    }
}
