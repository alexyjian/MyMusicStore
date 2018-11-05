using ConsoleApplication1.CodeFirstModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Migrations
{
   public class studentSeed
    {
        public static void Seed(CourseContext context)
        {
            var x1 = new student()
            {
                StudentCode = "001",
                Name = "黎涛",
                Birthday = DateTime.Parse("2000-5-20"),
                ADDdress = "太阳系",
                Phone = "110",
                Sex = true,
                Department = context.Department.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var x2 = new student()
            {
                StudentCode = "002",
                Name = "马思维",
                Birthday = DateTime.Parse("2000-6-6"),
                ADDdress = "地球",
                Phone = "10086",
                Sex = true,
                Department = context.Department.SingleOrDefault(x => x.Name == "艺术学院")

            };
            var x3 = new student()
            {
                StudentCode = "003",
                Name = "迪丽热巴",
                Birthday = DateTime.Parse("2000-1-1"),
                ADDdress = "我家",
                Phone = "隐私",
                Sex = false,
                Department = context.Department.SingleOrDefault(x => x.Name == "机电工程学院")
            };
            var x4 = new student()
            {
                StudentCode = "004",
                Name = "孙悟空",
                Birthday = DateTime.Parse("1999-9-9"),
                ADDdress = "宇宙",
                Phone = "语音",
                Sex = true,
                Department = context.Department.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            context.student.Add(x1);
            context.student.Add(x2);
            context.student.Add(x3);
            context.student.Add(x4);
            context.SaveChanges();
        }
    }
}
