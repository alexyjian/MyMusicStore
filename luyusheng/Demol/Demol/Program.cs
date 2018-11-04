using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demol
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CourseDBEntities1())
            {
                //使用数据上下文进行数据操作，using表示上下文代码的范围，执行完后内存会自动释放
                var departments = context.Department.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments)
                    Console.WriteLine("编号:{0},部门名称:{1},说明{2}",d.SortCode,d.Name,d.Dscn);
                Console.ReadKey();
            }
        }
    }
}
