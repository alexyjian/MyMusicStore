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
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MusicStoreEntity.EntityDbContext context)
        {

            //context.Database.ExecuteSqlCommand("delete AspNetUsers");
            context.Database.ExecuteSqlCommand("delete Albums");
            context.Database.ExecuteSqlCommand("delete Artists");
            context.Database.ExecuteSqlCommand("delete Genres");
            // context.Database.ExecuteSqlCommand("delete AspNetUserRoles");
            


            //UserAndRoleSeed.AddUserAndRoles();
            //UserAndRoleSeed.AddSpecialUser();
            GenreSeed.Seed();
            GenreSeed.Extend();
        }
    }
}
