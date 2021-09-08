using System;
using System.Collections.Generic;

#nullable disable

namespace SMS_API.Data
{
    public partial class Attendance
    {
        public decimal AttendanceId { get; set; }
        public decimal StudentId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Attended { get; set; }

        public virtual Student Student { get; set; }
    }
}
