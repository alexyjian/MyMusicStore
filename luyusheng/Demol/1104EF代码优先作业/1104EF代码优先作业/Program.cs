using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1104EF代码优先作业
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new DBContext().Coures.ToList();
            foreach (var c in courses)
                Console.WriteLine("课程名称:{0} 课程学分:{1} 所属学院:{2}", c.Title, c.Credit, c.Department.Name);
            //添加课程
            var c1 = new Coures()
            {
                ID = Guid.NewGuid(),
                Title = "软件工程项目组织管理",
                Credit = 17,
            };
            Console.ReadLine();

        }
    }
}
