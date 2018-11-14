using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Migrations
{
   public  class SeedMethod
    {
        public static void CategoryandProductSeed(ProductDbContext context)
        {
            var C1 = new Category()
            {
                Name = "家用电器",
                SortCode = "001",
            };
            var C2 = new Category()
            {
                Name = "手机",
                SortCode = "002",
            };
            var C3 = new Category()
            {
                Name = "电脑",
                SortCode = "003",
            };
            var C4 = new Category()
            {
                Name = "家居",
                SortCode = "004",
            };
            var C5 = new Category()
            {
                Name = "男装",
                SortCode = "005",
            };
            var C6 = new Category()
            {
                Name = "女鞋",
                SortCode = "006",
            };
            context.Categorise.Add(C1);
            context.Categorise.Add(C2);
            context.Categorise.Add(C3);
            context.Categorise.Add(C4);
            context.Categorise.Add(C5);
            context.Categorise.Add(C6);
            context.SaveChanges();

            for (var i = 0; i < 100; i++)
            {
                var p1 = new Product()
                {
                    Categoty = C1,
                    Name = C1.Name + i.ToString("00"),
                    DSCN = C1.Name + i.ToString("00") + "用了就知道好；",
                    SN = C1.SortCode + "_" + i.ToString("00")
                };
                context.Product.Add(p1);
            }
            for (var i = 0; i < 100; i++)
            {
                var p2 = new Product()
                {
                    Categoty = C2,
                    Name = C1.Name + i.ToString("00"),
                    DSCN = C1.Name + i.ToString("00") + "用了就知道好！",
                    SN = C2.SortCode + "_" + i.ToString("00")
                };
                context.Product.Add(p2);
            }
            for (var i = 0; i < 100; i++)
            {
                var p3 = new Product()
                {
                    Categoty = C3,
                    Name = C2.Name + i.ToString("00"),
                    DSCN = C2.Name + i.ToString("00") + "用了就知道好；",
                    SN = C3.SortCode + "_" + i.ToString("00")
                };
                context.Product.Add(p3);
            }
            for (var i = 0; i < 100; i++)
            {
                var p4 = new Product()
                {
                    Categoty = C4,
                    Name = C4.Name + i.ToString("00"),
                    DSCN = C4.Name + i.ToString("00") + "用了就知道好；",
                    SN = C4.SortCode + "_" + i.ToString("00")
                };
                context.Product.Add(p4);
            }

            for (var i = 0; i < 100; i++)
            {
                var p5 = new Product()
                {
                    Categoty = C5,
                    Name = C5.Name + i.ToString("00"),
                    DSCN = C5.Name + i.ToString("00") + "用了就知道好；",
                    SN = C5.SortCode + "_" + i.ToString("00")
                };
                context.Product.Add(p5);
            }
            for (var i = 0; i < 100; i++)
            {
                var p6 = new Product()
                {
                    Categoty = C6,
                    Name = C6.Name + i.ToString("00"),
                    DSCN = C6.Name + i.ToString("00") + "用了就知道好；",
                    SN = C6.SortCode + "_" + i.ToString("00")
                };
                context.Product.Add(p6);
            }
            context.SaveChanges();
        }
    }
}
