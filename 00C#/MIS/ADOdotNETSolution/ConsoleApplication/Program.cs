using DBAUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            var result = user.AddUser("12345678", "张三", "123", 1, "zhangshan@163.com", 
                "2016软件技术1班");
            if (result)
                Console.WriteLine("添加成功！");
            else
                Console.WriteLine("添加失败！");
            Console.ReadKey();
        }
    }
}
