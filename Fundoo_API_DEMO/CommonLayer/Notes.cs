using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer
{
    public class Notes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Note_ID { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Colour { get; set; }
        public DateTime Reminder { get; set; }
        public string Image { get; set; }

        public long UserId { get; set; }
        public User user { get; set; }

    }
}
