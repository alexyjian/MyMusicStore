namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicStoreEntity.MusicContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MusicStoreEntity.MusicContext context)
        {
            //UserAndRoleSeed.AddRoles();
            //UserAndRoleSeed.AddUsers();
            //GenreSeed.Seed();
            //GenreSeed.Extend();
        }
    }
}