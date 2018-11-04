using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1027EF代码优先作业1
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new DBCoursetext();
            var courses = context.Courses.ToList();

            foreach (var c in courses)
                Console.WriteLine("课程程名程：{0} 课程学分：{1} 所属学院:{2}", c.Title, c.Credit, c.Departmnt.Name);

            //添加课程
            var c1 = new Cours()
            {
                ID = Guid.NewGuid(),
                Title = "软件工程项目组织管理",
                Credit = 17,

                //用外键的对象 一定从同一个上下文中查询
                Departmnt = context.Departmnts.SingleOrDefault(x => x.Name == "汽修学院")
            };
            var c2 = new Cours()
            {
                ID = Guid.NewGuid(),
                Title = "C#图像",
                Credit = 10,

                //用外键的对象 一定从同一个上下文中查询
                Departmnt = context.Departmnts.SingleOrDefault(x => x.Name == "汽修学院")
            };
            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.SaveChanges();


            Console.WriteLine("===================修改一门课程===================");
            var obj = context.Courses.SingleOrDefault(x => x.Title == "环境与食品学院");
            if (obj != null)
            {
                obj.Title = "C#图像";
                obj.Credit = 10;
                obj.Departmnt = context.Departmnts.SingleOrDefault(x => x.Name == "汽修学院");
                context.SaveChanges();

            }
            else
                Console.WriteLine("未找到该课程，不能修改！");

            foreach (var c in context.Courses.ToList())
                Console.WriteLine("课程程名程：{0} 课程学分：{1} 所属学院:{2}", c.Title, c.Credit, c.Departmnt.Name);




            Console.WriteLine("===================删除一门课程===================");
            var delobj = context.Courses.Find(Guid.Parse("333a51e6-339c-4e7e-8426-ff39f5a37a96"));
            context.Courses.Remove(delobj);
            context.SaveChanges();

            foreach (var c in context.Courses.ToList())
                Console.WriteLine("课程程名程：{0} 课程学分：{1} 所属学院:{2}", c.Title, c.Credit, c.Departmnt.Name);


            Console.ReadLine();
        }
    }
}
