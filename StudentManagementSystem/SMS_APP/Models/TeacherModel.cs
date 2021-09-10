using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_APP.Models
{
    public class TeacherModel
    {
        public long TeacherId { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public long Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ClassModel ClassNameNavigation { get; set; }
    }
}
