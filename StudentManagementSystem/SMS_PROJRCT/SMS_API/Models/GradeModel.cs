using SMS_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Models
{
    public class GradeModel
    {
        public decimal GradeId { get; set; }
        public decimal StudentId { get; set; }
        public string GradeName { get; set; }
        public string Description { get; set; }

        public virtual Student Student { get; set; }
    }
}
