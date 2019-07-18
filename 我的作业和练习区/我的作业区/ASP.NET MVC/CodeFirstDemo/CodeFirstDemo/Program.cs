using CodeFirstDemo.CodeFirstModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var stu= new CourseContext().Students.OrderBy(x => x.StudentCode).ToList();
            foreach (var s in stu)
                Console.WriteLine("学号：{0}",s.StudentCode);
            Console.ReadKey();
        }
    }
}
