namespace Migrations
{
    using DataContext;
    using global::Migrations;
    using Microsoft.SqlServer.Server;

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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Database.ExecuteSqlCommand("delete departments");
            context.Database.ExecuteSqlCommand("delete students");
            DepartmentSeed.Seed(context);
            StudentSeed.Seed(context);
        }
    }
}
