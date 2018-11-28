namespace CodeFirst1108.Migrations
{
    using Enities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst1108.DataContext.StuDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodeFirst1108.DataContext.StuDBContext context)
        {
            context.Database.ExecuteSqlCommand("delete Students");
            context.Database.ExecuteSqlCommand("delete DepartMents");
            DepartMentSeed.Seed(context);
            StudentSeed.Seed(context);


        }
    }
}
