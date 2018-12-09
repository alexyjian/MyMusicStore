namespace MVCDemo1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MVCDemo1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCDemo1.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVCDemo1.Models.MovieDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Database.ExecuteSqlCommand("delete Moives");
          

            var m1 = new Moive()
            {
                Titile = "����A��",
                ReleaseDate = DateTime.Parse("2015-5-26"),
                Genre = "3D ���� ����",
                Price = 50.00M,
            };
            var m2 = new Moive()
            {
                Titile = "���������ɺ�",
                ReleaseDate = DateTime.Parse("2018-10-29"),
                Genre = "3D ���� �ഺ",
                Price = 50.00M,
            };
            var m3 = new Moive()
            {
                Titile = "�Ҳ���ҩ��",
                ReleaseDate = DateTime.Parse("2018-9-26"),
                Genre = "2D ϲ��",
                Price = 30.00M,
            };
            var m4 = new Moive()
            {
                Titile = "��ʽ�ഺ",
                ReleaseDate = DateTime.Parse("2018-10-29"),
                Genre = "2D ����",
                Price = 30.00M,
            };
            var m5 = new Moive()
            {
                Titile = "���涯��������",
                ReleaseDate = DateTime.Parse("2017-6-26"),
                Genre = "3D ���",
                Price = 50.00M,
            };

            context.Moives.Add(m1);
            context.Moives.Add(m2);
            context.Moives.Add(m3);
            context.Moives.Add(m4);
            context.Moives.Add(m5);
            context.SaveChanges();
        }
    }
}
