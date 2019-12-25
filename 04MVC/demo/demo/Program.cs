using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CourseDBEntities())
            {


                var departments = context.Departments.OrderBy(n => n.SortCode).ToList();
                foreach (var a in departments)

                    Console.WriteLine("编号:{0},部门名称:{1},说明:{2}", a.SortCode, a.Name, a.Dscn);
                ////添加
                //var newDepartment = new Department
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "环境与食品学院",
                //    Dscn = "环境与食品检测",
                //    SortCode = "007"
                //};
                //context.Departments.Add(newDepartment);
                //context.SaveChanges();

                //修改
                //var editDepartment = context.Departments.SingleOrDefault(x => x.Name == "环境与食品学院");
                //if (editDepartment != null)
                //{
                //    editDepartment.Name = "环境与食品检测学院";
                //    editDepartment.SortCode = "005";
                //    context.SaveChanges();
                //}
                //else
                //{
                //    Console.WriteLine("未找到记录，请重新查询");
                //}
                ////删除
                //var delDept = context.Departments.Find(Guid.Parse("9d43730e-d178-47ec-adef-aca57ff5c987"));
                //context.Departments.Remove(delDept);
                ////context.SaveChanges();
                //var departments1 = context.Departments.OrderBy(n => n.SortCode).ToList();
                //foreach (var d in departments1)

                //    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                Console.ReadKey();
            }
        }
    }
}
