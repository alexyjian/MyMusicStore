namespace _11_5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_11_5.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_11_5.CourseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Database.ExecuteSqlCommand("delete students");
            context.Database.ExecuteSqlCommand("delete courses");
            context.Database.ExecuteSqlCommand("delete departments");

            StudentSeed.Seed(context);
            //初始化学院数据
            var d1 = new Department()
            {
                Name = "电子信息工程学院",
                SortCode="001",
                Description="第一大学院"
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
                Title = "MIS实战开发",
                Credit= 17,
                Department=context.Departments.SingleOrDefault(x=>x.Name == "电子信息工程学院")
            };

            var c2 = new Course()
            {
                Title = "礼仪修养",
                Credit = 13,
                Department = context.Departments.SingleOrDefault(x => x.Name == "空乘学院")
            };

            var c3 = new Course()
            {
                Title = "web实战开发",
                Credit = 17,
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };

            var c4 = new Course()
            {
                Title = "工业制图",
                Credit = 17,
                Department = context.Departments.SingleOrDefault(x => x.Name == "机电学院")
            };

            var c5 = new Course()
            {
                Title = "发动机检测",
                Credit = 17,
                Department = context.Departments.SingleOrDefault(x => x.Name == "汽车学院")
            };

            var c6 = new Course()
            {
                Title = "网络营销",
                Credit = 7,
                Department = context.Departments.SingleOrDefault(x => x.Name == "财经学院")
            };

            context.Course.Add(c1);
            context.Course.Add(c2);
            context.Course.Add(c3);
            context.Course.Add(c4);
            context.Course.Add(c5);
            context.Course.Add(c6);
            context.SaveChanges();
        }
    }
}
