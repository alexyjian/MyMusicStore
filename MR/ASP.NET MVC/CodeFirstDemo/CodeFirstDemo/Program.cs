using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstDemo.CodeFirstMadels;

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new CourseContext())
            //{
            //    Console.WriteLine("ef初始化");
            //}
            var studens = new CourseContext().Student.OrderBy(x => x.StudentCode).ToList();
            foreach(var s in studens)
            {
                Console.WriteLine(s.Name);
                Console.WriteLine(s.Sex);
                Console.WriteLine(s.ID);
            };

            Console.Read();
        }
    }
}
