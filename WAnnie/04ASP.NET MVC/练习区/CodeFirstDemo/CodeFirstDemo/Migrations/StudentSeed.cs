using CodeFirstDemo.CodeFirstNodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Migrations
{
  public  class StudentSeed
    {
        public static void Seed(CourseContext context)
        {
            //初始化学生信息
            var stu1 = new Student()
            {
                Name="小杰",
                StudentCode="20170310099",
                Address ="北京",
                Birthday = DateTime.Parse("1982-12-20"),
                Phone = "888978999",
                Department=context.Departments.SingleOrDefault(x=>x.Name == "电子信息工程学院")
            };
            var stu2= new Student()
            {
                Name = "小娜",
                StudentCode = "20170310088",
                Address = "北京",
                Birthday = DateTime.Parse("1981-06-05"),
                Phone = "88896688999",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var stu3 = new Student()
            {
                Name = "小炅",
                StudentCode = "20170310089",
                Address = "北京",
                Birthday = DateTime.Parse("1978-10-20"),
                Phone = "6666898999",
                Department = context.Departments.SingleOrDefault(x => x.Name == "财经与物流学院")
            };
            var stu4= new Student()
            {
                Name = "小旋",
                StudentCode = "20170310889",
                Address = "北京",
                Birthday = DateTime.Parse("1999-8-28"),
                Phone = "15949369513",
                Department = context.Departments.SingleOrDefault(x => x.Name == "艺术学院")
            };
            var stu5 = new Student()
            {
                Name = "小妮",
                StudentCode = "20170310070",
                Address = "广西",
                Birthday = DateTime.Parse("1999-03-13"),
                Phone = "13471898998",
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
