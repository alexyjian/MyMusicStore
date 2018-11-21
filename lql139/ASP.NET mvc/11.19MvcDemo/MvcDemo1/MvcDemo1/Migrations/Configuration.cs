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
            context.Database.ExecuteSqlCommand("delete Movies");
            var m1 = new Movie() {
                Title = "怪物猎人",
                ReleaseDate = DateTime.Parse("2019-1-1"),
                Genre="3D 动作 好莱坞",
                Price=20.00M
            };
            var m2 = new Movie()
            {
                Title = "复仇者联盟4",
                ReleaseDate = DateTime.Parse("2019-6-6"),
                Genre = "3D 科幻 漫威",
                Price = 30.00M
            };
            var m3 = new Movie()
            {
                Title = "玩具总动员4",
                ReleaseDate = DateTime.Parse("2019-1-1"),
                Genre = "3D 动画 好莱坞",
                Price = 15.00M
            };
            context.Movies.Add(m1);
            context.Movies.Add(m2);
            context.Movies.Add(m3);
            context.SaveChanges();      
        }
    }
}
