
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDB1
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext() : base()
        {
        }
        public Microsoft.EntityFrameworkCore.DbSet<Student> Students { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Teacher> Teachers { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Grade> Grades { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=true");


        } 
    }      
    
}
    

