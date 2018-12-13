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

<<<<<<< HEAD
            context.Database.ExecuteSqlCommand("delete AspNetUsers");
            context.Database.ExecuteSqlCommand("delete Albums");
            context.Database.ExecuteSqlCommand("delete Artists");
            context.Database.ExecuteSqlCommand("delete Genres");
            context.Database.ExecuteSqlCommand("delete AspNetUserRoles");
=======
            //context.Database.ExecuteSqlCommand("delete AspNetUsers");
            //context.Database.ExecuteSqlCommand("delete Albums");
            //context.Database.ExecuteSqlCommand("delete Artists");
            //context.Database.ExecuteSqlCommand("delete Genres");
            //context.Database.ExecuteSqlCommand("delete AspNetUserRoles");

>>>>>>> 169a1dc5ec953bec41b43f553b60109f91cc1e9e



            UserAndRoleSeed.AddUserAndRoles();
            UserAndRoleSeed.AddSpecialUser();
            GenreSeed.Seed();
            GenreSeed.Extend();
        }
    }
}
