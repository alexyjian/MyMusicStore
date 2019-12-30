using FirstCode1108.DataContext;
using FirstCode1108.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCode1108.Migrations
{
    public class DepartmentSeed
    {
        public static void Seed(StuDBContext context)
        {
            var d1 = new DepartMent()
            {
                Name = "电子信息工程学院",
                SortCode = "001",
                Description = "第一大学院"
            };
            var d2 = new DepartMent()
            {
                Name = "机电工程学院",
                SortCode = "002",
                Description = "第二大学院"
            };
            var d3 = new DepartMent()
            {
                Name = "汽车工程学院",
                SortCode = "003",
                Description = "第三大学院"
            };
            var d4 = new DepartMent()
            {
                Name = "财经与物流学院",
                SortCode = "004",
                Description = "第四大学院"
            };
            context.DepartMents.Add(d1);
            context.DepartMents.Add(d2);
            context.DepartMents.Add(d3);
            context.DepartMents.Add(d4);
            context.SaveChanges();

        }
    }
}
