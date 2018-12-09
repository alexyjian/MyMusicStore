namespace CodeFirstDemo.Migrations
{
    using CodeFirstNodels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstDemo.CodeFirstNodels.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        //种子方法
        protected override void Seed(CodeFirstDemo.CodeFirstNodels.CourseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.Database.ExecuteSqlCommand("delete courses");
            //context.Database.ExecuteSqlCommand("delete students");
            //context.Database.ExecuteSqlCommand("delete Departments");

            //DepartmentSeed.Seed(context);
            //CourseSeed.Seed(context);
            //StudentSeed.Seed(context);

        }
    }
}
