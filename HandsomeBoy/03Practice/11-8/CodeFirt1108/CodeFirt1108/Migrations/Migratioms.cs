using CodeFirt1108.DataContext;
using CodeFirt1108.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirt1108.Migrations
{
  public  class Migratioms
    {

        public static void Seed(StuDBContext context)
        {
            var d1 = new DepartMents()
            {
                Name = "电子信息工程学院",
                Description = "电子信息工程学院",
                SortCode = "001",
            };
            var d2 = new DepartMents()
            {
                Name = "机电工程学院",
                Description = "机电工程学院",
                SortCode = "002",
            };
            var d3 = new DepartMents()
            {
                Name = "汽车工程学院",
                Description = "汽车工程学院",
                SortCode = "003",
            };
            var d4 = new DepartMents()
            {
                Name = "贸易与旅游学院",
                Description = "贸易与旅游学院",
                SortCode = "004",
            };
            var d5 = new DepartMents()
            {
                Name = "财经与物流学院",
                Description = "财经与物流学院",
                SortCode = "005",
                
            };
            context.DepartMent.Add(d1);
            context.DepartMent.Add(d2);
            context.DepartMent.Add(d3);
            context.DepartMent.Add(d4);
            context.DepartMent.Add(d5);
            context.SaveChanges();
        }

    }
}
