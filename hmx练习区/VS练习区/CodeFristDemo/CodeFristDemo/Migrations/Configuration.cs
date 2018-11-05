namespace CodeFristDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CodeFirstModels;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFristDemo.CodeFirstModels.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodeFristDemo.CodeFirstModels.CourseContext context)
        {
            context.Database.ExecuteSqlCommand("delete courses");
            context.Database.ExecuteSqlCommand("delete departments");
            CourserSeed.Seed(context);
            DepartmentSeed.Seed(context);
            StudentSeed.Seed(context);
            
           
        }
    }
}
