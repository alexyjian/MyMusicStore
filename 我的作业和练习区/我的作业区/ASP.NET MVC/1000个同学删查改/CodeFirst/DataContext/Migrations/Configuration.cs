namespace DataContext.Migrations
{
    using Enities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext.StuDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext.StuDBContext context)
        {
            context.Database.ExecuteSqlCommand("delete Students");
            context.Database.ExecuteSqlCommand("delete DepartMents");
            DepartMentSeed.Seed(context);
            StudentSeed.Seed(context);
        }
    }
}
