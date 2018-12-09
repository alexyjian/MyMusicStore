
using StuContext;
using StuEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StuDataContext
{
    public class StudentSeed
    {
        public static void Seed(StuDBContext context)
        {
            #region 电子信息学生
            var d1 = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院");
            for(var i = 0; i < 400; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);

                var student = new Student()
                {
                    StudentNo = "DZXX" + i.ToString("0000"),                  
                    LastName =lname,
                    FirstName=fname,                    
                    FullName = fullname,
                    BirthDay=DateTime.Now,
                    Address="广西·柳州",
                    Department =d1,
                    Phone ="159*******"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }

            #endregion

            #region  机电工程学院
            var d2 = context.Departments.SingleOrDefault(x => x.Name == "机电工程学院");
            for (var i = 0; i < 400; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);

                var student = new Student()
                {
                    StudentNo = "JDXY" + i.ToString("0000"),
                    LastName = lname,
                    FirstName = fname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "广西·柳州",
                    Department = d2,
                    Phone = "189*******"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion

            #region 艺术学院
            var d3 = context.Departments.SingleOrDefault(x => x.Name == "艺术学院");
            for (var i = 0; i < 400; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);

                var student = new Student()
                {
                    StudentNo = "YSXY" + i.ToString("0000"),
                    LastName = lname,
                    FirstName = fname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "广西·柳州",
                    Department = d3,
                    Phone = "139*******"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion

        # region 汽车工程学院
            var d4 = context.Departments.SingleOrDefault(x => x.Name == "汽车工程学院");
            for (var i = 0; i < 400; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);

                var student = new Student()
                {
                    StudentNo = "QCGC" + i.ToString("0000"),
                    LastName = lname,
                    FirstName = fname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "广西·柳州",
                    Department = d4,
                    Phone = "189*******"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion

            #region 财经与物流学院
            var d5 = context.Departments.SingleOrDefault(x => x.Name == "财经与物流学院");
            for (var i = 0; i < 400; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);

                var student = new Student()
                {
                    StudentNo = "CJYWL" + i.ToString("0000"),
                    LastName = lname,
                    FirstName = fname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "广西·柳州",
                    Department = d5,
                    Phone = "199*******"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion

            context.SaveChanges();
            _GarbageClear();
        }
        /// <summary>
        /// 随机生成中文姓名
        /// </summary>
        /// <param name="firstName">姓</param>
        /// <param name="lasrName">名</param>
        /// <returns></returns>
        public static string _GetRandomChineseFullName(ref string firstName, ref string lasrName)
        {
            string[] _seedFirstName = new string[]
            {
                   "冀","郏","浦","尚","农","温","别","庄","晏","柴","瞿","阎",
                "充","慕","连","茹","习","宦","艾","鱼","容","向","古","易",
                "慎","戈","廖","庚","终","暨","居","衡","步","都","耿","满",
                "弘","匡","国","文","寇","广","禄","阙","东","殴","殳","沃",
                "利","蔚","越","夔","隆","师","巩","厍","聂","晁","勾","敖",
                "融","冷","訾","辛","阚","那","简","饶","空","曾","毋","沙",
                "乜","养","鞠","须","丰","巢","关","蒯","相","查","后","江",
                "红","游","竺","权","逯","盖","益","桓","公","万","俟","司",
                "马","上","官","欧","阳","夏","侯","诸","葛","闻","人","东",
                "方","赫","连","皇","甫","尉","迟","公","羊","澹","台","公",
                "冶","宗","政","濮","阳","淳","于","仲","孙","太","叔","申",
                "屠","公","孙","乐","正","轩","辕","令","狐","钟","离","闾",
                "丘","长","孙","慕","容","鲜","于","宇","文","司","徒","司",
                "空","亓","官","司","寇","仉","督","子","车","颛","孙","端",
                "木","巫","马","公","西","漆","雕","乐","正","壤","驷","公",
                "良","拓","拔","夹","谷","宰","父","谷","粱","晋","楚","阎",
                "法","汝","鄢","涂","钦","段","干","百","里","东","郭","南",
                "门","呼","延","归","海","羊","舌","微","生","岳","帅","缑",
                "亢","况","后","有","琴","梁","丘","左","丘","东","门","西",
                "门","商","牟","佘","佴","伯","赏","南","宫","墨","哈","谯",
                "笪","年","爱","阳","佟","第","五","言","福","百","家","姓",
                "续",

           };
            string _seedLastName = @"块干感揆手楷港琨莞夸
                鼓该贾传仅涂塔塘廊谦提敬斟极楠殿汤渡绢经茎莒获莅庄莉蜀裏装解
                詹鼎贾路迹退铃钜陀电雷靖顿暖桢路嫁农贮贷贴轸迪钠湍琳当略铃鼓
                励庸园圆奥爱意扬援握榆业杨椰涌渝渭游炜爷烟兽犹煜碗筠义肄莞莠
                虞蛾裕诣郁钰雍阿预饮衙莹蓊晕渥琬琰畹筵裔淡催传勤势嗣塞嵩厦新喧楸楚岁湘测凑煦琴琪琦睡祺稔稠筮粲绣群圣莎裙诩诗试诠详资载送铅阻雌颂驰熙暄琼塞嵩想桢椿岁渚煮琛庄裟输轼幕
                汇惶挥描换楣枫湖浑渺涣煤烦琶琥盟睦碑禀聘腑荷莫号蜂补话酩附颁饭晕募焕";

            var rnd = new Random(DateTime.Now.Millisecond);
            //随机取一个姓
            firstName = _seedFirstName[rnd.Next(_seedFirstName.Length - 1)];
            //随机取两个字做名
            lasrName = _seedLastName.Substring(rnd.Next(0, _seedLastName.Length - 1),1)
                + _seedLastName.Substring(rnd.Next(0, _seedLastName.Length - 1), 1);

            return firstName + lasrName;
                 
        } 
        //去除重名的方法
        private static void _GarbageClear()
        {
            //var dbcontext = new StuDBContext();
            //var students = dbcontext.Students.DistinctBy(x => x.FullName).ToList();
            ////删除重名
            //foreach(var stu in students)
            //{
            //    dbcontext.Students.Where(x => x.FullName ==stu.FullName &&
            //    x.ID != stu.ID).Delete();
            //}
        }
    }
}