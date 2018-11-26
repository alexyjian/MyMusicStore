using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Migrations
{
    public class CategorySeed
    {
        public static void Seed(ProductDbContext context)
        {
            for (int s = 0; s < 10; s++)
            {
                var c1 = new Category()
                {
                    Name = "商品" + s.ToString(),
                    SortCode = s.ToString()
                };
                context.Categorys.Add(c1);               
            }
            context.SaveChanges();
        }
    }
}
