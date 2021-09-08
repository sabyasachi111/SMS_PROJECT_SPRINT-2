using System;
using System.Collections.Generic;

#nullable disable

namespace SMS_API.Data
{
    public partial class Login
    {
        public decimal LoginId { get; set; }
        public string Password { get; set; }
        public decimal Role { get; set; }
    }
}
