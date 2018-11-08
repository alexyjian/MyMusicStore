using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new OneLibraryEntities())
            {
                var newContext = new TBL_BookInfo
                {
                    BookID = "10653387543",
                    BookName = "算法导论",
                    ISBN = "9787111407010",
                    Author = "Thomas H.Cormen、Charles E.Leiserson等",
                    PublishDate = DateTime.Parse("2013-01-01 00:00:00"),
                    BookVersion = "1",
                    WordCount = 20000,
                    PageCount = 754,
                    Publisher = "机械工业出版社",
                    ClassID = "G"
                };
                context.TBL_BookInfo.Add(newContext);
                context.SaveChanges();
                Console.WriteLine("==============添加成功！==============");
                var editContext = context.TBL_BookInfo.SingleOrDefault(x => x.BookName == "算法导论");
                editContext.WordCount = 50000;
                context.SaveChanges();
                Console.WriteLine("==============修改成功！==============");
                var delContext = context.TBL_BookInfo.Find("10653387543");
                context.TBL_BookInfo.Remove(delContext);
                context.SaveChanges();
                Console.WriteLine("==============删除成功！==============");
            }
        }
    }
}
