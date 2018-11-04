using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denol
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个数据的上下文，所有的表的实体都会在此上下文中
            //var context = new CourseDBEntities();
            //var departments = context.Departments.OrderBy(x=>x.SortCode).ToList();
            //var courses = context.Courses.OrderBy(x => x.ID).ToList();
            //foreach (var d in departments)
            //    Console.WriteLine("{0}:{1}", d.SortCode, d.Name);

            //foreach (var d in courses)
            //    Console.WriteLine("课程名称:{0},课程学分:{1}", d.Title, d.Credit);

            //Console.ReadKey();

            using (var context = new CourseDBEntities())
            {
                // .where .orderby .tolist() 注意顺序

                var departments = context.Departments.Where(n=>n.Name.Contains("工程")).OrderBy(n => n.SortCode).ToList();
                
                foreach (var d in departments)
                {
                    Console.WriteLine("编号{0},部门{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                }
                //aasd
                Console.ReadKey();
            }
        }
    }
}
