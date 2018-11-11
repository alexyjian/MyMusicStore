using _1000Student.DataContext;
using _1000Student.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000Student.Migrations
{
    public class DepartmentSeed
    {
        public static void Seed(StuDBContext context)
        {
            var d1 = new DepartMent()
            {
                Name = "电子信息工程学院",
                Description = "电子信息工程",
                SortCode = "001"
            };

            var d2 = new DepartMent()
            {
                Name = "机电工程学院",
                Description = "机电工程",
                SortCode = "002"
            };

            var d3 = new DepartMent()
            {
                Name = "汽车工程学院",
                Description = "汽车工程",
                SortCode = "003"
            };

            var d4 = new DepartMent()
            {
                Name = "贸易与旅游学院",
                Description = "贸易与旅游",
                SortCode = "004"
            };

            var d5 = new DepartMent()
            {
                Name = "财经与物流学院",
                Description = "财经与物流",
                SortCode = "005"
            };
            context.DepartMents.Add(d1);
            context.DepartMents.Add(d2);
            context.DepartMents.Add(d3);
            context.DepartMents.Add(d4);
            context.DepartMents.Add(d5);

        }
    }
}
