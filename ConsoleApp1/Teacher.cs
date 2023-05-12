namespace HomeworkDB1
{
    public class Teacher
    {
        public int TeacherID { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }

        public IList<Grade> Grades { get; set; }

        public IList<Course> Courses { get; set; }


    }
}
