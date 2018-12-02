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
            var context = new DBContext();
            var courses = new DBContext().Courses.ToList();

            foreach (var c in courses)
                Console.WriteLine("课程名称:{0} 课程学分:{1} 所属学院:{2}", c.Tile, c.Credit, c.Departments.Name);

            //Console.WriteLine("===========添加2门课程===============");
            ////添加课程
            //var c1 = new Courses()
            //{
            //    ID = Guid.NewGuid(),
            //    Tile = "软件工程项目组织管理",
            //    Credit = 17,
            //    //外键的对象一定要从同一个上下文查询
            //    Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            //};

            //var c2 = new Courses()
            //{
            //    ID = Guid.NewGuid(),
            //    Tile = "算法与数据结构",
            //    Credit = 2,
            //    //外键的对象一定要从同一个上下文查询
            //    Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            //};
            //context.Courses.Add(c1);
            //context.Courses.Add(c2);
            //context.SaveChanges();

            //修改课程
            Console.WriteLine("===========修改1门课程===============");
            var obj = context.Courses.SingleOrDefault(x => x.Tile == "商务英语");
            if (obj != null)
            {
                obj.Tile = "计算机英语";
                obj.Credit = 4;
                obj.Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院");
                context.SaveChanges();
            }
            else
                Console.WriteLine("未找到该课程，不能修改!");
            foreach (var c in context.Courses.ToList())
                Console.WriteLine("课程名称:{0} 课程学分:{1} 所属学院:{2}", c.Tile, c.Credit, c.Departments.Name);



            //删除课程
            Console.WriteLine("===========删除1门课程===============");
            var delobj = context.Courses.Find(Guid.Parse("00bd0515-59ea-4c9a-bc2e-8ada025528eb"));
            context.Courses.Remove(delobj);
            context.SaveChanges();

            foreach (var c in context.Courses.ToList())
                Console.WriteLine("课程名称:{0} 课程学分:{1} 所属学院:{2}", c.Tile, c.Credit, c.Departments.Name);


            Console.ReadLine();
        }
    }
}
