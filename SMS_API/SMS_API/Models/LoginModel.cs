using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Models
{
    public class LoginModel
    {
        [Required]
        public long LoginId { get; set; }

        [Required]
        public string Password { get; set; }


        [Required]
        public int Role { get; set; }
    }
}
