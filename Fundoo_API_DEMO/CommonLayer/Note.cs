using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class Note
    {
        [Key]
        public int Note_ID { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Colour { get; set; }
        public DateTime Reminder { get; set; }
        public string Image { get; set; }

       /// public int UserId { get; set; }
        public User User { get; set; }

    }
}
