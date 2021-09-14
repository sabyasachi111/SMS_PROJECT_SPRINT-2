using SMS_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SMS_API.Models
{
    public class AttendanceModel
    {
        [Required]
        [RegularExpression(@"[\d]{6,10}")]
        public long AttendanceId { get; set; }


        [Required]
        [RegularExpression(@"[\d]{6,8}")]
        public long StudentId { get; set; }


        [Required]
        public DateTime AttendanceDate { get; set; }


        [Required]
        [RegularExpression(@"^[A|P]{1}$", ErrorMessage = "Invalid")]
        public string Attended { get; set; }

        public virtual Student Student { get; set; }
    }
}
