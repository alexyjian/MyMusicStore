namespace CodeFirst1108.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst1108.DataContent.StuDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodeFirst1108.DataContent.StuDBContext context)
        {
            context.Database.ExecuteSqlCommand("delete DepartMents");
            context.Database.ExecuteSqlCommand("delete Studetnts");
            DepartMentSeed.Seed(context);
            StudetntSeed.Seed(context);

        }
    }
}
