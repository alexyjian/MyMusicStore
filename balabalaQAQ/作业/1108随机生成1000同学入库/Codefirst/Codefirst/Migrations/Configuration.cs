namespace Codefirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Codefirst.DataContext.StuDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Codefirst.DataContext.StuDBContext context)
        {

            context.Database.ExecuteSqlCommand("delete Students");
            context.Database.ExecuteSqlCommand("delete Departments");
            DepartMentSeed.Seed(context);
            context.SaveChanges();
            StudentSeed.Seed(context);
            context.SaveChanges();
            StudentSeed._GarbageClear();
        }
    }
}
