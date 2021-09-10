using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_APP.Models
{
    public class GradeModel
    {
        public long GradeId { get; set; }
        public long StudentId { get; set; }
        public string GradeName { get; set; }
        public string Description { get; set; }


        public virtual StudentModel Student { get; set; }
    }
}
