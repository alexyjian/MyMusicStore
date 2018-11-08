using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using test1.Code;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            for(var i=0;i<=99;i++)
            {
                Student s = new Code.Student();
                Console.WriteLine(s.Name);
                Thread.Sleep(100);
            }
            Console.ReadKey();
        }
    }
}
