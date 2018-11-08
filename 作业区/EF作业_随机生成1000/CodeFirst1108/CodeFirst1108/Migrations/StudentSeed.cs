using CodeFirst1108.DataContext;
using CodeFirst1108.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MoreLinq;
using EntityFramework.Extensions;

namespace CodeFirst1108.Migrations
{
   public class StudentSeed
    {
        public static void Seed(StuDBContext context)
        {
            #region 电子信息工程学院
            var d1 = context.DepartMents.SingleOrDefault(x => x.Name=="电子信息工程学院");
            for (var i = 0; i < 400; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRanDomChinaseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "DZXX" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d1,
                    Phone = "186********"
                };
                context.Students.Add(student);
                Thread.Sleep(2);
            }
            #endregion
            #region 机电工程学院
            var d2 = context.DepartMents.SingleOrDefault(x => x.Name == "机电工程学院");
            for (var i = 0; i < 300; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRanDomChinaseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "JDGC" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d2,
                    Phone = "188********"
                };
                context.Students.Add(student);
                Thread.Sleep(3);
            }
            #endregion
            #region 汽车工程学院
            var d3 = context.DepartMents.SingleOrDefault(x => x.Name == "汽车工程学院");
            for (var i = 0; i < 100; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRanDomChinaseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "QCGC" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d3,
                    Phone = "188********"
                };
                context.Students.Add(student);
                Thread.Sleep(3);
            }
            #endregion
            #region 贸易与旅游学院
            var d4 = context.DepartMents.SingleOrDefault(x => x.Name == "贸易与旅游学院");
            for (var i = 0; i < 100; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRanDomChinaseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "MYLY" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d4,
                    Phone = "188********"
                };
                context.Students.Add(student);
                Thread.Sleep(3);
            }
            #endregion
            #region 财经与物流学院
            var d5 = context.DepartMents.SingleOrDefault(x => x.Name == "财经与物流学院");
            for (var i = 0; i < 100; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRanDomChinaseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "CJWL" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d5,
                    Phone = "188********"
                };
                context.Students.Add(student);
                Thread.Sleep(3);
            }
            #endregion
        }
        /// <summary>
        /// 随机生成中文名
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>姓名</returns>
        private static string _GetRanDomChinaseFullName(ref string firstName, ref string lastName)
        {
            string[] _seedFirstName = new string[]
            {
                "赵","钱","孙","李","周","吴","郑","王","冯","陈","褚","卫","蒋","沈","韩","杨","朱","秦","尤","许","何","吕","施","张","孔","曹","严","华","金","魏","陶","姜","戚","谢","邹","喻","柏","水","窦","章","云","苏","潘","葛","奚","范","彭","郎","鲁","韦","昌","马","苗","凤","花","方","俞","任","袁","柳","酆","鲍","史","唐","费","廉","岑","薛","雷","贺","倪","汤","滕","殷","罗","毕","郝","邬","安","常","乐","于","时","傅","皮","卞","齐","康","伍","余","元","卜","顾","孟","平","黄","和","穆","萧","尹","姚","邵","湛","汪","祁","毛","禹","狄","米","贝","明","臧","计","伏","成","戴","谈","宋","茅","庞","熊","纪","舒","屈","项","祝","董","梁","杜","阮","蓝","闵","席","季","麻","强","贾","路","娄","危","江","童","颜","郭","梅","盛","林","刁","钟","徐","邱","骆","高","夏","蔡","田","樊","胡","凌","霍","虞","万","支","柯","昝","管","卢","莫","经","房","裘","缪","干","解","应","宗","丁","宣","贲","邓","郁","单","杭","洪","包","诸","左","石","崔","吉","钮","龚","程","嵇","邢","滑","裴","陆","荣","翁","荀","羊","於","惠","甄","曲","家","封","芮","羿","储","靳","汲","邴","糜","松","井","段","富","巫","乌","焦","巴","弓","牧","隗","山","谷","车","侯","宓","蓬","全","郗","班","仰","秋","仲","伊","宫","宁","仇","栾","暴","甘","钭","厉","戎","祖","武","符","刘","景","詹","束","龙","叶","幸","司","韶","郜","黎","蓟","薄","印","宿","白","怀","蒲","邰","从","鄂","索","咸","籍","赖","卓","蔺","屠","蒙","池","乔","阴","鬱","胥","能","苍","双","闻","莘","党","翟","谭","贡","劳","逄","姬","申","扶","堵","冉","宰","郦","雍","卻","璩","桑","桂","濮","牛","寿","通","边","扈","燕","冀","郏","浦","尚","农","温","别","庄","晏","柴","瞿","阎","充","慕","连","茹","习","宦","艾","鱼","容","向","古","易","慎","戈","廖","庾","终","暨","居","衡","步","都","耿","满","弘","匡","国","文","寇","广","禄","阙","东","欧","殳","沃","利","蔚","越","夔","隆","师","巩","厍","聂","晁","勾","敖","融","冷","訾","辛","阚","那","简","饶","空","曾","毋","沙","乜","养","鞠","须","丰","巢","关","蒯","相","查","后","荆","红","游","竺","权","逯","盖","益","桓","公","万","俟","司","马","上","官","欧","阳","夏","侯","诸","葛","闻","人","东","方","赫","连","皇","甫","尉","迟","公","羊","澹","台","公","冶","宗","政","濮","阳","淳","于","单","于","太","叔","申","屠","公","孙","仲","孙","轩","辕","令","狐","钟","离","宇","文","长","孙","慕","容","鲜","于","闾","丘","司","徒","司","空","丌","官","司","寇","仉","督","子","车","颛","孙","端","木","巫","马","公","西","漆","雕","乐","正","壤","驷","公","良","拓","跋","夹","谷","宰","父","谷","梁","晋","楚","闫","法","汝","鄢","涂","钦","段","干","百","里","东","郭","南","门","呼","延","归","海","羊","舌","微","生","岳","帅","缑","亢","况","郈","有","琴","梁","丘","左","丘","东","门","西","门","商","牟","佘","佴","伯","赏","南","宫","墨","哈","谯","笪","年","爱","阳","佟"
            };
            string _seedLastName = @"伟刚勇毅俊峰强军平保东文辉力明永健世广志义兴良海山仁波宁贵福生龙元全国胜学祥才发武新利清飞彬富顺信子杰涛昌成康光天达安岩中茂进林振吉铭起凡凯珧骏凯华有坚和彪博诚先敬振壮会群豪心邦承乐绍功松善厚庆磊民友裕河哲江超亮政谦亨奇固之轮翰朗伯宏言若鸣朋斌梁栋维启克伦翔旭泽士以建家致树炎德行时泰盛雄琛钧澄邈德泽海超海阳海荣海逸海昌钰文涵亮涵煦涵蓄涵衍皛波博初震宕歌广邈气思言宝波博才畅诚良锋盛升杰乾维晟莱运鸿浩辰鹏曜昆星晨曦瀚畴达德飞风福光晖朗文轩煊骞远云哲祯志卓嘉康博振强振博振华振锐振光济澎湃彭泽池海浦和浦泽瑞渊越泽博耘德宇皓钊铭锟阳韦良沛轩涛濡潍爵腾睿泽然轩博凯振海振国振平昂然昂雄昂杰昂熙昌勋昌盛昌淼昌茂昌黎昌燎昌翰朗德明德昌德范明飞昂高旻晗日昊然昊天昊苍昊英昊宇昊嘉昊明昊伟昊硕昊磊昊东晖朗华晖金晋敬景明景天景俊晖君昊琦纬宇锐卉峰颉谊皓明杰雄纶涛煊之新旭彬旭尧旭旭东旭炎炫明宣朗学智轩昂彦昌坤栋文灿瑞智伟智杰智刚智阳昌勋昌盛昌茂昌黎昌燎昌翰朗昂然昂雄昂杰昂熙范明飞昂高朗高旻德明德昌德智伟智杰智刚智阳彭旭炎宣朗学智昊然昊天昊苍昊英昊宇昊嘉昊明昊伟朗华晖金晋敬景明景天景景行景中景逸景彰明杰雄纶涛煊景平俊晖君昊琦纬宇锐卉峰颉谊轩昂彦昌坤文灿瑞之新鑫旭彬旭尧旭旭东轩慨阔熙羲禧信泽洋泽雨哲胤佑允恒发云天耘志耘涛振荣振翱中子晗昱玥昂彭景行景中景逸景彰绍晖文景哲永昌子昂智宇智晖晗日晗昱昂昊硕昊磊昊东晖绍晖文昂文景哲永昌子昂智宇智晖然龙珹振宇高朗景平鑫昌淼炫明皓栋文昂昌勋礼骞振凯英武宣朗英勋永元乐音火景焕文兴怀景胜安澜景中智宇晋子实达修竹嘉勋良畴德义雨泽海超振华弘业嘉慕俊逸宏煊海英发和惬修然勇锐广子濯良才明轩承宣雨宸志健思桐姿竺世贾芷淇连波庆晔南熙钧君嘉轩韵至诚自政玉纳馨香泰兴洪蔚正杰同甫昌盛涵润梦丝畴长旭幻巧锐精祺福才良兴昌修诚高峻采薇和硕漠安康泰然嘉珍正文博容烨烨良材飞志行彭勃英豪飞舟成周念珍博易温茂韶阳蓉城弘量子平博涵亮华荣迎丝乐志英纵烨豪奕笛令秋智志弘毅泰平桂荣键铭宜民康顺修诚阳宇达云大雨晓奎宝丹兴邦天工刚豪嘉赐家铭磊
                                ";
            var rnd = new Random(DateTime.Now.Millisecond);
            firstName = _seedFirstName[rnd.Next(_seedFirstName.Length-1)];
            lastName = _seedLastName.Substring(rnd.Next(0, _seedLastName.Length - 1), 1) + _seedLastName.Substring(rnd.Next(0, _seedLastName.Length - 1), 1);
            return firstName + lastName;
        }
        private static void _GarbageClear()
        {
            var dbcontext = new StuDBContext();
            var stulist = dbcontext.Students.DistinctBy(x=>x.FullName).ToList();
            foreach (var stu in stulist)
                dbcontext.Students.Where(x => x.FullName == stu.FullName && x.ID != stu.ID).Delete();
               
        }
    }
}
