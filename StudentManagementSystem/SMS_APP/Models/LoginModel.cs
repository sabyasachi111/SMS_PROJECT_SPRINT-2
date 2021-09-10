using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_APP.Models
{
    public class LoginModel
    {
        public long LoginId { get; set; }
        public long Password { get; set; }
        public int Role { get; set; }
    }
}
