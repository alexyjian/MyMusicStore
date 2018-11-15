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
        public static void CategoryandProductSeed(DataContext.ProductDbContext context)
        {
            var c1 = new Category
            {
                Name = "电脑",
                SortCode ="001"
            };
            var c2 = new Category
            {
                Name = "数码",
                SortCode = "002"
            };
            var c3 = new Category
            {
                Name = "零食",
                SortCode = "003"
            };
            var c4 = new Category
            {
                Name = "生活用品",
                SortCode = "004"
            };
            var c5 = new Category
            {
                Name = "家电",
                SortCode = "005"
            };
            context.Category.Add(c1);
            context.Category.Add(c2);
            context.Category.Add(c3);
            context.Category.Add(c4);
            context.Category.Add(c5);
            context.SaveChanges();

            for (var i = 0; i < 100; i++)
            {
                var p1 = new Product
                {
                    Categoty = c1,
                    Name = c1.Name + i.ToString("00"),
                    DSCN = c1.Name + i.ToString("00") + "用了就知道好！",
                    SN = c1.SortCode + "_" + i.ToString("00")
                };
                context.Product.Add(p1);
            }

            for (var i = 0; i < 100; i++)
            {
                var p2 = new Product
                {
                    Categoty = c2,
                    Name = c2.Name + i.ToString("00"),
                    DSCN = c2.Name + i.ToString("00") + "用了就知道好！",
                    SN = c2.SortCode + "_" + i.ToString("00")
                };
                context.Product.Add(p2);
            }

            for (var i = 0; i < 100; i++)
            {
                var p3 = new Product
                {
                    Categoty = c3,
                    Name = c3.Name + i.ToString("00"),
                    DSCN = c3.Name + i.ToString("00") + "用了就知道好！",
                    SN = c3.SortCode + "_" + i.ToString("00")
                };
                context.Product.Add(p3);
            }

            for (var i = 0; i < 100; i++)
            {
                var p4 = new Product
                {
                    Categoty = c4,
                    Name = c4.Name + i.ToString("00"),
                    DSCN = c4.Name + i.ToString("00") + "用了就知道好！",
                    SN = c4.SortCode + "_" + i.ToString("00")
                };
                context.Product.Add(p4);
            }

            for (var i = 0; i < 100; i++)
            {
                var p5 = new Product
                {
                    Categoty = c5,
                    Name = c5.Name + i.ToString("00"),
                    DSCN = c5.Name + i.ToString("00") + "用了就知道好！",
                    SN = c5.SortCode + "_" + i.ToString("00")
                };
                context.Product.Add(p5);
            }
            context.SaveChanges();
        }
    }
}
