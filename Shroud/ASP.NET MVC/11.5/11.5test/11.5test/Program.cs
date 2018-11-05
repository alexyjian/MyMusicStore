using _11._5test.CodefirstModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._5test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var content=new CourseContext())
            {
                var data = content.Department.ToList();
                foreach(var d in data)
                {
                    Console.WriteLine(d.Name);
                }
                Console.ReadKey();
            }
        }
    }
}
