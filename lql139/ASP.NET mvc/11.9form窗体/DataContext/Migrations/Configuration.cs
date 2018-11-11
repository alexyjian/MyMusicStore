namespace StuContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StuContext.StuuuContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StuContext.StuuuContext context)
        {
            context.Database.ExecuteSqlCommand("delete DepartMents");
            context.Database.ExecuteSqlCommand("delete Studetnts");
            DepartMentSeed.Seed(context);
            StudetntSeed.Seed(context);
        }
    }
}
