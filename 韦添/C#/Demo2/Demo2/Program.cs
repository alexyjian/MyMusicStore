using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用数据上下文进行数据操作。using表示上下文代码的范围，执行完后内存会自动释放
            using (var context = new CourseDBEntities())
            {
                var departments = context.Departments.OrderBy(n => n.SortCode).ToList();
                foreach(var d in departments)
                    Console.WriteLine("编号:{0},部门名称:{1},说明:{2}",d.SortCode,d.Name,d.Dscn);

                //Console.WriteLine("修改记录");
                //Console.WriteLine("=======================================================================");
                ////修改
                //var editDepartment = context.Departments.SingleOrDefault(x => x.Name == "环境与食品检测学院");
                //if(editDepartment!=null)
                //{
                //    editDepartment.Name = "环境与食品检测学院";
                //    editDepartment.SortCode = "008";
                //    context.SaveChanges();
                //}
                //else
                //    Console.WriteLine("未找到该记录，不能修改");


                Console.WriteLine("删除记录");
                Console.WriteLine("=======================================================================");
                var delDept = context.Departments.Find(Guid.Parse("7771ce06-278c-4bda-9c9e-30824490460f"));
                //var id = Guid.Parse("7771ce06-278c-4bda-9c9e-30824490460f");
                //var delDept = context.Departments.SingleOrDefault(x => x.ID == id);
                context.Departments.Remove(delDept);
                context.SaveChanges();



                var departments1 = context.Departments.OrderBy(n => n.SortCode).ToList();
                foreach(var d in departments1)
                    Console.WriteLine("编号:{0},部门名称:{1},说明:{2}",d.SortCode,d.Name,d.Dscn);
                Console.ReadKey();
            }
        }
    }
}
