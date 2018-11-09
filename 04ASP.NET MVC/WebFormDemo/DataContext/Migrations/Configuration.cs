namespace StuContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StuContext.StuDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StuContext.StuDBContext context)
        {
            DepartmentSeed.Seed(context);
            StudentSeed.Seed(context);
        }
    }
}
