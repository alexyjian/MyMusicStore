namespace CodeFirstDemo.Migrations
{
    using CodeFirstMadels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstDemo.CodeFirstMadels.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodeFirstDemo.CodeFirstMadels.CourseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Database.ExecuteSqlCommand("delete courses");
            context.Database.ExecuteSqlCommand("delete departments");
            context.Database.ExecuteSqlCommand("delete students");

            var d1 = new Department()
            {
                Name = "������Ϣ����ѧԺ",
                SortCode = "001",
                Description = "��һ��ѧԺ"
            };

            var d2 = new Department()
            {
                Name = "���繤��ѧԺ",
                SortCode = "002",
                Description = "�ڶ���ѧԺ"
            };

            var d3 = new Department()
            {
                Name = "��������ѧԺ",
                SortCode = "003",
                Description = "������ѧԺ"
            };

            var d4 = new Department()
            {
                Name = "�ƾ�������ѧԺ",
                SortCode = "004",
                Description = "���Ĵ�ѧԺ"
            };

            context.Departments.Add(d1);
            context.Departments.Add(d2);
            context.Departments.Add(d3);
            context.Departments.Add(d4);
            context.SaveChanges();

         
            var c1 = new Course()
            {
                Title = "C#�������",
                Credit = 7,
                Department = context.Departments.SingleOrDefault(x => x.Name == "������Ϣ����ѧԺ")
            };

            var c2 = new Course()
            {
                Title = "MIS����ʵս",
                Credit = 15,
                Department = context.Departments.SingleOrDefault(x => x.Name == "������Ϣ����ѧԺ")
            };

            var c3 = new Course()
            {
                Title = "WEBӦ���뿪��",
                Credit = 17,
                Department = context.Departments.SingleOrDefault(x => x.Name == "������Ϣ����ѧԺ")
            };

            var c4 = new Course()
            {
                Title = "��ҵ��ͼ",
                Credit = 7,
                Department = context.Departments.SingleOrDefault(x => x.Name == "���繤��ѧԺ")
            };

            var c5 = new Course()
            {
                Title = "���������",
                Credit = 6,
                Department = context.Departments.SingleOrDefault(x => x.Name == "��������ѧԺ")
            };

            var c6 = new Course()
            {
                Title = "����Ӫ��",
                Credit = 6,
                Department = context.Departments.SingleOrDefault(x => x.Name == "�ƾ�������ѧԺ")
            };

            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);
            context.Courses.Add(c4);
            context.Courses.Add(c5);
            context.Courses.Add(c6);
            context.SaveChanges();

            var s1 = new Student()
            {
                Name = "����Ϥ",
                Sex = false,
                Birthday = Convert.ToDateTime("1998-12-30"),
                StudentCode = "20170301032",
                Address="��������",
                Phone = "15277824247",
                Department = context.Departments.SingleOrDefault(x => x.Name == "������Ϣ����ѧԺ")
            };

            var s2 = new Student()
            {
                Name = "����",
                Sex = true,
                Birthday = Convert.ToDateTime("1998-04-05"),
                StudentCode = "20170310075",
                Address = "��������",
                Phone = "1807825465",
                Department = context.Departments.SingleOrDefault(x => x.Name == "������Ϣ����ѧԺ")
            };

            context.Student.Add(s1);
            context.Student.Add(s2);
            context.SaveChanges();
        }
    }
}
