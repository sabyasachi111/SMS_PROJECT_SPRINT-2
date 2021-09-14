using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_APP.Models
{
    public class TeacherModel
    {
        [Required]
        [RegularExpression(@"^[\d]{6,8}$", ErrorMessage = "Invalid")]
        public long TeacherId { get; set; }

        [Required]
        public string ClassName { get; set; }

        [Required]
        [MaxLength(25)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]+$", ErrorMessage = "Invalid")]
        public string TeacherName { get; set; }

        [Required]
        [RegularExpression(@"^[M|F]$", ErrorMessage = "Invalid")]
        public string Gender { get; set; }

        [Required]
        public DateTime? Dob { get; set; }

        [Required]
        [RegularExpression(@"^[\d]{10}$", ErrorMessage = "Invalid")]
        public long Contact { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        //[RegularExpression(@"^[a-zA-Z][a-zA-Z\s]+$", ErrorMessage = "Invalid")]
        public string Address { get; set; }

        public virtual ClassModel ClassNameNavigation { get; set; }
    }
}
