using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1104代码优先作业
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new DBContext().Coures.ToList();
            foreach (var c in courses)
                Console.WriteLine("课程名称:{0} 课程学分:{1} 所属学院:{2}", c.Title, c.Credit, c.Department.Name);
            //添加课程
            var cl = new Coures()
            {
                ID = Guid.NewGuid(),
                Title ="软件工程项目组织管理",
                Credit =17,
                //外键的对象一定要从同一个上下文中查询
                Department =context.Departments.SingleOrDefault(x=> x.Name =="电子信息工程学院")
            };
            var c2 = new Coures()
            {
                ID = Guid.NewGuid(),
                Title = "算法与数据结构",
                Credit = 2,
                //外键的对象一定要从同一个上下文中查询
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c3 = new Coures()
            {
                ID = Guid.NewGuid(),
                Title = "C#图像处理",
                Credit = 12,
                //外键的对象一定要从同一个上下文中查询
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };

            Console.ReadLine();
        }
    }
}
