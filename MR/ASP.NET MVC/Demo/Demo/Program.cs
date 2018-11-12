using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用数据上下文进行数据操作，using表示上下文代码的范围，执行完后内存会自动释放
            using (var context = new CourseContext())
            {
                var departments = context.Departments.OrderBy(n => n.SortCode).ToList();
                foreach(var d in departments)
                    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dscn);

                Console.ReadKey();
            }
        }
    }
}
