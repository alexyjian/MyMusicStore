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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Database.ExecuteSqlCommand("delete Albums");
            context.Database.ExecuteSqlCommand("delete Artists");
            context.Database.ExecuteSqlCommand("delete Genres");
            GenreSeed.Seed();
            ArtistSeed.Seed();
            AlbumSeed.Seed();
            
        }
    }
}
