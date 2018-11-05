using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CodeFirstModels
{
    public class CourseContext : DbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<student> student { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer < CourseContext >(new CourseInitializer()) ;
        }   
    }
    //每一次运行都添加到数据库
    public class CourseInitializer : DropCreateDatabaseIfModelChanges<CourseContext>
    {
    }
}
