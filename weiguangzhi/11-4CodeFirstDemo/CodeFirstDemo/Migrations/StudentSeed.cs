using CodeFirstDemo.CodeFirstModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Migrations
{
    public class StudentSeed
    {
        public static void Seed(CourseContext context)
        {
            var stu1 = new Student()
            {
                StudentCode = "0001",
                Name = "张翠山",
                Address = "武当山",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "13833883388",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var stu2 = new Student()
            {
                StudentCode = "0002",
                Name = "谢逊",
                Address = "空洞",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "13833883399",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var stu3 = new Student()
            {
                StudentCode = "0003",
                Name = "赵敏",
                Address = "汝阳王府",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "13833883377",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var stu4 = new Student()
            {
                StudentCode = "0004",
                Name = "灭绝",
                Address = "峨眉山",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "13833881188",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var stu5 = new Student()
            {
                StudentCode = "0005",
                Name = "成昆",
                Address = "空洞",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "13833993388",
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
