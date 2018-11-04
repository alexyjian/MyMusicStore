using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CoursesDBEntities())
            {
                var departments = context.Departments.Where(n => n.Name.Contains("工程")).OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments)
                    Console.WriteLine("编号{0}", "部门名称{1}", "说明{2}", d.SortCode, d.Name, d.Dscn);

                //Console.WriteLine("修改记录");
                //Console.WriteLine("=========================================");
                ////修改
                //var editDepartment = context.Departments.SingleOrDefault(x => x.Name == "环境与食品检测学院");
                //if (editDepartment != null)
                //{
                //    editDepartment.Name = "环境与食品检测学院";
                //    editDepartment.SortCode = "006";
                //    context.SaveChanges();
                //}
                //else
                //    Console.WriteLine("未找到该记录，请重新查询");


                Console.WriteLine("删除记录");
                Console.WriteLine("==============================================");
                var deIDept = context.Departments.Find(Guid.Parse("6b03cdab-2576-40b7-b789-e3d9b34bd9e0"));
                context.Departments.Remove(deIDept);
                context.SaveChanges();
                Console.WriteLine("====================================");

                var departments1 = context.Departments.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments1)
                    Console.WriteLine("编号：{0},部门名称：{1}，说明：{2}", d.SortCode, d.Name, d.Dscn);
                Console.ReadKey();
            }
        }
    }
}

