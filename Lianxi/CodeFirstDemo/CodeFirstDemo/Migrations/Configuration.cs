namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstDemo.CodeFirstModels.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodeFirstDemo.CodeFirstModels.CourseContext context)
        {

            context.Database.ExecuteSqlCommand("delete courses");
            context.Database.ExecuteSqlCommand("delete students");
            context.Database.ExecuteSqlCommand("delete departments");

            StudentSeed.Seed(context);
         
        }
    }
}
