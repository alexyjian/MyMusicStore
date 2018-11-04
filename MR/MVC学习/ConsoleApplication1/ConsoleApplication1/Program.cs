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
            var courses = new CourseDBEntities().Courses.ToList();

            foreach(var c in courses)
            {
                Console.WriteLine("课程名称：{0} 课程学分：{1} 所属学院：{2}", c.Title, c.Credit, c.Dapartments.Name);
            }


            Console.ReadKey();
        }
    }
}
