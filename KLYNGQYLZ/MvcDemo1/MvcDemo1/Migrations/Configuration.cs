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

        public Guid ID { get; private set; }

        protected override void Seed(MvcDemo1.Models.MovieDBContext context)
        {
            context.Database.ExecuteSqlCommand("delete movies");
            var m1 = new Movie()
            {
                Titile = "双世宠妃2",
                ReleaseDate = DateTime.Parse("2019-2-2"),
                Genre = "3D 动作 爱奇艺",
                Price = 50.00M
            };
            var m2 = new Movie()
            {
                Titile = "将夜",
                ReleaseDate = DateTime.Parse("2019-2-2"),
                Genre = "3D 动作 爱奇艺",
                Price = 50.00M
            };
            var m3 = new Movie()
            {
                Titile = "长城",
                ReleaseDate = DateTime.Parse("2019-2-2"),
                Genre = "3D 动作 爱奇艺",
                Price = 50.00M
            };
            var m4 = new Movie()
            {
                Titile = "爱情回来了",
                ReleaseDate = DateTime.Parse("2019-2-2"),
                Genre = "3D 动作 爱奇艺",
                Price = 50.00M
            }; var m5 = new Movie()
            {
                Titile = "生死狙击",
                ReleaseDate = DateTime.Parse("2019-2-2"),
                Genre = "3D 动作 爱奇艺",
                Price = 50.00M
            };

            context.Movies.Add(m1);
            context.Movies.Add(m2);
            context.Movies.Add(m3);
            context.Movies.Add(m4);
            context.Movies.Add(m5);
            context.SaveChanges();
        }
    }
}
