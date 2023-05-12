
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDB1
{
    public class Course
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; }

        public IList<Student> Students { get; set; }
        public IList<Teacher> Teachers { get; set; }

        public IList<Grade> Grades { get; set; }
        
    }
}
