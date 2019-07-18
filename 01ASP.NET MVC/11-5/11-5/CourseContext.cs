using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace _11_5
{
    /// <summary>
    /// 数据上下文 映射到DB
    /// </summary>
   public class CourseContext:DbContext

    {
        public DbSet<Department>Departments { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }
       
    }
}
