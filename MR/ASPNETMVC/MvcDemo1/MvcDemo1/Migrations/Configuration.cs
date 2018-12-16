namespace MvcDemo1.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcDemo1.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcDemo1.Models.MovieDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var m1 = new Movie()
            {
                Titile = "复仇者联盟",
                ReleaseDate = DateTime.Parse("2019-2-2"),
                Genre = "3D 动作 好莱坞",
                Price = 50.00M
            };


            context.Movies.Add(m1);
            context.SaveChanges();
            

        }
    }
}
