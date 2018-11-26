using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Migrations
{
   public class SeedMethod
    {
        public static void CategoryandProductSeed(ProductDbContext context)
        {
            var c1 = new Category()
            {
                Name = "家用电器",
                SortCode = "001"
            };
            var c2 = new Category()
            {
                Name = "手机/数码",
                SortCode = "002"
            };
            var c3 = new Category()
            {
                Name = "电脑/办公",
                SortCode = "003"
            };
            var c4 = new Category()
            {
                Name = "家具",
                SortCode = "004"
            };
            var c5 = new Category()
            {
                Name = "男装/女装",
                SortCode = "005",
            };
            var c6 = new Category()
            {
                Name = "男鞋/女鞋",
                SortCode = "006",
            };
            context.Categories.Add(c1);
            context.Categories.Add(c2);
            context.Categories.Add(c3);
            context.Categories.Add(c4);
            context.Categories.Add(c5);
            context.Categories.Add(c6);
            context.SaveChanges();

            for (var i = 0; i < 100; i++)
            {
                var p1 = new Product()
                {
                    Category = c1,
                    Name = c1.Name + i.ToString("00"),
                    DSCN = c1.Name + i.ToString("00") + "用了就知道好！",
                    SN = c1.SortCode + "_" + i.ToString("00")
                };
                context.Products.Add(p1);
            }
            for (var i = 0; i < 100; i++)
            {
                var p2 = new Product()
                {
                    Category = c2,
                    Name = c2.Name + i.ToString("00"),
                    DSCN = c2.Name + i.ToString("00") + "用了就知道好！",

                    SN = c2.SortCode + "_" + i.ToString("00")
                };
                context.Products.Add(p2);
            }
            for (var i = 0; i < 100; i++)
            {
                var p3 = new Product()
                {
                    Category = c3,
                    Name = c3.Name + i.ToString("00"),
                    DSCN = c3.Name + i.ToString("00") + "用了就知道好！",
                    SN = c3.SortCode + "_" + i.ToString("00")
                };
                context.Products.Add(p3);
            }
            for (var i = 0; i < 100; i++)
            {
                var p4 = new Product()
                {
                    Category = c4,
                    Name = c4.Name + i.ToString("00"),
                    DSCN = c4.Name + i.ToString("00") + "用了就知道好！",
                    SN = c4.SortCode + "_" + i.ToString("00")
                };
                context.Products.Add(p4);
            }
            for (var i = 0; i < 100; i++)
            {
                var p5 = new Product()
                {
                    Category = c5,
                    Name = c5.Name + i.ToString("00"),
                    DSCN = c5.Name + i.ToString("00") + "用了就知道好！",
                    SN = c5.SortCode + "_" + i.ToString("00")
                };
                context.Products.Add(p5);
            }
            for (var i = 0; i < 100; i++)
            {
                var p6 = new Product()
                {
                    Category = c6,
                    Name = c6.Name + i.ToString("00"),
                    DSCN = c6.Name + i.ToString("00") + "用了就知道好！",
                    SN = c6.SortCode + "_" + i.ToString("00")
                };
                context.Products.Add(p6);
            }
            context.SaveChanges();
        }
    }
}
