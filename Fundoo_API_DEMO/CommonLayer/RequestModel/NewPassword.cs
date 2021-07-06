using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModel
{
    public class NewPassword
    {
        public string NewPass { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
