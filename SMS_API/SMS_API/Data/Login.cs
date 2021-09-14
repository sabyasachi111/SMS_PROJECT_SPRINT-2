using System;
using System.Collections.Generic;

#nullable disable

namespace SMS_API.Data
{
    public partial class Login
    {
        public long LoginId { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
