using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_APP.Models
{
    public class ClassModel
    {
        public ClassModel()
        {
            Students = new HashSet<StudentModel>();
            Teachers = new HashSet<TeacherModel>();
        }

        public string ClassName { get; set; }

        public virtual ICollection<StudentModel> Students { get; set; }
        public virtual ICollection<TeacherModel> Teachers { get; set; }
    }
}
