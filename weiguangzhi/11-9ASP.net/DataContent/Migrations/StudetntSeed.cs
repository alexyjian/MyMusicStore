using DataContext;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using MoreLinq;

namespace Migrations
{
    public class StudetntSeed
    {
        public static void Seed(StuDBContext context)
        {
            #region 电子信息学生
            var d1 = context.DepartMents.SingleOrDefault(x => x.Name == "电子信息工程学院");
            for (var i = 0; i < 400; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);

                var student = new Studetnt()
                {
                    StudentNo = "DZXX" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d1,
                    Phone = "188**********"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion

            #region 机电学生
            var d2 = context.DepartMents.SingleOrDefault(x => x.Name == "机电工程学院");
            for (var i = 0; i < 400; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);

                var student = new Studetnt()
                {
                    StudentNo = "JDGC" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d2,
                    Phone = "188**********"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion

            #region 汽车学生
            var d3 = context.DepartMents.SingleOrDefault(x => x.Name == "汽车工程学院");
            for (var i = 0; i < 300; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);

                var student = new Studetnt()
                {
                    StudentNo = "QCGC" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d3,
                    Phone = "188**********"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion

            #region 财经学生
            var d4 = context.DepartMents.SingleOrDefault(x => x.Name == "财经与物流学院");
            for (var i = 0; i < 300; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);

                var student = new Studetnt()
                {
                    StudentNo = "QCGC" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d4,
                    Phone = "188**********"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion

            context.SaveChanges();

        }

        /// <summary>
        /// 随机生成中文姓名
        /// </summary>
        /// <param name="firstName">姓</param>
        /// <param name="lasrName">名</param>
        /// <returns></returns>
        private static string _GetRandomChineseFullName(ref string firstName, ref string lasrName)
        {
            string[] _seedFirstName = new string[]
            {
                "李","王","张","刘","陈","杨","赵","黄","周","吴","徐","孙","胡","朱",
                "高","林","何","郭","马","罗","梁","宋","郑","谢","韩","唐","冯","于",
                "董","萧","程","曹","袁","邓","许","傅","沈","曾","彭","吕","苏","卢",
                "蒋","蔡","贾","丁","魏","薛","叶","阎","余","潘","杜","戴","夏","钟",
                "汪","田","任","姜","范","方","石","姚","谭","廖","邹","熊","金","陆",
                "郝","孔","白","崔","康","毛","邱","秦","江","史","顾","侯","邵","孟",
                "龙","万","段","雷","钱","汤","尹","黎","易","常","武","乔","贺","赖",
                "龚","文","庞","樊","兰","殷","施","陶","洪","翟","安","颜","倪","严",
                "牛","温","芦","季","俞","章","鲁","葛","伍","韦","申","尤","毕","聂",
                "丛","焦","向","柳","邢","骆","岳","齐","尚","梅","莫","庄","辛","管",
                "祝","左","涂","谷","祁","时","舒","耿","牟","卜","路","詹","关","苗",
                "凌","费","纪","靳","盛","童","欧","甄","项","曲","成","游","阳","裴",
                "席","卫","查","屈","鲍","位","覃","霍","翁","隋","植","甘","景","蒲",
                "单","包","司","柏","宁","柯","阮","桂","闵","欧","阳","解","强","柴",
                "华","车","冉","房","边","辜","吉","饶","刁","瞿","戚","丘","古","米",
                "池","滕","晋","苑","邬","臧","畅","宫","来","缪","苟","全","褚","廉",
                "简","娄","盖","符","奚","木","穆","党","燕","郎","邸","冀","谈","姬",
                "屠","连","郜","晏","栾","郁","商","蒙","计","喻","揭","窦","迟","宇",
                "敖","糜","鄢","冷","卓","花","仇","艾","蓝","都","巩","稽","井","练",
                "仲","乐","虞","卞","封","竺","冼","原","官","衣","楚","佟","栗","匡",
                "宗","应","台","巫","鞠","僧","桑","荆","谌","银","扬","明","沙","薄",
                "伏","岑","习","胥","保","和","蔺"


            };
            string _seedlastName = @"憇憈憉憊憋憌憍憎憏憐憑憒憓憔憕憖憗憘憙憚憛憜憝憞憟憠憡憢憣憤憥憦憧憨憩憪憫憬憭憮憯憰憱憲憳憴憵憶憷憸憹憺憻憼憽憾憿懀懁懂懃懄懅懆懇懈應懊懋懌懍懎懏懐懑懒懓懔懕懖懗懘懙懚懛懜懝懞懟懠懡懢懣懤懥懦懧懨懩懪懫懬懭懮懯懰懱懲懳懴懵懶懷懸懹懺懻懼懽懾懿戀戁戂戃戄戅戆戇戈戉戊戋戌戍戎戏成我戒戓戔戕或戗战戙戚戛戜戝戞戟戠戡戢戣戤戥戦戧戨戩截戫戬戭戮戯戰戱戲戳戴戵戶户戸戹戺戻戼戽戾房所扁扂扃扄扅扆扇扈扉扊手扌才扎扏扐扑扒打扔払扖扗托扙扚扛扜扝扞扟扠扡扢扣扤扥扦执扨扩扪扫扬扭扮扯扰扱扲扳扴扵扶扷扸批扺扻扼扽找承技抁抂抃抄抅抆抇抈抉把抋抌抍抎抏抐抑抒抓抔投抖抗折抙抚抛抜抝択抟抠抡抢抣护报抦抧抨抩抪披抬抭抮抯抰抱抲抳抴抵抶抷抸抹抺抻押抽抾抿拀拁拂拃拄担拆拇拈拉拊拋拌拍拎拏拐拑拒拓拔拕拖拗拘拙拚招拜拝拞拟拠拡拢拣拤拥拦拧拨择拪拫括拭拮拯拰拱拲拳拴拵拶拷拸拹拺拻拼拽拾拿挀持挂挃挄挅挆指挈按挊挋挌挍挎挏挐挑挒挓挔挕挖挗挘挙挚挛挜挝挞挟挠挡挢挣挤挥挦挧挨挩挪挫挬挭挮振挰挱挲挳挴挵挶挷挸挹挺挻挼挽挾挿捀捁捂捃捄捅捆捇捈捉捊捋捌捍捎捏捐捑捒捓捔捕捖捗捘捙捚捛捜捝捞损捠捡换捣捤捥捦捧捨捩捪捫捬捭据捯捰捱捲捳捴捵捶捷捸捹捺捻捼捽捾捿掀掁掂掃掄掅掆掇授掉掊掋掌掍掎掏掐掑排掓掔掕掖掗掘掙掚掛掜掝掞掟掠採探掣掤接掦控推掩措掫掬掭掮掯掰掱掲掳掴掵掶掷掸掹掺掻掼掽掾掿揀揁揂揃揄揅揆揇揈揉揊揋揌揍揎描提揑插揓揔揕揖揗揘揙揚換揜揝揞揟揠握揢揣揤揥揦揧揨揩揪揫揬揭揮揯揰揱揲揳援揵揶揷揸揹揺揻揼揽揾揿搀搁搂搃搄搅搆搇搈搉搊搋搌損搎搏搐搑搒搓搔搕搖搗搘搙搚搛搜搝搞搟搠搡搢搣搤搥搦搧搨搩搪搫搬搭搮搯搰搱搲搳搴搵搶搷搸搹携搻搼搽搾搿摀摁摂摃摄摅摆摇摈摉摊摋摌摍摎摏摐摑摒摓摔摕摖摗摘摙摚摛摜摝摞摟摠摡摢摣摤摥摦摧摨摩摪摫摬摭摮摯摰摱摲摳摴摵摶摷摸摹摺摻摼摽摾摿撀撁撂撃撄撅";

            var rnd = new Random(DateTime.Now.Millisecond);
            //随机取一个姓
            firstName = _seedFirstName[rnd.Next(_seedFirstName.Length - 1)];
            lasrName = _seedlastName.Substring(rnd.Next(0, _seedlastName.Length - 1), 1)
                + _seedlastName.Substring(rnd.Next(0, _seedlastName.Length - 1),1);
            return firstName + lasrName;
        }

        private static void _GarbageClear()

        {
            var dbcontext = new StuDBContext();
            var stulist = dbcontext.Students.DistinctBy(x => x.FullName).ToList();
            //删除查名
            foreach (var stu in stulist)
                dbcontext.Students.Where(x => x.FullName == stu.FullName && x.ID != stu.ID).Delete();
        }
    }
}
