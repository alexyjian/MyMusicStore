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
                Title = "毒液：致命守护者",
                ReleaseDate=DateTime.Parse("2018-1-1"),
                Genre="动作|特效",
                Price=37.00m
            };

            var m2 = new Movie()
            {
                Title = "12",
                ReleaseDate = DateTime.Parse("2018-1-1"),
                Genre = "动作|特效",
                Price = 37.00m
            };
            context.Movies.Add(m1);
            context.Movies.Add(m2);

        }
    }
}
