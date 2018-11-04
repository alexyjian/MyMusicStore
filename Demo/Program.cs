using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建数据的上下文,所有的表的实体都会在此上下文中;
            //var context = new CourseDBEntities();
            //var depatments = context.Departments.OrderBy(x=>x.SortCode).ToList();
            //var course = context.Coures.OrderBy(x => x.ID).ToList();

            //foreach (var d in depatments)
            //    Console.WriteLine("{0}:{1}", d.SortCode, d.Name);

            //foreach (var d in course)
            //    Console.WriteLine("{0}:{1}", d.Title, d.Credit);

            //使用数据上下文进行数据操作，using表示上下文代码的范围，执行完后内存会自动释放
            using (var conext = new CourseContext())
            {
                //where .orderby .tolist()注意调用的顺序.
                var departments = conext.Department.Where(n => n.Name.Contains("工程")).OrderBy(n => n.SortCode).ToList();
                //var departments = conext.Department.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments)

                    Console.WriteLine("编号：{0},部门名称:{1},说明:{2}", d.SortCode, d.Name, d.Dscn);

                Console.WriteLine("添加一条新的部门记录");
                Console.WriteLine("====================================================");

                //添加一条记录
                var newDepartment = new Department
                {
                    ID = Guid.NewGuid(),
                    Name = "测试学院",
                    Dscn = "环境与食品开发检测",
                    SortCode = "66"
                };
                //把新对象添加到上下文中
                conext.Department.Add(newDepartment);
                //更新上下文把新的实体保存到数据库
                conext.SaveChanges();

                //显示新的记录
                var departments1 = conext.Department.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments1)

                    Console.WriteLine("编号：{0},部门名称:{1},说明:{2}", d.SortCode, d.Name, d.Dscn);

                //Console.WriteLine("修改记录");
                //Console.WriteLine("=====================================================");

                //修改

                //var editDepartment = conext.Department.SingleOrDefault(x => x.Name == "环境与食品检测学院");
                //if (editDepartment != null)
                //{
                //    editDepartment.Name = "环境与食品检测学院";
                //    editDepartment.SortCode = "007";
                //    conext.SaveChanges();
                //}
                //else
                //    Console.WriteLine("未找到记录，不能修改");

                //var departments1 = conext.Department.OrderBy(n => n.SortCode).ToList();
                //foreach (var d in departments1)
                //    Console.WriteLine("编号：{0},部门名称:{1},说明:{2}", d.SortCode, d.Name, d.Dscn);

                //删除

                //Console.WriteLine("删除记录");
                //Console.WriteLine("=====================================================");
                ////find 用主键查询实体
                //var delDept = conext.Department.Find(Guid.Parse("c222d521-fc40-4d45-be16-ee74ac214090"));
                //// 不建议使用
                ////var id = Guid.Parse("c222d521-fc40-4d45-be16-ee74ac214090");
                ////var delDept = conext.Department.SingleOrDefault(x => x.ID == id);
                //conext.Department.Remove(delDept);
                //conext.SaveChanges();

                //var departments1 = conext.Department.OrderBy(n => n.SortCode).ToList();
                //foreach (var d in departments1)
                //    Console.WriteLine("编号：{0},部门名称:{1},说明:{2}", d.SortCode, d.Name, d.Dscn);


                Console.ReadKey();
            }
        }
    }
}
