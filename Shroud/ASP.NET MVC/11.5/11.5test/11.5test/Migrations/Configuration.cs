namespace _11._5test.Migrations
{
    using CodefirstModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_11._5test.CodefirstModels.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_11._5test.CodefirstModels.CourseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Database.ExecuteSqlCommand("delete Student");
            context.Database.ExecuteSqlCommand("delete Courses");
            context.Database.ExecuteSqlCommand("delete Departments");

            //��ʼ��ѧԺ����
            var d1 = new Department()
            {
                Name = "������Ϣ",
                SortCode = "001",
                Description = "NO.1"
            };
            var d2 = new Department()
            {
                Name = "��������",
                SortCode = "002",
                Description = "NO.2"
            };
            var d3 = new Department()
            {
                Name = "��ʳ����",
                SortCode = "003",
                Description = "NO.3"
            };
            context.Department.Add(d1);
            context.Department.Add(d2);
            context.Department.Add(d3);
            context.SaveChanges();

            var c1 = new Course()
            {
                Title = "C#�������",
                Credit = 7,
                Department = context.Department.SingleOrDefault(x => x.Name == "������Ϣ")
            };
            var c2 = new Course()
            {
                Title = "MIS",
                Credit = 7,
                Department = context.Department.SingleOrDefault(x => x.Name == "������Ϣ")
            };
            var c3 = new Course()
            {
                Title = "���������",
                Credit = 7,
                Department = context.Department.SingleOrDefault(x => x.Name == "��������")
            };
            var c4 = new Course()
            {
                Title = "ʳƷ���",
                Credit = 7,
                Department = context.Department.SingleOrDefault(x => x.Name == "��ʳ����")
            };
            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);
            context.Courses.Add(c4);
            context.SaveChanges();

            var s1 = new Student()
            {
                Name = "��ΰ��1",
                Sex = true,
                StudentCode = "111",
                Age = 18,
                Department = context.Department.SingleOrDefault(x => x.Name == "������Ϣ")
            };
            var s2 = new Student()
            {
                Name = "��ΰ��2",
                Sex = true,
                StudentCode = "112",
                Age = 18,
                Department = context.Department.SingleOrDefault(x => x.Name == "������Ϣ")
            };
            var s3 = new Student()
            {
                Name = "��ΰ��3",
                Sex = true,
                StudentCode = "113",
                Age = 18,
                Department = context.Department.SingleOrDefault(x => x.Name == "������Ϣ")
            };
            var s4 = new Student()
            {
                Name = "��ΰ��4",
                Sex = true,
                StudentCode = "114",
                Age = 18,
                Department = context.Department.SingleOrDefault(x => x.Name == "������Ϣ")
            };
            var s5 = new Student()
            {
                Name = "��ΰ��5",
                Sex = true,
                StudentCode = "115",
                Age = 18,
                Department = context.Department.SingleOrDefault(x => x.Name == "������Ϣ")
            };
            context.Students.Add(s1);
            context.Students.Add(s2);
            context.Students.Add(s3);
            context.Students.Add(s4);
            context.Students.Add(s5);
            context.SaveChanges();
        }
    }
}
