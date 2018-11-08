using _1000Student.DataContext;
using _1000Student.Entities;
using _1000Student.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000Student
{
    class Program
    {
        static void Main(string[] args)
        {
            ////创建上下文
            //CodeFirstContext dbcontext = new CodeFirstContext();
            ////创建数据库
            //dbcontext.Database.CreateIfNotExists();
            //创建表，并将字段加入进去
            //User u = new User();
            //u.Name = "wang";
            //u.Id = 1;
            //Card c = new Card();
            //c.CardName = "lei";
            //c.Id = 1;
            ////将实体赋予上下文，并添加到表里
            //dbcontext.User.Add(u);
            ////保存
            //dbcontext.SaveChanges();
            //Console.WriteLine("成功创建数据库和表");
            //Console.ReadKey();
            //---------------------
            //作者：AresCarry
            //来源：CSDN
            //原文：https://blog.csdn.net/kisscatforever/article/details/51442449 
            //版权声明：本文为博主原创文章，转载请附上博文链接！
            //StuDBContext context = new StuDBContext();
            //StudentSeed.Seed(context);
        }
    }
}
