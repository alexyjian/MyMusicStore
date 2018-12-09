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
            var d1 = new Category()
            {
                Name="家用电器",
                SortCode="001",
                
            };
            var d2 = new Category()
            {
                Name = "家具/家具",
                SortCode = "002",

            };
            var d3 = new Category()
            {
                Name = "男装/女装",
                SortCode = "003",

            };
            var d4 = new Category()
            {
                Name = "男鞋/女鞋",
                SortCode = "004",

            };
            var d5 = new Category()
            {
                Name = "手机/数码",
                SortCode = "005",

            };
            var d6 = new Category()
            {
                Name = "电脑/办公",
                SortCode = "006",

            };
            context.Categories.Add(d1);
            context.Categories.Add(d2);
            context.Categories.Add(d3);
            context.Categories.Add(d4);
            context.Categories.Add(d5);
            context.Categories.Add(d6);
            context.SaveChanges();


            for (var i = 0; i < 100; i++)
            {
                var z1 = new Product()
                {
                    Categoty = d1,
                    Name = d1.Name + i.ToString("00"),
                    DSCN = d1.Name + i.ToString("00") + "用了就知道好！",
                    SN = d1.SortCode + "_" + i.ToString("00")
                };
                context.Products.Add(z1);
            }
            for (var i = 0; i < 100; i++)
            {
                var z2 = new Product()
                {
                    Categoty = d2,
                    Name = d2.Name + i.ToString("00"),
                    DSCN = d2.Name + i.ToString("00") + "用了就知道好！",
                    SN = d2.SortCode + "_" + i.ToString("00")
                };
                context.Products.Add(z2);
            }
            for (var i = 0; i < 100; i++)
            {
                var z3 = new Product()
                {
                    Categoty = d3,
                    Name = d3.Name + i.ToString("00"),
                    DSCN = d3.Name + i.ToString("00") + "用了就知道好！",
                    SN = d3.SortCode + "_" + i.ToString("00")
                };
                context.Products.Add(z3);
            }
            for (var i = 0; i < 100; i++)
            {
                var z4 = new Product()
                {
                    Categoty = d4,
                    Name = d4.Name + i.ToString("00"),
                    DSCN = d4.Name + i.ToString("00") + "用了就知道好！",
                    SN = d4.SortCode + "_" + i.ToString("00")
                };
                context.Products.Add(z4);
            }
            for (var i = 0; i < 100; i++)
            {
                var z5 = new Product()
                {
                    Categoty = d5,
                    Name = d5.Name + i.ToString("00"),
                    DSCN = d5.Name + i.ToString("00") + "用了就知道好！",
                    SN = d5.SortCode + "_" + i.ToString("00")
                };
                context.Products.Add(z5);
            }
            for (var i = 0; i < 100; i++)
            {
                var z6 = new Product()
                {
                    Categoty = d6,
                    Name = d6.Name + i.ToString("00"),
                    DSCN = d6.Name + i.ToString("00") + "用了就知道好！",
                    SN = d6.SortCode + "_" + i.ToString("00")
                };
                context.Products.Add(z6);
            }
            context.SaveChanges();
        }
    }
}
