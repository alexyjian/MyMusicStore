using CodeFirt1108.DataContext;
using CodeFirt1108.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirt1108
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StuDBContext())
                Console.WriteLine("ef初始化");
        }
    }
}
