using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_APP.Models
{
    public class StudentModel
    {
        public StudentModel()
        {
            Attendances = new HashSet<AttendanceModel>();
            Fees = new HashSet<FeeModel>();
            Grades = new HashSet<GradeModel>();
        }



        public long StudentId { get; set; }
        public string ClassName { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string BloodGroup { get; set; }
        public long Contact { get; set; }
        public string Address { get; set; }


        public virtual ClassModel ClassNameNavigation { get; set; }
        public virtual ICollection<AttendanceModel> Attendances { get; set; }
        public virtual ICollection<FeeModel> Fees { get; set; }
        public virtual ICollection<GradeModel> Grades { get; set; }
    }
}
