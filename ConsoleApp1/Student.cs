namespace HomeworkDB1
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }

        public string SurName { get; set; }

        public IList<Course> Courses { get; set; }
        public IList<Grade> Grades { get; set; }



    }

}
