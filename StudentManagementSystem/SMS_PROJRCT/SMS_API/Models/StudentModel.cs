using SMS_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Models
{
    public class StudentModel
    {
        public StudentModel()
        {
            Attendances = new HashSet<Attendance>();
            Fees = new HashSet<Fee>();
            Grades = new HashSet<Grade>();
        }

        public decimal StudentId { get; set; }
        public string ClassName { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string BloodGroup { get; set; }
        public decimal Contact { get; set; }
        public string Address { get; set; }

        public virtual Class ClassNameNavigation { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}

