using CodeFirstDemo.CodeFirstModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.CodeFirstModels
{
   public class StudentSeed
    {
        public static void Seed(CourseContext context)
        {
            var stu1 = new Student()
            {
                StudentCode = "0001",
                Name = "秦君",
                Address = "天帝神殿",
                Birthday = DateTime.Parse("1999-07-3"),
                Phone = "135484",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var stu2 = new Student()
            {
                StudentCode = "0002",
                Name = "苏逸",
                Address = "荒古",
                Birthday = DateTime.Parse("1999-07-3"),
                Phone = "1394845415",
                Department = context.Departments.SingleOrDefault(x => x.Name == "机电工程学院")
            };
            var stu3 = new Student()
            {
                StudentCode = "0003",
                Name = "姬永生",
                Address = "混沌",
                Birthday = DateTime.Parse("1999-07-3"),
                Phone = "1354844541",
                Department = context.Departments.SingleOrDefault(x => x.Name == "汽车工程学院")
            };
            var stu4 = new Student()
            {
                StudentCode = "0004",
                Name = "极帝",
                Address = "混沌",
                Birthday = DateTime.Parse("1999-07-3"),
                Phone = "135454684",
                Department = context.Departments.SingleOrDefault(x => x.Name == "财经与物流学院")
            };

            context.Students.Add(stu1);
            context.Students.Add(stu2);
            context.Students.Add(stu3);
            context.Students.Add(stu4);
            context.SaveChanges();
        }
     }
}
