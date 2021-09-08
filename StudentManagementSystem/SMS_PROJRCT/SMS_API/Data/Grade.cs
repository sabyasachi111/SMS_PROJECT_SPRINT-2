using System;
using System.Collections.Generic;

#nullable disable

namespace SMS_API.Data
{
    public partial class Grade
    {
        public decimal GradeId { get; set; }
        public decimal StudentId { get; set; }
        public string GradeName { get; set; }
        public string Description { get; set; }

        public virtual Student Student { get; set; }
    }
}
