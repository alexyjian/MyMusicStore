namespace DataContext.Migrations
{
    using global::Migrations;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext.StuDBCotext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext.StuDBCotext context)
        {

            //DepartmentSeed.Seed(context);
            //StudentSeed.Seed(context);
        }
    }
}
