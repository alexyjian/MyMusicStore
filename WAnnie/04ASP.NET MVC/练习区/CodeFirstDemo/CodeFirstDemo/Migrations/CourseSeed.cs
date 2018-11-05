using CodeFirstDemo.CodeFirstNodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Migrations
{
  public  class CourseSeed
    {
        public static void Seed(CourseContext context)
        {
            //初始化课程
            context.Database.ExecuteSqlCommand("delete courses");
            var c1 = new Course()
            {
                Title = "C#程序设计",
                Credit = 7,
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c2 = new Course()
            {
                Title = "WEB应用与开发",
                Credit = 17,
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c3 = new Course()
            {
                Title = "MIS应用与实战开发",
                Credit = 17,
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c4 = new Course()
            {
                Title = "工业制图",
                Credit = 2,
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
            var c7 = new Course()
            {
                Title = "室内设计",
                Credit = 8,
                Department = context.Departments.SingleOrDefault(x => x.Name == "艺术学院")
            };
            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);
            context.Courses.Add(c4);
            context.Courses.Add(c5);
            context.Courses.Add(c6);
            context.Courses.Add(c7);
            context.SaveChanges();
        }
    }
}
