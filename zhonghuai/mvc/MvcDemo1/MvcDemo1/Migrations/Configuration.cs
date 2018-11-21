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
            context.Database.ExecuteSqlCommand("delete movies");
            var m1 = new Movie()
            {
                Titile="电影1",
                ReleaseDate=DateTime.Parse("2019-8-8"),
                Genre="动作 ",
                Price=50.00M


            };
            var m2 = new Movie()
            {
                Titile = "亚谁打别忘",
                ReleaseDate = DateTime.Parse("2019-8-8"),
                Genre = "色情 ",
                Price = 100.00M


            };
            var m3 = new Movie()
            {
                Titile = "也灭大别忘",
                ReleaseDate = DateTime.Parse("2020-8-8"),
                Genre = "传记 ",
                Price = 50.00M


            };
            var m4= new Movie()
            {
                Titile = "你的小可爱",
                ReleaseDate = DateTime.Parse("2030-8-8"),
                Genre = "亚谁 ",
                Price = 50.00M


            };

            context.Movies.Add(m1);
            context.Movies.Add(m2);
            context.Movies.Add(m3);
            context.Movies.Add(m4);
            context.SaveChanges();

        }

    }
}
