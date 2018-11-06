using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1027EF代码优先作业
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var context = new CourseDBEntities();
            var Courses = context.Coures.ToList();

            foreach (var c in Courses)
                Console.WriteLine("课程名称:{0} 课程学分:{1} 所属学院：{2}", c.Title, c.Credit, c.Departments.Name);

            Console.WriteLine("======================添加三门课程===============================");
            //添加课程
            var c1 = new Coures
            {
                ID = Guid.NewGuid(),
                Title = "软件工程项目组织管理",
                Credit = 17,
                //外键的对象 一定要同一个上下文中查询
                Departments = context.Department.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c2 = new Coures
            {
                ID = Guid.NewGuid(),
                Title = "算法与数据结构",
                Credit = 2,
                //外键的对象 一定要同一个上下文中查询
                Departments = context.Department.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c3 = new Coures
            {
                ID = Guid.NewGuid(),
                Title = "C#图像处理",
                Credit = 2,
                //外键的对象 一定要同一个上下文中查询
                Departments = context.Department.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            context.Coures.Add(c1);
            context.Coures.Add(c2);
            context.Coures.Add(c3);
            context.SaveChanges();

            foreach (var c in context.Coures.ToList())
                Console.WriteLine("课程名称:{0} 课程学分:{1} 所属学院：{2}", c.Title, c.Credit, c.Departments.Name);


            Console.WriteLine("===============================修改一门课程================================");
            var obj = context.Coures.SingleOrDefault(x => x.Title == "商务英语");
            if (obj != null)
            {
                obj.Title = "计算机英语";
                obj.Credit = 4;
                obj.Departments= context.Department.SingleOrDefault(x => x.Name == "电子信息工程学院");
            }
            else
                Console.WriteLine("未找到该课程，不能修改！");

            foreach (var c in Courses)
                Console.WriteLine("课程名称:{0} 课程学分:{1} 所属学院：{2}", c.Title, c.Credit, c.Departments.Name);

            Console.WriteLine("===============================删除一门课程================================");
            var delobj = context.Coures.Find(Guid.Parse("2a6b964d-5b53-4ed4-9508-e5f56fce03c6"));
            context.Coures.Remove(delobj);
            context.SaveChanges();


            Console.ReadLine();
        }
    }
}
