namespace MvcWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcWeb.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcWeb.Models.MovieDBContext context)
        {
            var m1 = new Models.Movie()
            {
                Title = "复仇者联盟IV",
                ReleaseDate = DateTime.Parse("2019-2-2"),
                Genre = "3D 动作 科幻",
                Price = 32
            };
            var m2 = new Models.Movie()
            {
                Title = "怪物猎人",
                ReleaseDate = DateTime.Parse("2019-1-2"),
                Genre = "3D 动作 科幻",
                Price = 40
            };
            var m3 = new Models.Movie()
            {
                Title = "毒液",
                ReleaseDate = DateTime.Parse("2018-11-11"),
                Genre = "3D 动作 科幻",
                Price = 50
            };
            var m4 = new Models.Movie()
            {
                Title = "西红市首富",
                ReleaseDate = DateTime.Parse("2018-7-27"),
                Genre = "搞笑",
                Price = 35
            };
            var m5 = new Models.Movie()
            {
                Title = "碟中谍6：全面瓦解",
                ReleaseDate = DateTime.Parse("2018-7-27"),
                Genre = "动作冒险",
                Price = 42
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
