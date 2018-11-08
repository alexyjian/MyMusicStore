using ConsoleApplication2.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
public    class Program
    {
       static void Main(string[] args)
        {
            static void Main(string[] args)
        {
                for (var i = 0; i < 10; i++)
                {
                    var fname = "";
                    var lname = "";
                    Console.WriteLine(StudentSeed._GetRandomChineseFullName(ref fname, ref lname));
                    Thread.Sleep(3);
                }
            }

        }
    }
}
