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

            //初始化学院数据
            var d1 = new Department()
            {
                Name = "电子信息",
                SortCode = "001",
                Description = "NO.1"
            };
            var d2 = new Department()
            {
                Name = "汽车工程",
                SortCode = "002",
                Description = "NO.2"
            };
            var d3 = new Department()
            {
                Name = "环食旅游",
                SortCode = "003",
                Description = "NO.3"
            };
            context.Department.Add(d1);
            context.Department.Add(d2);
            context.Department.Add(d3);
            context.SaveChanges();

            var c1 = new Course()
            {
                Title = "C#程序设计",
                Credit = 7,
                Department = context.Department.SingleOrDefault(x => x.Name == "电子信息")
            };
            var c2 = new Course()
            {
                Title = "MIS",
                Credit = 7,
                Department = context.Department.SingleOrDefault(x => x.Name == "电子信息")
            };
            var c3 = new Course()
            {
                Title = "发动机检测",
                Credit = 7,
                Department = context.Department.SingleOrDefault(x => x.Name == "汽车工程")
            };
            var c4 = new Course()
            {
                Title = "食品检测",
                Credit = 7,
                Department = context.Department.SingleOrDefault(x => x.Name == "环食旅游")
            };
            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);
            context.Courses.Add(c4);
            context.SaveChanges();

            var s1 = new Student()
            {
                Name = "梁伟杰1",
                Sex = true,
                StudentCode = "111",
                Age = 18,
                Department = context.Department.SingleOrDefault(x => x.Name == "电子信息")
            };
            var s2 = new Student()
            {
                Name = "梁伟杰2",
                Sex = true,
                StudentCode = "112",
                Age = 18,
                Department = context.Department.SingleOrDefault(x => x.Name == "电子信息")
            };
            var s3 = new Student()
            {
                Name = "梁伟杰3",
                Sex = true,
                StudentCode = "113",
                Age = 18,
                Department = context.Department.SingleOrDefault(x => x.Name == "电子信息")
            };
            var s4 = new Student()
            {
                Name = "梁伟杰4",
                Sex = true,
                StudentCode = "114",
                Age = 18,
                Department = context.Department.SingleOrDefault(x => x.Name == "电子信息")
            };
            var s5 = new Student()
            {
                Name = "梁伟杰5",
                Sex = true,
                StudentCode = "115",
                Age = 18,
                Department = context.Department.SingleOrDefault(x => x.Name == "电子信息")
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
