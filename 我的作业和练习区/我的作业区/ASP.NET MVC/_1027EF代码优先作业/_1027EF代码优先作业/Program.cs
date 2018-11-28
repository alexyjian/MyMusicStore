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
            using (var context = new CuresContext())
            {


                foreach (var cou in context.Courses.ToList())
                {
                    Console.WriteLine("课程名称：{0}   课程学分：{1}    所属学院：{2}", cou.Title, cou.Credit, cou.Departments.Name);
                }
                ////添加课程  
                //Console.WriteLine("=======================添加三门课程==========================");
                //var cour1 = new Courses()
                //{
                //    ID = Guid.NewGuid(),
                //    Title = "软件工程项目组织管理",
                //    Credit = 17,
                //    Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
                //};
                //var cour2 = new Courses()
                //{
                //    ID = Guid.NewGuid(),
                //    Title = "算法与数据结构",
                //    Credit = 10,
                //    Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
                //};
                //var cour3 = new Courses()
                //{
                //    ID = Guid.NewGuid(),
                //    Title = "C#图像处理",
                //    Credit = 10,
                //    //Department_ID=context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院").ID,
                //    Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
                //};
                //context.Courses.Add(cour1);
                //context.Courses.Add(cour2);
                //context.Courses.Add(cour3);
                //context.SaveChanges();


                //修改课程
                var obj = context.Courses.SingleOrDefault(x=>x.Title=="商务英语");
                if (obj!=null) {
                    obj.Credit = 3;
                    context.SaveChanges();
                    Console.WriteLine("修改成功");
                }
                else
                {
                    Console.WriteLine("修改失败");
                }
                //刷新列表
                foreach (var cou in context.Courses.ToList())
                {
                    Console.WriteLine("课程名称：{0}   课程学分：{1}    所属学院：{2}", cou.Title, cou.Credit, cou.Departments.Name);
                }

                //删除课程
                var del = context.Courses.SingleOrDefault(x => x.Title == "商务英语");
                if (del != null)
                {
                    context.Courses.Remove(del);
                    context.SaveChanges();
                    Console.WriteLine("删除成功");
                }
                else
                {
                    Console.WriteLine("删除失败");
                }
                //刷新列表
                foreach (var cou in context.Courses.ToList())
                {
                    Console.WriteLine("课程名称：{0}   课程学分：{1}    所属学院：{2}", cou.Title, cou.Credit, cou.Departments.Name);
                }
                Console.ReadKey();
            }
        }
    }
}
