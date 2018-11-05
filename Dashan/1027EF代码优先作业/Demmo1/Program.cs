using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demmo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建数据的上下文， 所有的表的实体在此上下文
            using (var context = new CourseDBEnti())
            {
                //注意调用的顺序 .where .orderby .tolist()
                var departments = context.Departmnts.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments)
                    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dscn);


                Console.WriteLine("添加一条新的部门记录");
                //添加一条新的记录
                var newDepartment = new Departmnt
                {
                    ID = Guid.NewGuid(),
                    Name = "机电学院",
                    Dscn = "机电部",
                    SortCode = "008"


                };

                //
                context.Departmnts.Add(newDepartment);
                //
                context.SaveChanges();
                //显示新的记录





                var department1 = context.Departmnts.OrderBy(n => n.SortCode).ToList();
                foreach (var d in department1)
                    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dscn);


                Console.WriteLine("修改记录");
                Console.WriteLine("=============================================");

                //修改
                var editDpartment = context.Departmnts.SingleOrDefault(x => x.Name == "艺术学院");
                editDpartment.Name = "艺术学院";
                editDpartment.SortCode = "005";
                context.SaveChanges();


                //else
                //Console.WriteLine("未找到记录，不能修改！！！");





                Console.WriteLine("删除记录");
                Console.WriteLine("=============================================");

                //var id = Guid.Parse("a77dc643-da6f-4895-b674-dde647b42273");
                //var deIDept = context.Departmnts.SingleOrDefault(x => x.ID == id);
                //context.Departmnts.Remove(deIDept);
                //context.SaveChanges();

                //var department1 = context.Departmnts.OrderBy(n => n.SortCode).ToList();
                //foreach (var d in department1)
                //    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                //Console.ReadKey();




            }
        }
    }
}
