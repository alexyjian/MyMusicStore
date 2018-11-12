using StuEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuContext.Migrations
{
   public class DepartmentSeed
    {
        public static void Seed(StuDBContext context)
        {
            var d1 = new DopartMent()
            {
                Name = "电子信息工程学院",
                Description = "软件技术",
                SortCode = "001",
            };
            var d2 = new DopartMent()
            {
                Name = "机电工程学院",
                Description = "机电工程学院",
                SortCode = "002",
            };
            var d3 = new DopartMent()
           {
            Name = "汽车工程学学院",
            Description = "汽车工程学院",
            SortCode = "003",
           };
  
           var d4 = new DopartMent()
           {
            Name = "贸易与旅游学院",
            Description = "贸易与旅游学院",
            SortCode = "004",
           };
            var d5 = new DopartMent()
            {
                Name = "财经与物流学院",
                Description = "财经与物流学院",
                SortCode = "005",
            };
            context.DopartMents.Add(d1);
            context.DopartMents.Add(d2);
            context.DopartMents.Add(d3);
            context.DopartMents.Add(d4);
            context.DopartMents.Add(d5);
            context.SaveChanges();
        }
    }
}
