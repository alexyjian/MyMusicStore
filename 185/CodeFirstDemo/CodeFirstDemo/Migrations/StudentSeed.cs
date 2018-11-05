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
                Phone = "13656565656",
                Department = context.Department.SingleOrDefault(x => x.Name == "电子信息工程学院"),
            };
            var stu2 = new Student()
            {
                StudentCode = "0002",
                Name = "赵敏",
                Address = "汝阳王府",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "13656565656",
                Department = context.Department.SingleOrDefault(x => x.Name == "汽车工程学院"),
            };
            var stu3 = new Student()
            {
                StudentCode = "0003",
                Name = "灭绝",
                Address = "不知道",
                Birthday = DateTime.Parse("2000-05-01"),
                Phone = "13656565656",
                Department = context.Department.SingleOrDefault(x => x.Name == "电子信息工程学院"),
            };
            var stu4 = new Student()
            {
                StudentCode = "0004",
                Name = "陈大大",
                Address = "不计",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "13656565656",
                Department = context.Department.SingleOrDefault(x => x.Name == "财经与旅游程学院"),
            };
            var stu5 = new Student()
            {
                StudentCode = "0005",
                Name = "略略略",
                Address = "哈哈哈",
                Birthday = DateTime.Parse("2004-01-01"),
                Phone = "13656565656",
                Department = context.Department.SingleOrDefault(x => x.Name == "机电工程程学院"),
            };
            context.Student.Add(stu1);
            context.Student.Add(stu2);
            context.Student.Add(stu3);
            context.Student.Add(stu4);
            context.Student.Add(stu5);
            context.SaveChanges();


        }
    }
}
