using CodeFirst.DataContext;
using CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Migrations
{
   public class DepartmentSeed
    {
        public static void Seed(StuDBContext context)
        {
            //初始化学院
            var d1 = new DepartMent()
            {
                Name = "电子信息工程学院",
                SortCode = "001",
                Description = ""

            };
            var d2 = new DepartMent()
            {
                Name = "机电工程学院",
                SortCode = "002",
                Description = ""

            };
            var d3 = new DepartMent()
            {
                Name = "艺术学院",
                SortCode = "003",
                Description = ""

            };
            var d4 = new DepartMent()
            {
                Name = "汽车工程学院",
                SortCode = "004",
                Description = ""

            };
            var d5 = new DepartMent()
            {
                Name = "财经与物流学院",
                SortCode = "005",
                Description = ""

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
