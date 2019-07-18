using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    public class DepartmentSeed
    {
        public static void Seed(StuDBContext context)
        {
            var d1 = new DepartMent()
            {
                Name = "汽车工程学院",
                Description = "汽车工程学院",
                SortCode = "001"
            };
            var d2 = new DepartMent()
            {
                Name = "电子信息工程学院",
                Description = "电子信息工程学院",
                SortCode = "002"
            };
            var d3 = new DepartMent()
            {
                Name = "贸易与旅游工程学院",
                Description = "贸易与旅游工程学院",
                SortCode = "003"
            };
            var d4 = new DepartMent()
            {
                Name = "艺术学院",
                Description = "艺术学院",
                SortCode = "004"
            };

            context.DepartMents.Add(d1);
            context.DepartMents.Add(d2);
            context.DepartMents.Add(d3);
            context.DepartMents.Add(d4);
            context.SaveChanges();
        }
    }
}
