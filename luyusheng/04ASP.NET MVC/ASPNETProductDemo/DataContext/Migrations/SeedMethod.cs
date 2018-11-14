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
                SortCode = "001",
            };
            var c2 = new Category()
            {
                Name = "手机/数码",
                SortCode = "002",
            };
            var c3 = new Category()
            {
                Name = "电脑/办工",
                SortCode = "003",
            };
            var c4 = new Category()
            {
                Name = "家居/家具",
                SortCode = "004",
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
        }
    }
}
