namespace MVC5Demo.Migrations
{
    using MvcDemo.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcDemo.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcDemo.Models.MovieDBContext context)
        {
            // context.Database.ExecuteSqlCommand("delete movies"); //删除原有记录 不重复
            var m1 = new Movie()
            {
                Titile = "西虹市首富",
                ReleaseDate = DateTime.Parse("2018 - 11 - 01"),
                Genre = "搞笑  感情",
                Price = 380.00M
            };
            var m2 = new Movie()
            {
                Titile = "我不是药神",
                ReleaseDate = DateTime.Parse("2018 - 11 - 10"),
                Genre = "搞笑  感情",
                Price = 400.00M
            };
            var m3 = new Movie()
            {
                Titile = "悲伤逆流成河",
                ReleaseDate = DateTime.Parse("2018 - 11 - 15"),
                Genre = " 感情",
                Price = 460.00M
            };
            context.Movies.Add(m1);
            context.Movies.Add(m2);
            context.Movies.Add(m3);
            context.SaveChanges();
        }
    }
}
