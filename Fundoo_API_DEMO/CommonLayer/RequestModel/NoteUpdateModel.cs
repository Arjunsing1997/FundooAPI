using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModel
{
    public class NoteUpdateModel
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public DateTime Reminder { get; set; }
        public string Image { get; set; }
        public string Archive { get; set; }
        public string Trash { get; set; }
        public string Pin { get; set; }
        public int Note_Id { get; set; }
    }
}
