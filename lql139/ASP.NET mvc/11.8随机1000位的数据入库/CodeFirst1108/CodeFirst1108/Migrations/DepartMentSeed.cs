using CodeFirst1108.DataContent;
using CodeFirst1108.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst1108.Migrations
{
   public class DepartMentSeed
    {
        public static void Seed(StuDBContext context)
        {
            var d1 = new DepartMent()
            {
                Name="电子信息工程学院",
                SortCode="001",
                Desctiption= "电子信息工程学院"
            };
            var d2 = new DepartMent()
            {
                Name = "机电工程学院",
                SortCode = "002",
                Desctiption = "机电工程学院"
            };
            var d3 = new DepartMent()
            {
                Name = "贸易旅游学院",
                SortCode = "003",
                Desctiption = "贸易旅游学院"
            };
            var d4 = new DepartMent()
            {
                Name = "汽车工程学院",
                SortCode = "004",
                Desctiption = "汽车工程学院"
            };
            var d5 = new DepartMent()
            {
                Name = "财经与物流学院",
                SortCode = "005",
                Desctiption = "财经与物流学院"
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
