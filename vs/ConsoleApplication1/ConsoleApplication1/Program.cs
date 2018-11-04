using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用数据上下文进行数据操作，using表示上下文代码的范围，执行完后内存会自动释放
            using (var context = new CourseDBEntities())
            {
                var departments = context.dbo_Departnents.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments)
                
                    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dscn);

                //    Console.WriteLine("添加一条新的部门记录");
                //    //添加一条记录
                //    var newDepartment = new dbo_Departnents
                //    {
                //        ID = Guid.NewGuid(),
                //        Name = "环境与食品学院",
                //        Dscn = "环境与食品检测",
                //        SortCode="04"
                //    };
                ////把新的对象添加到上下文中
                //    context.dbo_Departnents.Add(newDepartment);
                ////更新上下文，把心的尸体保存到数据库中
                //    context.SaveChanges();

                //    var departments1 = context.dbo_Departnents.OrderBy(n => n.SortCode).ToList();
                //    foreach (var d in departments)

                //        Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                Console.WriteLine("修改记录");
                Console.WriteLine("======================================================");
                // 修改
                var editDepartment = context.dbo_Departnents.SingleOrDefault(x => x.Name == "环境与食品检测学院");
                if (editDepartment != null)
                {
                    editDepartment.Name = "环境与食品检测学院";
                    editDepartment.SortCode = "04";
                }
                else
                    Console.WriteLine("未找到该记录，不能修改");
                var departments1 = context.dbo_Departnents.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments)
                    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                Console.ReadKey();

                }
            }
        }
   }
