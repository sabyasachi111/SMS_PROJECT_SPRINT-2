using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_APP.Models
{
    public class AttendanceModel
    {
        public long AttendanceId { get; set; }
        public long StudentId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Attended { get; set; }

        public virtual StudentModel Student { get; set; }
    }
}
