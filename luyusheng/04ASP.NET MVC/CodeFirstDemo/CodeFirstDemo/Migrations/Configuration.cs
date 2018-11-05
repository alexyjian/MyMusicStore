namespace CodeFirstDemo.Migrations
{
    using CodeFirstModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstDemo.CodeFirstModels.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        //种子方法
        protected override void Seed(CodeFirstDemo.CodeFirstModels.CourseContext context)
        {
            //初始化学院数据
            var d1 = new Dopartment()
            {
                Name = "电子信息工程学院",
                SortCode = "001",
                Description = "第一大学院"
            };
            var d2 = new Dopartment()
            {
                Name = "机电工程学院",
                SortCode = "002",
                Description = "第二大学院"
            };
            var d3 = new Dopartment()
            {
                Name = "汽车工程学院",
                SortCode = "003",
                Description = "第三大学院"
            };
            var d4 = new Dopartment()
            {
                Name = "财经与物流程学院",
                SortCode = "004",
                Description = "第四大学院"
            };
            
            context.Dopartments.Add(d1);
            context.Dopartments.Add(d2);
            context.Dopartments.Add(d3);
            context.Dopartments.Add(d4);
            context.SaveChanges();

            var c1 = new Course()
            {
                Title = "C#程序设计",
                Credit = 7,
                Dopartment = context.Dopartments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c2= new Course()
            {
                Title = "MIS开发实战",
                Credit = 17,
                Dopartment = context.Dopartments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c3 = new Course()
            {
                Title = "WEB应用与开发",
                Credit = 17,
                Dopartment = context.Dopartments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c4 = new Course()
            {
                Title = "工业制图",
                Credit = 4,
                Dopartment = context.Dopartments.SingleOrDefault(x => x.Name == "机电工程学院")
            };
            var c5 = new Course()
            {
                Title = "发动机检测",
                Credit = 6,
                Dopartment = context.Dopartments.SingleOrDefault(x => x.Name == "汽车工程学院")
            };
            var c6 = new Course()
            {
                Title = "网络营销",
                Credit = 6,
                Dopartment = context.Dopartments.SingleOrDefault(x => x.Name == "财经与物流工程学院")
            };
            context.Courses.Add(cl);
            context.Courses.Add(c2);
            context.Courses.Add(c3);
            context.Courses.Add(c4);
            context.Courses.Add(c5);
            context.Courses.Add(c6);
            context.SaveChanges();
        }
    }
}
