using CommonLayer;
using CommonLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INoteBl
    {
        IEnumerable<Notes> NoteDetails();
        void AddNote(AddNote note);
        
    }
}
