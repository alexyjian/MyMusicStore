using CodeFirst1108.DataContext;
using CodeFirst1108.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst1108.Migrations
{
   public  class DepartmentSeed
    {
        public static void Seed(StunDbContext context)
        {
            var d1 = new DeparMent()
            {
                Name = "电子信息工程学院",
                Description = "电子信息工程学院",
                SortCode = "001",
            };
            var d2 = new DeparMent()
            {
                Name = "机电工程学院",
                Description = "机电工程学院",
                SortCode = "002",
            };
            var d3 = new DeparMent()
            {
                Name = "汽车学院",
                Description = "汽车学院",
                SortCode = "003",
            };
            var d4 = new DeparMent()
            {
                Name = "贸易与旅游学院",
                Description = "贸易与旅游学院",
                SortCode = "004",
            };
            context.DeparMents.Add(d1);
            context.DeparMents.Add(d2);
            context.DeparMents.Add(d3);
            context.DeparMents.Add(d4);

        }
    }
}
