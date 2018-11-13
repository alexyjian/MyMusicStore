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
                Name = "电子信息工程学院",
                SortCode = "001",
                Description = "第一大学院"
            };

            var d2 = new Department()
            {
                Name = "机电工程学院",
                SortCode = "002",
                Description = "第二大学院"
            };

            var d3 = new Department()
            {
                Name = "汽车工程学院",
                SortCode = "003",
                Description = "第三大学院"
            };

            var d4 = new Department()
            {
                Name = "财经与物流学院",
                SortCode = "004",
                Description = "第四大学院"
            };

            context.Departments.Add(d1);
            context.Departments.Add(d2);
            context.Departments.Add(d3);
            context.Departments.Add(d4);
            context.SaveChanges();

         
            var c1 = new Course()
            {
                Title = "C#程序设计",
                Credit = 7,
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };

            var c2 = new Course()
            {
                Title = "MIS开发实战",
                Credit = 15,
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };

            var c3 = new Course()
            {
                Title = "WEB应用与开发",
                Credit = 17,
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };

            var c4 = new Course()
            {
                Title = "工业制图",
                Credit = 7,
                Department = context.Departments.SingleOrDefault(x => x.Name == "机电工程学院")
            };

            var c5 = new Course()
            {
                Title = "发动机检测",
                Credit = 6,
                Department = context.Departments.SingleOrDefault(x => x.Name == "汽车工程学院")
            };

            var c6 = new Course()
            {
                Title = "网络营销",
                Credit = 6,
                Department = context.Departments.SingleOrDefault(x => x.Name == "财经与物流学院")
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
                Name = "黄美悉",
                Sex = false,
                Birthday = Convert.ToDateTime("1998-12-30"),
                StudentCode = "20170301032",
                Address="广西都安",
                Phone = "15277824247",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };

            var s2 = new Student()
            {
                Name = "蒙仁",
                Sex = true,
                Birthday = Convert.ToDateTime("1998-04-05"),
                StudentCode = "20170310075",
                Address = "广西都安",
                Phone = "1807825465",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };

            context.Student.Add(s1);
            context.Student.Add(s2);
            context.SaveChanges();
        }
    }
}
