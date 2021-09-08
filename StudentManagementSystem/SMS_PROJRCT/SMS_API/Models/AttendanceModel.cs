using SMS_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Models
{
    public class AttendanceModel
    {
        public decimal AttendanceId { get; set; }
        public decimal StudentId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Attended { get; set; }

        public virtual Student Student { get; set; }
    }
}
