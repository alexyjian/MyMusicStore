using CodeFristDemo.CodeFirstModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFristDemo.Migrations
{
  public  class StudentSeed
    {
        public static void Seed(CourseContext context)
        {
            var stu1 = new Student()
            {
                StudentCode = "20170301032",
                Name = "赵丽颖",
                Address = "赵小刀",
                Birthday = DateTime.Parse("1993-11-16"),
                Phone = "1527782424765",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };

            var stu2 = new Student()
            {
                StudentCode = "20170301033",
                Name = "黄美悉",
                Address = "黄美xi",
                Birthday = DateTime.Parse("1993-11-16"),
                Phone = "15274564247",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };

            var stu3= new Student()
            {
                StudentCode = "20170301034",
                Name = "黄美丽",
                Address = "赵小刀",
                Birthday = DateTime.Parse("1993-11-16"),
                Phone = "1527742424765",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };

            var stu4 = new Student()
            {
                StudentCode = "20170301035",
                Name = "李四",
                Address = "赵小刀",
                Birthday = DateTime.Parse("1993-11-16"),
                Phone = "1527562424765",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };

            var stu5 = new Student()
            {
                StudentCode = "20170301036",
                Name = "张三",
                Address = "赵小刀",
                Birthday = DateTime.Parse("1993-11-16"),
                Phone = "1527782824765",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            context.Students.Add(stu1);
            context.Students.Add(stu2);
            context.Students.Add(stu3);
            context.Students.Add(stu4);
            context.Students.Add(stu5);
            context.SaveChanges();
        }
    }
}
