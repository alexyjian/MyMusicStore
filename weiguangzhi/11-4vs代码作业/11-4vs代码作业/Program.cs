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
            var context = new CourseDBEntities();
            var courses = context.Departents.ToList();

            foreach (var c in courses)
                Console.WriteLine("课程名称：{0} 课程学分：{1} 所属学院",c.Title,c.Credit,c.Cou.Name);

            //Console.WriteLine("添加课程");
            //Console.WriteLine("----------------------------------------------------");
            //var c1 = new Departents()
            //{
            //    ID = Guid.NewGuid(),
            //    Title = "软件工程项目组织管理",
            //    Credit = 17,
            //    //外键的对象一定要从一个上下文中查询
            //    Cou = context.Cou.SingleOrDefault(x => x.Name == "电子信息工程学院")
            //};
            //var c2 = new Departents()
            //{
            //    ID = Guid.NewGuid(),
            //    Title = "算法与数据结构1",
            //    Credit = 2,

            //    Cou = context.Cou.SingleOrDefault(x => x.Name == "电子信息工程学院")
            //};
            //var c3 = new Departents()
            //{
            //    ID = Guid.NewGuid(),
            //    Title = "C#图像处理",
            //    Credit = 2,

            //    Cou = context.Cou.SingleOrDefault(x => x.Name == "电子信息工程学院")
            //};
            ////把新的对象添加到上下文中
            //context.Departents.Add(c1);
            //context.Departents.Add(c2);
            //context.Departents.Add(c3);
            ////更新上下文，把新的实体保存到数据库中
            //context.SaveChanges();

            //Console.WriteLine("修改课程");
            //Console.WriteLine("----------------------------------------");
            //var editDepartment = context.Departents.SingleOrDefault(x => x.Title == "算法与数据结构1");
            //if (editDepartment != null)
            //{
            //    editDepartment.Title = "职业素养";
            //    editDepartment.Credit = 5;
            //    context.SaveChanges();
            //}
            //else
            //    Console.WriteLine("未找到该数据，不能修改");

            Console.WriteLine("删除课程");
            Console.WriteLine("----------------------------------------------");

            //fing--用主键查询实体
            var delDept = context.Departents.Find(Guid.Parse("bb4ba209-b035-41eb-a946-d0ca990bd9f0"));
            context.Departents.Remove(delDept);
            context.SaveChanges();



            //显示新的记录
            var departments1 = context.Departents.OrderBy(n => n.Title).ToList();
            foreach (var c in courses)
                Console.WriteLine("课程名称：{0} 课程学分：{1} 所属学院", c.Title, c.Credit, c.Cou.Name);


            ////使用数据上下文进行数据操作，using表示上下文代码的范围，执行完成后内存会自动释放
            //using (var context = new CourseDBEntities())
            //{
            //    //.where .orderby .tolist()注意调用的顺序
            //    var departments = context.Cou.OrderBy(n => n.SortCode).ToList();
            //    //var departments = context.Cou.Where(n => n.Name.Contains("工程")).OrderBy(n => n.SortCode).ToList();
            //    foreach (var a in departments)
            //        Console.WriteLine("编号{0},部门名称{1}，说明{2}", a.SortCode, a.Name, a.Dscn);
            //    ////添加一条记录
            //    //var newcou = new Cou
            //    //{
            //    //    ID = Guid.NewGuid(),
            //    //    Name = "财经学院",
            //    //    Dscn="环境与食品检测",
            //    //    SortCode="009"

            //    //};
            //    ////把新的对象添加到上下文中
            //    //context.Cou.Add(newcou);
            //    ////更新上下文，把新的实体保存到数据库中
            //    //context.SaveChanges();

            //    //Console.WriteLine("-------------------------------------------------------------");
            //    ////修改
            //    //var editDepartment = context.Cou.SingleOrDefault(x => x.Name == "zz学院");
            //    //if (editDepartment != null)
            //    //{
            //    //    editDepartment.Name = "环境与食品检测学院";
            //    //    editDepartment.SortCode = "007";
            //    //    context.SaveChanges();
            //    //}
            //    //else
            //    //    Console.WriteLine("未找到该数据，不能修改");

            //    ////显示新的记录
            //    //var departments1 = context.Cou.OrderBy(n => n.SortCode).ToList();
            //    //foreach (var a in departments)
            //    //    Console.WriteLine("编号{0},部门名称{1}，说明{2}", a.SortCode, a.Name, a.Dscn);

            //    Console.WriteLine("删除记录");
            //    Console.WriteLine("-------------------------------------");
            //    //fing--用主键查询实体
            //    var delDept = context.Cou.Find(Guid.Parse("19cc8682-a6f6-4bb9-a474-a122511ebfff"));
            //    context.Cou.Remove(delDept);
            //    context.SaveChanges();


            //    Console.ReadKey();
        }
    }
    }
