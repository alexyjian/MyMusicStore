using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstDemo.CodeFirstMadels
{
    /// <summary>
    /// 数据上下文 映射到DB
    /// </summary>
    public class CourseContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Student { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<CourseContext>(new CourseInitializer);
        //}
    }
    //每一次运行时都重新生成新数据库
    //public class CourseInitializer:DropCreateDatabaseIfModelChange<CourseContext>
    //{
    //    base.OnModelCreating(DbModelBuilder);
    //}
}
