using CodeFirstDemo.CodeFirstes;
using ConsoleApplication1.CodeFirstModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.CodeFirstesModels
{
    /// <summary>
    /// 数据上下文 央射到DB
    /// </summary>
   public class CourseContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

       public DbSet<Student> Students { get; set; }
    }
}
