namespace WebApplication1.Migrations
{
    using MusicStore.Migrations;
    using MusicStorEntity.Migrations;
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
            //UserAndRoleSeed.AddRoles();
            //UserAndRoleSeed.AddUsers();
            GenreSeed.Seed();
            GenreSeed.Extend();
            
        }
    }
}
