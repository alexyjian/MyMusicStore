namespace mvcDemo1.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<mvcDemo1.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(mvcDemo1.Models.MovieDBContext context)
        {
            context.Database.ExecuteSqlCommand("delete movies");
            var m1 = new Movie()
            {
                Title = "复仇者联盟IV",
                ReleaseDate = DateTime.Parse("2019-2-2"),
                Genre = "3D 动作 好莱坞",
                Prce = 50.00M,
            };
            var m2 = new Movie()
            {
                Title = "怪物猎人",
                ReleaseDate = DateTime.Parse("2018-12-12"),
                Genre = "3D 动作 好莱坞",
                Prce = 30.00M,
            };
            var m3 = new Movie()
            {
                Title = "极限特工",
                ReleaseDate = DateTime.Parse("2019-2-2"),
                Genre = "2D 动作 好莱坞",
                Prce = 20.00M,
            };
            var m4 = new Movie()
            {
                Title = "银河护卫队",
                ReleaseDate = DateTime.Parse("2019-2-2"),
                Genre = "3D 动作 好莱坞",
                Prce = 40.00M,
            };
            var m5 = new Movie()
            {
                Title = "毒液：致命守护者",
                ReleaseDate = DateTime.Parse("2019-2-2"),
                Genre = " 动作 好莱坞",
                Prce = 50.00M,
            };
            context.Moves.Add(m1);
            context.Moves.Add(m2);
            context.Moves.Add(m3);
            context.Moves.Add(m4);
            context.Moves.Add(m5);
            context.SaveChanges();

        }
    }
}
