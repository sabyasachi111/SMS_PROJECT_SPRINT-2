using System;
using System.Collections.Generic;

#nullable disable

namespace SMS_API.Data
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public string ClassName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
