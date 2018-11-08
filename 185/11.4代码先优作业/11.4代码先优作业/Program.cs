using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._4代码先优作业
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CourseDBEntities();
            var courses = context.dbo_Courses.ToList();

            foreach (var c in courses)
                Console.WriteLine("课程名称：{0}课程学分{1} 所属学院：{2}", c.Title, c.Credit, c.Departent_ID);
            //Console.WriteLine("=======================添加三门课程===============================");
            ////添加课程
            //var c1 = new dbo_Courses()
            //{
            //    ID = Guid.NewGuid(),
            //    Title = "软件工程项目组织管理",
            //    Credit = 17,
            //    //外间的对象 一定要从同一个上下文中查询
            //    dbo_Departnents = context.dbo_Departnents.SingleOrDefault(x => x.Name == "电子信息工程学院")
            //};
            //var c2 = new dbo_Courses()
            //{
            //    ID = Guid.NewGuid(),
            //    Title = "算法与数据结构",
            //    Credit = 2,
            //    //外间的对象 一定要从同一个上下文中查询
            //    dbo_Departnents = context.dbo_Departnents.SingleOrDefault(x => x.Name == "电子信息工程学院")
            //};
            //var c3 = new dbo_Courses()
            //{
            //    ID = Guid.NewGuid(),
            //    Title = "C#图像处理",
            //    Credit = 2,
            //    //外键的对象 一定要从同一个上下文中查询
            //    dbo_Departnents = context.dbo_Departnents.SingleOrDefault(x => x.Name == "电子信息工程学院")
            //};
            //context.dbo_Courses.Add(c1);
            //context.dbo_Courses.Add(c2);
            //context.dbo_Courses.Add(c3);
            //context.SaveChanges();

            //foreach (var c in context.dbo_Courses.ToList())
            //    Console.WriteLine("课程名称：{0}  课程学分:{1}  所属学院:{2}", c.Title, c.Credit, c.Departent_ID);

            //Console.WriteLine("==================修改一门课程====================");
            //var obj = context.dbo_Courses.SingleOrDefault(x => x.Title == "商务英语");
            //if (obj != null)
            //{
            //    obj.Title = "计算机英语";
            //    obj.Credit = 4;
            //    obj.dbo_Departnents = context.dbo_Departnents.SingleOrDefault(x => x.Name == "电子信息工程学院");
            //    context.SaveChanges();
            //}
            //else
            //    Console.WriteLine("未找该课程，不能修改!");

            //foreach (var c in context.dbo_Courses.ToList())
            //    Console.WriteLine("课程名称：{0}  课程学分:{1}  所属学院:{2}", c.Title, c.Credit, c.Departent_ID);

            Console.WriteLine("==================删除一门课程====================");
            var delobj = context.dbo_Courses.Find(Guid.Parse("74e6755d-4a26-43c4-911b-90f07ddaf08c"));
            context.dbo_Courses.Remove(delobj);
            context.SaveChanges();

            foreach (var c in context.dbo_Courses.ToList())
                Console.WriteLine("课程名称：{0}  课程学分:{1}  所属学院:{2}", c.Title, c.Credit, c.Departent_ID);

            
            Console.ReadLine();
        }
    }
}
