using CodeFirst11._08.DataContext;
using CodeFirst11._08.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst11._08.Migrations
{
    public  class DepartmentSeed
    {
        public static void Seed(StuDBContext context)
        {
            var d1 = new DepartMent()
            {
                Name = "电子信息工程学院",
                SortCode = "01",
                Descirption = "第一大学院"
            };
            var d2 = new DepartMent()
            {
                Name = "机电工程学院",
                SortCode = "02",
                Descirption = "第二大学院"
            };
            var d3 = new DepartMent()
            {
                Name = "汽车工程学院",
                SortCode = "03",
                Descirption = "第三大学院"
            };
            var d4 = new DepartMent()
            {
                Name = "财经物流学院",
                SortCode = "04",
                Descirption = "第四大学院"
            };
            context.DepartMents.Add(d1);
            context.DepartMents.Add(d2);
            context.DepartMents.Add(d3);
            context.DepartMents.Add(d4);
            context.SaveChanges();
        }
    }
}
