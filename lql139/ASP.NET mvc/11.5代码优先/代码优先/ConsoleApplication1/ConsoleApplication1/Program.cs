using ConsoleApplication1.CodeFirstModels;
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
            var students = new CourseContext().student.OrderBy(x => x.StudentCode).ToList();
            foreach (var s in students)
                Console.WriteLine(s.Name);
            Console.ReadKey();
        }
    }
}
