using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        [Required]
        [RegularExpression(@"^[\d]{6,8}$", ErrorMessage = "Invalid")]
        public long StudentId { get; set; }

        [Required]
        public string ClassName { get; set; }

        [Required]
        [MaxLength(25)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]+$", ErrorMessage = "Invalid")]
        public string StudentName { get; set; }

        [Required]
        [RegularExpression(@"^[M|F]$", ErrorMessage = "Invalid")]
        public string Gender { get; set; }

        [Required]
        public DateTime? Dob { get; set; }

        [Required]
        public string BloodGroup { get; set; }

        [Required]
        [RegularExpression(@"^[\d]{10}$", ErrorMessage = "Invalid")]
        public long Contact { get; set; }

        [Required]
        [MaxLength(50)]
        //[RegularExpression(@"^(\d+)/([A-Z]),([a-zA-Z]+),([a-zA-Z]+),$", ErrorMessage = "Invalid")]
        public string Address { get; set; }

        public virtual ClassModel ClassNameNavigation { get; set; }
        public virtual ICollection<AttendanceModel> Attendances { get; set; }
        public virtual ICollection<FeeModel> Fees { get; set; }
        public virtual ICollection<GradeModel> Grades { get; set; }
    }
}
