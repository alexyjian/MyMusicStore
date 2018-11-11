using _1000Student.DataContext;
using _1000Student.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000Student.Migrations
{
    public class StudentSeed
    {
        public static void Seed(StuDBContext context)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i < 400)
                {
                    var s1 = new Student()
                    {
                        DepartMent = context.DepartMents.SingleOrDefault(x => x.Name == "电子信息工程学院")
                    };
                    context.Students.Add(s1);
                }
                if (i > 400&&i<600)
                {
                    var s2= new Student()
                    {
                        DepartMent = context.DepartMents.SingleOrDefault(x => x.Name == "机电工程学院")
                    };
                    context.Students.Add(s2);
                }
                if (i >600&&i<800)
                {
                    var s3 = new Student()
                    {
                        DepartMent = context.DepartMents.SingleOrDefault(x => x.Name == "财经与物流学院")
                    };
                    context.Students.Add(s3);
                }
                if (i < 900&i>800)
                {
                    var s4 = new Student()
                    {
                        DepartMent = context.DepartMents.SingleOrDefault(x => x.Name == "汽车工程学院")
                    };
                    context.Students.Add(s4);
                }
                else 
                {
                    var s5 = new Student()
                    {
                        DepartMent = context.DepartMents.SingleOrDefault(x => x.Name == "汽车工程学院")
                    };
                    context.Students.Add(s5);
                }
            }
           
        }
        //public static string department()
        //{
        //    string l = null;
        //    Random ran = new Random();
        //    int i = ran.Next(0, 5);
        //    switch (i)
        //    {
        //        case 1:
        //            l = "电子信息工程学院";
        //            break;
        //        case 2:
        //            l = "机电工程学院";
        //            break;
        //        case 3:
        //            l = "汽车工程学院";
        //            break;
        //        case 4:
        //            l = "贸易与旅游学院";
        //            break;
        //        case 5:
        //            l = "财经与物流学院";
        //            break;
        //    }
        //    return l;
        //}
    }
}

        
