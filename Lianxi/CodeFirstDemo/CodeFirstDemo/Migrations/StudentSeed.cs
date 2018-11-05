using CodeFirstDemo.CodeFirstModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Migrations
{
 public   class StudentSeed

    {
        public static void Seed(CourseContext context)
        {
            var stu1 = new Student()
            {
                StudentCode = "0002",
                Name = "Baby",
                Address = "加多宝",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "13833883388",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            context.Students.Add(stu1);
        }
    }
}
