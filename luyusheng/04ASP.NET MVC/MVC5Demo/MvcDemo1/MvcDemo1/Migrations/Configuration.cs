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
                ReleaseDate =DateTime.Parse("2019-2-2"),
                Genre ="3D 动作 好莱坞",
                Price =50.00M,
            };
            var m2 = new Movie()
            {
                Titile = "我不是药神",
                ReleaseDate = DateTime.Parse("2018-11-17"),
                Genre = "2D 悬疑 剧情",
                Price = 270.00M,
            };
            var m3 = new Movie()
            {
                Titile = "银河护卫队",
                ReleaseDate = DateTime.Parse("2018-12-12"),
                Genre = "3D 动作 好莱坞",
                Price = 30.00M,
            };
            var m4 = new Movie()
            {
                Titile = "极限特工4",
                ReleaseDate = DateTime.Parse("2018-12-6"),
                Genre = "3D 动作 激情",
                Price = 350.00M,
            };
            var m5 = new Movie()
            {
                Titile = "西虹市首富",
                ReleaseDate = DateTime.Parse("2018-11-15"),
                Genre = "2D 搞笑 喜剧",
                Price = 200.00M,
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
