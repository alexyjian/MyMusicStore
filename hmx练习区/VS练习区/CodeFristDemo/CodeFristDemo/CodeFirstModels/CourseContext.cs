using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFristDemo.CodeFirstModels
{
    /// <summary>
    /// s数据上下文  映射到DB
    /// </summary>
     public   class  CourseContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Student>Students { get; set; }

        //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //    {
        //        Database.SetInitializer<CourseContext>( new CourseInitializer());
        //    }
        //}
        ////每一次运行时都重新生成
        //public class CourseInitializer : DropCreateDatabaseIfModelChanges<CourseContext>
        //{
    }
}
