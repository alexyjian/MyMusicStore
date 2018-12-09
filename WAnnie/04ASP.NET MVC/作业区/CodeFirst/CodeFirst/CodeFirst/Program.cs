using CodeFirst.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            for(var i =0; i<10; i++)
            {
                var fname = "";
                var lname = "";
                Console.WriteLine(StudentSeed._GetRandomChineseFullName(ref fname, ref lname));
                Thread.Sleep(5);
            }
            Console.ReadKey();
        }
    }
}
