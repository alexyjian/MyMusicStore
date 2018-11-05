using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CourseDBEntities();
            var courses = new CourseDBEntities().Courses.ToList();

            foreach(var c in courses)
            {
                Console.WriteLine("课程名称：{0} 课程学分：{1} 所属学院：{2}", c.Title, c.Credit, c.Dapartments.Name);
            }
            //添加课程
            var c1 = new Courses()
            {
                ID = Guid.NewGuid(),
                Title = "软件工程项目组织管理",
                Credit = 17,
                Dapartments = context.Dapartments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            context.Courses

            Console.ReadKey();
        }
    }
}
