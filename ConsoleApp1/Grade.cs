using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDB1
{
    public class Grade
    {

        public int GradeID { get; set; }

        public int GradeValue { get; set; }



        public IList<Student> Students { get; set; }

        public IList<Teacher> Teachers { get; set; }

        public IList<Course> Courses { get; set; }
    }
}