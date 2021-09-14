﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_APP.Models
{
    public class GradeModel
    {
        [Required]
        [RegularExpression(@"^[\d]{6,10}$", ErrorMessage = "Invalid")]
        public long GradeId { get; set; }

        [Required]
        [RegularExpression(@"^[\d]{6,8}$", ErrorMessage = "Invalid")]
        public long StudentId { get; set; }

        [Required]
        [MaxLength(3)]
        public string GradeName { get; set; }


        [Required]
        [MaxLength(20)]
        public string Description { get; set; }


        public virtual StudentModel Student { get; set; }
    }
}
