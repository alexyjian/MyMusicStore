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
                Titile = "复仇者联盟IV",
                ReleaseDate = DateTime.Parse("2019-2-2"),
                Genre = "3D 动作 好莱坞",
                Price = 30.00M
            };
            var m2 = new Movie()
            {
                Titile = "龙珠超：布罗利",
                ReleaseDate = DateTime.Parse("2018-12-14"),
                Genre = "2D 动作 Jump",
                Price = 30.00M
            };
            var m3 = new Movie()
            {
                Titile = "昨日青空",
                ReleaseDate = DateTime.Parse("2018-10-26"),
                Genre = "2D 青春 大陆",
                Price = 30.00M
            };
            var m4 = new Movie()
            {
                Titile = "毒液：致命守护者",
                ReleaseDate = DateTime.Parse("2018-11-9"),
                Genre = "3D 动作 好莱坞",
                Price = 30.00M
            };
            var m5 = new Movie()
            {
                Titile = "你好，之华",
                ReleaseDate = DateTime.Parse("2018-11-8"),
                Genre = "3D 剧情 好莱坞",
                Price = 30.00M
            };
            context.Movies.Add(m1);
            context.Movies.Add(m2);
            context.Movies.Add(m3);
            context.Movies.Add(m4);
            context.Movies.Add(m5);
        }
    }
}
