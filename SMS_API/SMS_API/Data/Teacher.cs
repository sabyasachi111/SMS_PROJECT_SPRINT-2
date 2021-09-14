using System;
using System.Collections.Generic;

#nullable disable

namespace SMS_API.Data
{
    public partial class Teacher
    {
        public long TeacherId { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public long Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual Class ClassNameNavigation { get; set; }
    }
}
