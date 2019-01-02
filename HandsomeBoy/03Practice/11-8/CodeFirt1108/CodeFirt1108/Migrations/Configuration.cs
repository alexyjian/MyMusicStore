namespace CodeFirt1108.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirt1108.DataContext.StuDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodeFirt1108.DataContext.StuDBContext context)
        {
            Migratioms.Seed(context);
            StudentSeed.Seed(context);
        }
    }
}
