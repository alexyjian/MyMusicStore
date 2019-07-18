using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Migrations
{
    public class ProductSeed
    {
        public static void Seed(ProductDbContext context)
        {
            for (int s = 0; s < 1000; s++)
            {
                var p1 = new Product()
                {
                    SN = s.ToString(),
                    Name = "飞机",
                    DSCN = "飞机SD卡雷锋精神打开了房间的说",
                    Category = context.Categorys.Single(x => x.SortCode == "1")
                };
                context.Products.Add(p1);
            }
            context.SaveChanges();
        }
    }
}
