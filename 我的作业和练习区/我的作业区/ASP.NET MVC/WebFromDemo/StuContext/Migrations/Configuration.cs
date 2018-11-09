namespace StuContext.Migrations
{
    using ASPNETWEB.StuContext;
    using ASPNETWEB.StuEntities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ASPNETWEB.StuContext.StuDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ASPNETWEB.StuContext.StuDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Database.ExecuteSqlCommand("delete Students");
            context.Database.ExecuteSqlCommand("delete DepartMents");
            DepartMentSeed.Seed(context);
            StudentSeed.Seed(context);

        }
    }
}
