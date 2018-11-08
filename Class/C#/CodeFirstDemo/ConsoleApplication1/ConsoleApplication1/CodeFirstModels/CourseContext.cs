using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CodeFirstModels
{
    public class CourseContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }
    }
}
