using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018._11._4_EF代码优先作业2
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CourseContext();
            var courses = context.Courses.ToList();
            foreach (var c in courses)
                Console.WriteLine("课程名称：{0} 课程学分：{1} 所属学院：{2} ", c.Title, c.Credit, c.Departments.Name);

            Console.WriteLine("================添加四门课程===============");
            //添加课程
            var c1 = new Courses()
            {
                ID = Guid.NewGuid(),
                Title = "软件工程项目组织管理",
                Credit = 18,
                //外键的对象一定要从同一个上下文中查询
                Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c2 = new Courses()
            {

                ID = Guid.NewGuid(),
                Title = "算法与数据结构",
                Credit = 3,
                //外键的对象一定要从同一个上下文中查询
                Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c3 = new Courses()
            {

                ID = Guid.NewGuid(),
                Title = "软件工程项目",
                Credit = 13,
                //外键的对象一定要从同一个上下文中查询
                Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c4 = new Courses()
            {

                ID = Guid.NewGuid(),
                Title = "C#图像处理",
                Credit = 5,
                //外键的对象一定要从同一个上下文中查询
                Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);
            context.Courses.Add(c4);
            context.SaveChanges();

            //Console.WriteLine("================修改课程===============");


            foreach (var c in context.Courses.ToList())
                Console.WriteLine("课程名称：{0} 课程学分：{1} 所属学院：{2} ", c.Title, c.Credit, c.Departments.Name);

            Console.ReadLine();

        }
    }
}
