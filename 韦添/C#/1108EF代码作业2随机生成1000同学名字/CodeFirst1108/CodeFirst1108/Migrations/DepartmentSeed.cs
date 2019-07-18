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

        public  static void Seed(StuDBContext context)
        {
            var d1 = new DepartMent()
            {
                Name = "电子信息工程学院",
                Description = "电子信息工程学院",
                SortCode="001",
            };
            var d2 = new DepartMent()
            {
                Name = "环境与食品学院",
                Description = "环境与食品学院",
                SortCode = "002",
            };
            var d3 = new DepartMent()
            {
                Name = "艺术设计学院",
                Description = "艺术设计学院",
                SortCode = "003",
            };
            var d4 = new DepartMent()
            {
                Name = "会计学院",
                Description = "会计学院",
                SortCode = "004",
            };
            var d5 = new DepartMent()
            {
                Name = "财务学院",
                Description = "财务学院",
                SortCode = "005",
            };
            context.DepartMents.Add(d1);
            context.DepartMents.Add(d2);
            context.DepartMents.Add(d3);
            context.DepartMents.Add(d4);
            context.DepartMents.Add(d5);
            context.SaveChanges();
        }
    }
}
