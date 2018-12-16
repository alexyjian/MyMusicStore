namespace MusicStore.Migrations
{
    using MusicStoreEntity.Migrations;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicStoreEntity.EntityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MusicStoreEntity.EntityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //UserAndRoleSeed.Addroles();
            //UserAndRoleSeed.AddUsers();
            //GenreSeed.Seed();
            //GenreSeed.Extend();
        }
    }
}
