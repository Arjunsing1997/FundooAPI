using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    interface INoteBl
    {
        IEnumerable<Notes> NotesDetails();
        Notes AddNote(Notes note);
        
    }
}
