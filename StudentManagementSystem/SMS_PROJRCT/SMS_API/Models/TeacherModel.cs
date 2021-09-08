using SMS_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Models
{
    public class TeacherModel
    {
        public decimal TeacherId { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public decimal Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual Class ClassNameNavigation { get; set; }
    }
}
