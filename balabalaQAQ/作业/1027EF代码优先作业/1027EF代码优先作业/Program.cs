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


            //添加
            var context = new CourseDBEntities();
            var courseDB = context.Courses.ToList();
            var DB = new Courses()
            {
                ID = Guid.NewGuid(),
                Title = "做作业",
                Credit = "009",
                Department_ID = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院").ID
                };
            context.Courses.Add(DB);
            context.SaveChanges();

            //修改
            var editCourese = context.Courses.SingleOrDefault(n => n.Title == "做作业");
            if (editCourese != null)
            {
                editCourese.Title = "做作业啦";
                editCourese.Credit = "00J";
                context.SaveChanges();
            }
            else
            {
                Console.Write("没有该记录，无法修改！");
            }

            //删除
            var delCourese = context.Courses.Find(Guid.Parse(""));
            context.Courses.Remove(DB);
            context.SaveChanges();

            //查询
            foreach (var c in courseDB)
                    Console.WriteLine("课程名称：{0} 课程学分：{0} 课程ID：{0}", c.Title, c.Credit, c.Department_ID);
                Console.ReadKey();
            
        }
    }
}
