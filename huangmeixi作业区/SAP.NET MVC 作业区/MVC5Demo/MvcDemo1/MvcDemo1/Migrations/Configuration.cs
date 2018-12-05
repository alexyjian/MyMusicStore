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
                Titile = "前任3",
                ReleaseDate = DateTime.Parse("2017-4-2"),
                Genre = "3D 动作 好莱坞",
                Price = 50.00M
            };
            var m2 = new Movie()
            {
                Titile = "复仇者联盟",
                ReleaseDate = DateTime.Parse("2017-4-3"),
                Genre = "3D 动作 好莱坞",
                Price = 20.00M
            };
            var m3 = new Movie()
            {
                Titile = "我的青春我做主",
                ReleaseDate = DateTime.Parse("2017-4-6"),
                Genre = "3D 动作 好莱坞",
                Price = 30.00M
            };
            var m4 = new Movie()
            {
                Titile = "你好，再见",
                ReleaseDate = DateTime.Parse("2017-4-7"),
                Genre = "3D 动作 好莱坞",
                Price = 35.00M
            };
            var m5 = new Movie()
            {
                Titile = "我的大学",
                ReleaseDate = DateTime.Parse("2017-4-9"),
                Genre = "3D 动作 好莱坞",
                Price = 40.00M
            };
            context.Movies.Add(m1);
            context.Movies.Add(m2);
            context.Movies.Add(m3);
            context.Movies.Add(m4);
            context.Movies.Add(m5);
        }
    }
}
