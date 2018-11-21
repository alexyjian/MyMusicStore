namespace _11_19_MvcDemo.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_11_19_MvcDemo.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_11_19_MvcDemo.Models.MovieDBContext context)
        {
            context.Database.ExecuteSqlCommand("delete movies");
            var m1 = new Movie()
            {
                Tite = "复仇者联盟IV",
                ReLeaseDate = DateTime.Parse("2019-1-1"),
                Genre = "3D 动作 好莱坞",
                Price = 50.00M
            };
            var m2 = new Movie()
            {
                Tite = "怪物猎人",
                ReLeaseDate = DateTime.Parse("2018-1-1"),
                Genre = "3D 动作 好莱坞",
                Price = 30.00M
            };
            var m3 = new Movie()
            {
                Tite = "城市猎人",
                ReLeaseDate = DateTime.Parse("2018-2-1"),
                Genre = "3D 动作 好莱坞",
                Price = 30.00M
            };
            var m4 = new Movie()
            {
                Tite = "城市猎人",
                ReLeaseDate = DateTime.Parse("2018-2-1"),
                Genre = "2D 动作 剧情",
                Price = 30.00M
            };
            var m5 = new Movie()
            {
                Tite = "反贪风暴3",
                ReLeaseDate = DateTime.Parse("2018-2-1"),
                Genre = "3D 动作 悬疑",
                Price = 30.00M
            };
            var m6 = new Movie()
            {
                Tite = "我不是药神",
                ReLeaseDate = DateTime.Parse("2018-5-25"),
                Genre = "2D 动作 情感 剧情",
                Price = 28.00M
            };
            var m7 = new Movie()
            {
                Tite = "小偷家族",
                ReLeaseDate = DateTime.Parse("2018-2-1"),
                Genre = "2D 情感 剧情 犯罪",
                Price = 30.00M
            };
            context.Movie.Add(m1);
            context.Movie.Add(m2);
            context.Movie.Add(m3);
            context.Movie.Add(m4);
            context.Movie.Add(m5);
            context.Movie.Add(m6);
            context.Movie.Add(m7);
            context.SaveChanges();
        }
    }
}
