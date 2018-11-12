using StuEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StuContext.Migrations
{
    public class StudentSeed
    {
        public static void Seed(StuDBContext context)
        {
            #region 电子信息学生
            var d1 = context.DopartMents.SingleOrDefault(x => x.Name == "电子信息工程学院");
            for (var i = 0; i < 400; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "DZXX" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Dopartment = d1,
                    Phone = "177*******"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion
            #region 机电学生
            var d2 = context.DopartMents.SingleOrDefault(x => x.Name == "机电工程学院");
            for (var i = 0; i < 300; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "JDGC" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "秀厢路07号",
                    Dopartment = d2,
                    Phone = "178*******"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion
            #region 汽车学生
            var d3 = context.DopartMents.SingleOrDefault(x => x.Name == "汽车工程学院");
            for (var i = 0; i < 250; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "QCGC" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "秀厢路07号",
                    Dopartment = d3,
                    Phone = "137*******"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion
            #region 贸易与旅游学生
            var d4 = context.DopartMents.SingleOrDefault(x => x.Name == "贸易与旅游学院");
            for (var i = 0; i < 250; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "MYLY" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "秀厢路07号",
                    Dopartment = d4,
                    Phone = "137*******"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion
            #region 财经与物流学生
            var d5 = context.DopartMents.SingleOrDefault(x => x.Name == "财经与物流学院");
            for (var i = 0; i < 250; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "CJWL" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "秀厢路07号",
                    Dopartment = d5,
                    Phone = "137*******"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion
        }


        /// <summary>
        /// 随机生成中文名字
        /// </summary>
        /// <param name="firstName">姓</param>
        /// <param name="lasrName">名</param>
        /// <returns>姓名</returns>
        public static string _GetRandomChineseFullName(ref string firstName, ref string lasrName)
        {
            string[] _seedFirstName = new string[]
            {
                "赵","钱","孙","李","周","吴","郑","王","冯","陈","褚","卫",
                "蒋","沈","韩","杨","朱","秦","尤","许","何","吕","施","孔",
                "邹","喻","柏","水","窦","章","云","苏","潘","葛","奚","范",
                "彭","郎","鲁","韦","昌","马","苗","凤","花","方","俞","任",
                "袁","柳","酆","鲍","史","唐","费","廉","岑","薛","雷","贺",
                "倪","汤","滕","殷","罗","毕","郝","邬","安","常","乐","于",
                "时","傅","皮","卞","齐","康","伍","余","元","卜","顾","孟",
                "平","黄","和","穆","萧","尹","姚","邵","湛","汪","祁","毛",
                "禹","狄","米","贝","明","臧","伏","成","戴","谈","宋","茅",
                "庞","熊","宓","纪","舒","屈","项","祝","董","梁","杜","阮",
                "蓝","闵","席","季","麻","强","贾",
                
            };
            string _seedLastName = @"哲莹泰秦艳恭真原倩偌倚倜兼益凌准陵陶都挽莱莲莫茶莉莓荷莜莎唏唤峰峻徒徐阅涛涟消浴浩海流涧润涕浪涩家
侘昌抄弨扯忱承忡初垂佌刺儿庚刮戋金净侃刻侄孥妻戕青取叁刹姗疝尚舍社侁呻使始事受抒叔刷祀忪怂所兔昔穸些姓刖甾昃轧周妯宙侏宗绿晚萤雪彩得着
常眼惜虚谚辆猪脚断停推敢淡啸绮密盖蚯球脸脱淋甜情唱啥梳象睁做救票梦领盛捧啄累梁铭教铜袋鹿掉渐梢粗理假蛋蛇惯绳兔兕兖兗兘兙党兛宽宴容宾姬
兜兝兞兟兠兡兢兣兤入徖得徘徙徚徛徜徝從徟徠御徢徣徤慯慰慱慲慳慴慵慶慷慸慹慺慻慼慽慾慿憀憁憂憃憄憅憆娟娥绣朗朕";
            {
                var rnd = new Random(DateTime.Now.Millisecond);
                //随机取一个姓
                firstName = _seedFirstName[rnd.Next(_seedFirstName.Length - 1)];
                //随机取两个字作名字
                lasrName = _seedLastName.Substring(rnd.Next(0, _seedLastName.Length - 1), 1)
                    + _seedLastName.Substring(rnd.Next(0, _seedLastName.Length - 1), 1);
                return firstName + lasrName;
            }
        }
            private static void _GarbageClear()
        {
            //var dbcontext = new StuDBContext();
            //var students = dbcontext.Students.DistinctBy(x => x.FullName).ToList();
            ////
            //foreach (var stu in students)
            //    dbcontext.Students.Where(x => x.FirstName == stu.FullName &&
            //    x.ID != stu.ID).Delete();
          }
        }
    }