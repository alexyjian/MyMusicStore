namespace test1.Migrations
{
    using Code;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<test1.DbContent.StudentContent>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(test1.DbContent.StudentContent context)
        {
            
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Database.ExecuteSqlCommand("delete Students");
            context.Database.ExecuteSqlCommand("delete DepartMents");

            string[] dps = { "������Ϣ", "ó��������", "��ʳ����", "����ѧԺ" };
            var d1 = new DepartMent()
            {
                Name = "������Ϣ"
            };
            var d2 = new DepartMent()
            {
                Name = "ó��������"
            };
            var d3 = new DepartMent()
            {
                Name = "��ʳ����"
            };
            var d4 = new DepartMent()
            {
                Name = "����ѧԺ"
            };
            context.DepartMents.Add(d1);
            context.DepartMents.Add(d2);
            context.DepartMents.Add(d3);
            context.DepartMents.Add(d4);
            context.SaveChanges();

            string studentid;
            string dpsname = "";
            for (var i = 1; i <= 1000; i++)
            {
                dpsname = dps[new Random().Next(0, dps.Length - 1)];
                if (i <= 9) studentid = "2017031000" + i.ToString();
                else if (i == 100) studentid = "20170310" + i.ToString();
                else studentid = "201703100" + i.ToString();
                Student s = new Code.Student()
                {

                    StudentID = studentid,
                    Phone = new Random().Next(0, 10000).ToString(),
                    Address = "���ǽֵ�"+i.ToString()+"��",
                    Age = i,
                    DepartMent = context.DepartMents.SingleOrDefault(x => x.Name == dpsname)
                };

                context.Students.Add(s);
                Thread.Sleep(10);
            }
            context.SaveChanges();
        }
    }
}
