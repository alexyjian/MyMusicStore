namespace ConsoleApplication1.Migrations
{
    using CodeFirstModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApplication1.CodeFirstModels.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ConsoleApplication1.CodeFirstModels.CourseContext context)
        {
            context.Database.ExecuteSqlCommand("delete Courses");
            context.Database.ExecuteSqlCommand("delete Departments");
            context.Database.ExecuteSqlCommand("delete students");
            DepartmentSeed.Seed(context);
            CourseSeed.Seed(context);
            studentSeed.Seed(context);
        }
    }
}
