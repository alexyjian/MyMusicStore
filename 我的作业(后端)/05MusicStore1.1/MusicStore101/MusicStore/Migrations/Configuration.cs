namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicStoreEntity.EntityDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MusicStoreEntity.EntityDBContext context)
        {
            //UserAndRoleSeed.AddRoles();
            //UserAndRoleSeed.AddUsers();
            GenreSeed.Seed();
        }
    }
}
