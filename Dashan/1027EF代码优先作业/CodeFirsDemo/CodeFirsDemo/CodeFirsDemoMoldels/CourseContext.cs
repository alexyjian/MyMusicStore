using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirsDemo.CodeFirsDemoMoldels
{
   public class CourseContext:DbContext
    {
        public DbSet<Dpartment> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
