namespace DataContext.Migrations
{
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
            //context.Database.ExecuteSqlCommand("delete students");
            //context.Database.ExecuteSqlCommand("delete DepartMents");
            //DepartmentSeed.Seed(context);
            //StudentSeed.Seed(context);
        }
    }
}
