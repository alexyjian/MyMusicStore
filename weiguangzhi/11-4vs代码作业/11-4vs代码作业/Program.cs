using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_4vs代码作业
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用数据上下文进行数据操作，using表示上下文代码的范围，执行完成后内存会自动释放
            using (var context = new CourseDBEntities())
            {
                //.where .orderby .tolist()注意调用的顺序
                var departments = context.Cou.OrderBy(n => n.SortCode).ToList();
                //var departments = context.Cou.Where(n => n.Name.Contains("工程")).OrderBy(n => n.SortCode).ToList();
                foreach (var a in departments)
                    Console.WriteLine("编号{0},部门名称{1}，说明{2}", a.SortCode, a.Name, a.Dscn);
                ////添加一条记录
                //var newcou = new Cou
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "财经学院",
                //    Dscn="环境与食品检测",
                //    SortCode="009"

                //};
                ////把新的对象添加到上下文中
                //context.Cou.Add(newcou);
                ////更新上下文，把新的实体保存到数据库中
                //context.SaveChanges();

                //Console.WriteLine("-------------------------------------------------------------");
                ////修改
                //var editDepartment = context.Cou.SingleOrDefault(x => x.Name == "zz学院");
                //if (editDepartment != null)
                //{
                //    editDepartment.Name = "环境与食品检测学院";
                //    editDepartment.SortCode = "007";
                //    context.SaveChanges();
                //}
                //else
                //    Console.WriteLine("未找到该数据，不能修改");

                ////显示新的记录
                //var departments1 = context.Cou.OrderBy(n => n.SortCode).ToList();
                //foreach (var a in departments)
                //    Console.WriteLine("编号{0},部门名称{1}，说明{2}", a.SortCode, a.Name, a.Dscn);

                Console.WriteLine("删除记录");
                Console.WriteLine("-------------------------------------");
                //fing--用主键查询实体
                var delDept = context.Cou.Find(Guid.Parse("19cc8682-a6f6-4bb9-a474-a122511ebfff"));
                context.Cou.Remove(delDept);
                context.SaveChanges();


                Console.ReadKey();
            }
        }
    }
}
