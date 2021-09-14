using System;
using System.Collections.Generic;

#nullable disable

namespace SMS_API.Data
{
    public partial class Attendance
    {
        public long AttendanceId { get; set; }
        public long StudentId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Attended { get; set; }

        public virtual Student Student { get; set; }
    }
}
