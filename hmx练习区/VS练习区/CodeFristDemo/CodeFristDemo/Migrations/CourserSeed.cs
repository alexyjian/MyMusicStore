using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFristDemo.Migrations
{
    public class CourserSeed
    {
        public static void Seed(CourserContext context)
        {
            var c1 = new Course()
            {
                Title = "C#程序设计",
                Credit = 15,
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
                Title = "工业设计",
                Credit = 2,
                Department = context.Departments.SingleOrDefault(x => x.Name == "机电工程学院")

            };

            var c4 = new Course()
            {
                Title = "发动机",
                Credit = 2,
                Department = context.Departments.SingleOrDefault(x => x.Name == "机电工程学院")

            };

            var c5 = new Course()
            {
                Title = "商务英语",
                Credit = 3,
                Department = context.Departments.SingleOrDefault(x => x.Name == "财经与物流管理学院")

            };
            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);
            context.Courses.Add(c4);
            context.SaveChanges();
        }
    }
}
