using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_5.Migrations
{
   public class StudentSeed
    {
        public static void Seed (CourseContext context)
        {
            var stu1 = new Student()
            {
                StudentCode="0001",
                Name="小明",
                Address="光明小学",
                Birthday=DateTime.Parse("2000-01-01"),
                Phone="123456789",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")

            };

            var stu2 = new Student()
            {
                StudentCode = "0002",
                Name = "大明",
                Address = "阳光小学",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "123456789",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")

            };
            var stu3 = new Student()
            {
                StudentCode = "0003",
                Name = "小麦",
                Address = "光麦小学",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "123456789",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")

            };
            var stu4 = new Student()
            {
                StudentCode = "0004",
                Name = "大麦",
                Address = "大麦小学",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "123456789",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")

            };
            context.Student.Add(stu1);
            context.Student.Add(stu2);
            context.Student.Add(stu3);
            context.Student.Add(stu4);
            context.SaveChanges();
        }
    }
}
