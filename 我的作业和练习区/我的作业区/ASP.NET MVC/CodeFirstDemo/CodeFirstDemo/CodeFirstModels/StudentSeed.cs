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
            var s1 = new Student()
            {
                StudentCode = "123456",
                Name = "孙大头",
                Sex = true,
                Birthday = DateTime.Now,
                Phone = "123456789",
                Address = "天上",
                Department = context.Departments.SingleOrDefault(x => x.Name == "机电工程学院")
            };
            var s2 = new Student()
            {
                StudentCode = "123457",
                Name = "孙小头",
                Sex = true,
                Birthday = DateTime.Now,
                Phone = "123456789",
                Address = "天上",
                Department = context.Departments.SingleOrDefault(x => x.Name == "机电工程学院")
            };
            var s3 = new Student()
            {
                StudentCode = "123458",
                Name = "孙巨头",
                Sex = true,
                Birthday = DateTime.Now,
                Phone = "123456789",
                Address = "天上",
                Department = context.Departments.SingleOrDefault(x => x.Name == "机电工程学院")
            };
            var s4 = new Student()
            {
                StudentCode = "123459",
                Name = "孙微头",
                Sex = true,
                Birthday = DateTime.Now,
                Phone = "123456789",
                Department = context.Departments.SingleOrDefault(x => x.Name == "机电工程学院")
            };
            var s5 = new Student()
            {
                StudentCode = "12345",
                Name = "孙特头",
                Sex = true,
                Birthday = DateTime.Now,
                Phone = "123456789",
                Address = "天上",
                Department = context.Departments.SingleOrDefault(x => x.Name == "机电工程学院")
            };
            context.Students.Add(s1);
            context.Students.Add(s2);
            context.Students.Add(s3);
            context.Students.Add(s4);
            context.Students.Add(s5);
            context.SaveChanges();
        }
    }
}
