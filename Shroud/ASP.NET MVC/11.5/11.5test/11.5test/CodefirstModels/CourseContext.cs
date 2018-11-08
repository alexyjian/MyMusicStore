using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._5test.CodefirstModels
{
    public class CourseContext : DbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<CourseContext>(new CourseInitializer());
        //}
    }

    //public class CourseInitializer : DropCreateDatabaseIfModelChanges<CourseContext>
    //{

    //}


}
