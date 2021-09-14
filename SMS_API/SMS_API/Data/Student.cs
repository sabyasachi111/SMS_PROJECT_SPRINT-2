using System;
using System.Collections.Generic;

#nullable disable

namespace SMS_API.Data
{
    public partial class Student
    {
        public Student()
        {
            Attendances = new HashSet<Attendance>();
            Fees = new HashSet<Fee>();
            Grades = new HashSet<Grade>();
        }

        public long StudentId { get; set; }
        public string ClassName { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string BloodGroup { get; set; }
        public long Contact { get; set; }
        public string Address { get; set; }

        public virtual Class ClassNameNavigation { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
