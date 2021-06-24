using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModel
{
    public class AddNote
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string Colour { get; set; }
        public DateTime Reminder { get; set; }
        public string Image { get; set; }
        public string Archieve { get; set; }
        public string Trash { get; set; }
        public string Pin { get; set; }
        public long UserId { get; set; }
    }
}
