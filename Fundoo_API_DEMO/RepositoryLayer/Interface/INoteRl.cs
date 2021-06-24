using CommonLayer;
using CommonLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INoteRl
    {
         void AddNote(AddNote note);
        IEnumerable<Notes> NoteDetails();

    }
}
