namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicStoreEntity.EntityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MusicStoreEntity.EntityDbContext";
        }

        protected override void Seed(MusicStoreEntity.EntityDbContext context)
        {

            //UserAndRoleSeed.Addroles();
            //UserAndRoleSeed.AddUsers();
            GenreSeed.Seed();

            
            GenreSeed.Extend();
        }
    }
}
