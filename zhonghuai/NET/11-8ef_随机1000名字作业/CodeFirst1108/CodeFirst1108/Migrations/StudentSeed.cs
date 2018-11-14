using CodeFirst1108.DataContext;
using CodeFirst1108.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst1108.Migrations
{
    public class StudentSeed
    {
        public static void Seed(StuDBContext context)
        {
            for (var i = 0; i < 400; i++)
            {
                var fname = "";
                var lname = "";
                //var fullname = _GetRandomChineseFullName(ref fname, ref lname);

                 var student = new Student()
                {
                   
                   StudentNo = "DZXXGC" + i.ToString("0000"),
                    FirstName ="",
                    LastName = "",
                    FullName = _GetRandomChineseFullName(ref fname, ref lname),
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = context.DepartMent.SingleOrDefault(x => x.Name == "电子信息工程学院"),
                 Phone = "123456789"
                };
                context.Student.Add(student);
                Thread.Sleep(2);
            }
            //context.SaveChanges();
        }


        /// <summary>
        /// 随机生成中文名
        /// </summary>
        /// <param name="firstName">姓</param>
        /// <param name="lasrName">名</param>
        /// <returns></returns>

       public  static string _GetRandomChineseFullName(ref string firstName, ref string lasrName)
        {
            string[] _seedFirstName = new string[] {
                "王","李","张","刘","陈","杨","黄","吴","赵","周","徐","孙","马","朱","胡","林","郭","何","高",
                "罗","郑","梁","谢","宋","唐","许","邓","冯","韩","曹","曾","彭","萧","蔡","潘","田","董","袁",
                "于","余","叶","蒋","杜","苏","魏","程","吕","丁","沈","任","姚","卢","傅","钟","姜","崔","谭",
                "廖","范","汪","陆","金","石","戴","贾","韦","夏","邱","方","侯","邹","熊","孟","秦","白","江",
                "阎","薛","尹","段","雷","黎","史","龙","陶","贺","顾","毛","郝","龚","邵","万","钱","严","赖",
                "覃","洪","武","莫","孔","汤","向","常","温","康","施","文","牛","樊","葛","邢","安","齐","易",
                "乔","伍","庞","颜","倪","庄","聂","章","鲁","岳","翟","殷","詹","申","欧","耿","关","兰","焦",
                "俞","左","柳","甘","祝","包","宁","尚","符","舒","阮","柯","纪","梅","童","凌","毕","单","季",
                "裴","霍","涂","成","苗","谷","盛","曲","翁","冉","骆","蓝","路","游","辛","靳","欧","阳","管",
                "柴","蒙","鲍","华","喻","祁","蒲","房","滕","屈","饶","解","牟","艾","尤","阳","时","穆","农",
                "司","卓","古","吉","缪","简","车","项","连","芦","麦","褚","娄","窦","戚","岑","景","党","宫",
                "费","卜","冷","晏","席","卫","米","柏","宗","瞿","桂","全","佟","应","臧","闵","苟","邬","边",
                "卞","姬","师","和","仇","栾","隋","商","刁","沙","荣","巫","寇","桑","郎","甄","丛","仲","虞",
                "敖","巩","明","佘","池","查","麻","苑","迟","邝","官","封","谈","匡","鞠","惠","荆","乐","冀","郁","胥","南","班","储","原","栗",
                "燕","楚","鄢","劳","谌","奚","皮","粟","冼","蔺","楼","盘","满","闻","位","厉","伊","仝","区","郜","海","阚","花","权","强","帅",
                "屠","豆","朴","盖","练","廉","禹","井","祖","漆","巴","丰","支","卿","国","狄","平","计","索","宣","晋","相","初","门","云","容",
                "敬","来","扈","晁","芮","都","普","阙","浦","戈","伏","鹿","薄","邸","雍","辜","羊","阿","乌","母","裘","亓","修","邰","赫","杭",
                "况","那","宿","鲜","印","逯","隆","茹","诸","战","慕","危","玉","银","亢","嵇","公","哈","湛","宾","戎","勾","茅","利","於","呼",
                "居","揭","干","但","尉","冶","斯","元","束","檀","衣","信","展","阴","昝","智","幸","奉","植","衡","富","尧","闭","由"
            };

            string _seedLastName = @"哲莹泰秦艳恭真原倩偌倚倜兼益凌准陵陶都挽莱莲莫茶莉莓荷莜莎唏唤峰峻徒徐阅涛涟消浴浩海流涧润涕浪涩家宽宴容宾姬娟娥绣朗朕
侘昌抄弨扯忱承忡初垂佌刺儿庚刮戋金净侃刻侄孥妻戕青取叁刹姗疝尚舍社侁呻使始事受抒叔刷祀忪怂所兔昔穸些姓刖甾昃怎咋轧忮周妯咒宙侏抓宗卒绿晚黄猫船萤雪彩得着
常眼惜虚谚辆猪脚断停推敢淡啸绮密盖蚯球脸脱淋甜情唱啥梳象睁做救票梦领盛捧啄累梁铭教铜袋鹿掉渐梢粗理假蛋蛇惯绳";

            var rnd = new Random(DateTime.Now.Millisecond);
            //随机取一个姓
            firstName = _seedFirstName[rnd.Next(_seedFirstName.Length - 1)];

            lasrName = _seedLastName.Substring(rnd.Next(_seedLastName.Length - 1), 1)
                + _seedLastName.Substring(rnd.Next(0, _seedLastName.Length - 1), 1);
            return firstName + lasrName;

        }
    }
}

