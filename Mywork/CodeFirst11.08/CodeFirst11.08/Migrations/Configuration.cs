namespace CodeFirst11._08.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst11._08.DataContext.StuDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodeFirst11._08.DataContext.StuDBContext context)
        {
            //DepartmentSeed.Seed(context);
            StudentSeed.Seed(context);
        }
    }
}
