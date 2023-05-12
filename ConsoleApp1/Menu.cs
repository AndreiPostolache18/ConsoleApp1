using System;
using System.Linq;
using HomeworkDB1;

namespace ConsoleApp
{
    class Menu
    {
       
    }

    class MyApp
    {
        private CodeFirstContext context;

        public MyApp()
        {
            context = new CodeFirstContext();
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. View all students");
                Console.WriteLine("2. Add new student");
                Console.WriteLine("3. View all courses");
                Console.WriteLine("4. Add new course");
                Console.WriteLine("5. Add new teacher");
                Console.WriteLine("6. Enroll student in course");
                Console.WriteLine("7. Assign teacher to course");
                Console.WriteLine("8. View all grades");
                Console.WriteLine("9. Add new grade");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllStudents();
                        break;
                    case "2":
                        AddNewStudent();
                        break;
                    case "3":
                        ViewAllCourses();
                        break;
                    case "4":
                        AddNewCourse();
                        break;
                    case "5":
                        AddNewTeacher();
                        break;
                    case "6":
                        EnrollStudentInCourse();
                        break;
                    case "7":
                        AssignTeacherToCourse();
                        break;
                    case "8":
                        ViewAllGrades();
                        break;
                    case "9":
                        AddNewGrade();
                        break;
                    case "10":
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private void ViewAllStudents()
        {
            var students = context.Students.ToList();

            foreach (var student in students)
            {
                Console.WriteLine("{0} {1} {2}", student.StudentID, student.FirstName, student.SurName);
            }
        }

        private void ViewAllGrades()
        {
            var grades = context.Grades.ToList();

            foreach (var grade in grades)
            {
                Console.WriteLine("{0} {1}", grade.GradeID, grade.GradeValue);
            }
        }

        private void AddNewGrade()
        {
            Console.Write("Enter student ID: ");
            int studentID = int.Parse(Console.ReadLine());

            Console.Write("Enter course ID: ");
            int courseID = int.Parse(Console.ReadLine());

            Console.Write("Enter grade value: ");
            double gradeValue = double.Parse(Console.ReadLine());

            var student = context.Students.Find(studentID);
            var course = context.Courses.Find(courseID);

            if (student == null)
            {
                Console.WriteLine("Invalid student ID");
            }
            else if (course == null)
            {
                Console.WriteLine("Invalid course ID");
            }
            else
            {
                Grade newGrade = new Grade
                {
                    Students = new List<Student> { student },
                    Courses = new List<Course> { course },
                    GradeValue = (int)gradeValue
                };
                context.Grades.Add(newGrade);
                context.SaveChanges();
                Console.WriteLine("New grade added");
            }
        }

        private void AddNewStudent()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();

            Student newStudent = new Student { FirstName = firstName, SurName = surname };

            context.Students.Add(newStudent);
            context.SaveChanges();

            Console.WriteLine("New student added");
        }

        private void ViewAllCourses()
        {
            var courses = context.Courses.ToList();

            foreach (var course in courses)
            {
                Console.WriteLine("{0} {1}", course.CourseID, course.CourseName);
            }
        }

        private void AddNewCourse()
        {
            Console.Write("Enter course name: ");
            string courseName = Console.ReadLine();

            Course newCourse = new Course { CourseName = courseName };

            context.Courses.Add(newCourse);
            context.SaveChanges();

            Console.WriteLine("New course added");
        }

        private void AddNewTeacher()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();

            Teacher newTeacher = new Teacher { FirstName = firstName, SurName = surname };

            context.Teachers.Add(newTeacher);
            context.SaveChanges();

            Console.WriteLine("New teacher added");
        }

        private void AssignTeacherToCourse()
        {
            Console.Write("Enter teacher ID: ");
            int teacherID = int.Parse(Console.ReadLine());

            Console.Write("Enter course ID: ");
            int courseID = int.Parse(Console.ReadLine());

            var teacher = context.Teachers.Find(teacherID);
            var course = context.Courses.Find(courseID);

            if (teacher == null)
            {
                Console.WriteLine("Invalid teacher ID");
            }
            else if (course == null)
            {
                Console.WriteLine("Invalid course ID");
            }
            else
            {
                if (course.Teachers == null)
                {
                    course.Teachers = new List<Teacher>();
                }
                course.Teachers.Add(teacher);
                context.SaveChanges();
                Console.WriteLine("Teacher assigned to course");
            }
        }

        private void EnrollStudentInCourse()
        {
            Console.Write("Enter student ID: ");
            int studentID = int.Parse(Console.ReadLine());

            Console.Write("Enter course ID: ");
            int courseID = int.Parse(Console.ReadLine());

            var student = context.Students.Find(studentID);
            var course = context.Courses.Find(courseID);

            if (student == null)
            {
                Console.WriteLine("Invalid student ID");
            }
            else if (course == null)
            {
                Console.WriteLine("Invalid course ID");
            }
            else if (course.Students != null && course.Students.Any(s => s.StudentID == studentID))
            {
                Console.WriteLine("Student is already enrolled in the course");
            }
            else
            {
                if (course.Students == null)
                {
                    course.Students = new List<Student>();
                }
                course.Students.Add(student);
                context.SaveChanges();
                Console.WriteLine("Student enrolled in course");
            }
        }


    }
}

