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
            using(var context=new CuresContext())
            {
                foreach(var dep in context.Departments.OrderBy(x => x.SortCode).ToList())
                {
                    Console.WriteLine("{0}   {1}    {2}",dep.Name,dep.SortCode,dep.Dscn);
                }
                //添加一条纪录
                Console.WriteLine("添加一条纪录");
                var adddep = new Departments() {
                    ID = Guid.Parse("08693647-b635-4a8d-a734-b6ba8f9da479"),
                    Name="电竞与战略学院",
                    Dscn="就是专门打游戏的学校",
                    SortCode="010"
                };
                context.Departments.Add();
                Console.ReadKey();
            }
        }
    }
}
