using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demmo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建数据的上下文， 所有的表的实体在此上下文
            using (var context = new CourseDBEntities())
            {
                //注意调用的顺序 .where .orderby .tolist()
                var departments = context.Departmnts.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments)
                    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dscn);

                Console.ReadKey();



            }
        }
    }
}
