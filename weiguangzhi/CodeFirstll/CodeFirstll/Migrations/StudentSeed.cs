using CodeFirstll.CodeFirstModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CodeFirstll.Migrations
{
    public class StudentSeed
    {
        public static void Seed(CourseContext context)
        {
            var stu1 = new Student()
            {
                StudentCode = "0001",
                Name = "无言组",
                Address = "武当山",
                Birthday = DateTime.Parse("2018-01-01"),
                Phone = "1111111",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")

            };
        }
    }
}
