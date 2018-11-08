﻿using CodeFirst1108.DataContext;
using CodeFirst1108.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using MoreLinq;

namespace CodeFirst1108.Migrations
{
    public class StudentSeed
    {
        public static void Seed(StuDBContext context)
        {
            #region 电子信息学生
            var d1 = context.DepartMents.SingleOrDefault(x => x.Name == "电子信息工程学院");
            for (var i = 0; i < 400; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname,ref lname);

                var student = new Student()
                {
                    StudentNo = "DZXX"+i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d1,
                    Phone = "188********"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion

            #region 机电学生
            var d2 = context.DepartMents.SingleOrDefault(x => x.Name == "机电工程学院");
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
                    Address = "社湾路28号",
                    Department = d2,
                    Phone = "188********"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion

            #region 汽车学生
            var d3 = context.DepartMents.SingleOrDefault(x => x.Name == "汽车工程学院");
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
                    Address = "社湾路28号",
                    Department = d3,
                    Phone = "188********"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion

            #region 贸易与旅游学生
            var d4 = context.DepartMents.SingleOrDefault(x => x.Name == "贸易与旅游学院");
            for (var i = 0; i < 200; i++)
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
                    Address = "社湾路28号",
                    Department = d4,
                    Phone = "188********"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            #endregion

            #region 机电学生
            var d5 = context.DepartMents.SingleOrDefault(x => x.Name == "财经与物流学院");
            for (var i = 0; i < 150; i++)
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
                    Address = "社湾路28号",
                    Department = d5,
                    Phone = "188********"
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
        /// <returns>姓名</returns>
        public static string _GetRandomChineseFullName(ref string firstName, ref string lasrName)
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
常眼惜虚谚辆猪脚断停推敢淡啸绮密盖蚯球脸脱淋甜情唱啥梳象睁做救票梦领盛捧啄累梁铭教铜袋鹿掉渐梢粗理假蛋蛇惯绳一丁丂七丄丅丆万丈三上下丌不与丏丐丑丒专且丕世丗丘丙业丛东丝丞丟丠両丢丣两严並丧丨丩个丫丬中丮丯丰丱串丳临丵丶丷丸丹为主丼丽举丿乀乁乂乃乄久乆乇么义乊之乌乍乎乏乐乑乒乓乔乕乖乗乘乙乚乛乜九乞也习乡乢乣乤乥书乧乨乩乪乫乬乭乮乯买乱乲乳乴乵乶乷乸乹乺乻乼乽乾乿亀亁亂亃亄亅了亇予争亊事二亍于亏亐云互亓五井亖亗亘亙亚些亜亝亞亟亠亡亢亣交亥亦产亨亩亪享京亭亮亯亰亱亲亳亴亵亶亷亸亹人亻亼亽亾亿什仁仂仃仄仅仆仇仈仉今介仌仍从仏仐仑仒仓仔仕他仗付仙仚仛仜仝仞仟仠仡仢代令以仦仧仨仩仪仫们仭仮仯仰仱仲仳仴仵件价仸仹仺任仼份仾仿伀企伂伃伄伅伆伇伈伉伊伋伌伍伎伏伐休伒伓伔伕伖众优伙会伛伜伝伞伟传伡伢伣伤伥伦伧伨伩伪伫伬伭伮伯估伱伲伳伴伵伶伷伸伹伺伻似伽伾伿佀佁佂佃佄佅但佇佈佉佊佋佌位低住佐佑佒体佔何佖佗佘余佚佛作佝佞佟你佡佢佣佤佥佦佧佨佩佪佫佬佭佮佯佰佱佲佳佴併佶佷佸佹佺佻佼佽佾使侀侁侂侃侄侅來侇侈侉侊例侌侍侎侏侐侑侒侓侔侕侖侗侘侙侚供侜依侞侟侠価侢侣侤侥侦侧侨侩侪侫侬侭侮侯侰侱侲侳侴侵侶侷侸侹侺侻侼侽侾便俀俁係促俄俅俆俇俈俉俊俋俌俍俎俏俐俑俒俓俔俕俖俗俘俙俚俛俜保俞俟俠信俢俣俤俥俦俧俨俩俪俫俬俭修俯俰俱俲俳俴俵俶俷俸俹俺俻俼俽俾俿倀倁倂倃倄倅倆倇倈倉倊個倌倍倎倏倐們倒倓倔倕倖倗倘候倚倛倜倝倞借倠倡倢倣値倥倦倧倨倩倪倫倬倭倮倯倰倱倲倳倴倵倶倷倸倹债倻值倽倾倿偀偁偂偃偄偅偆假偈偉偊偋偌偍偎偏偐偑偒偓偔偕偖偗偘偙做偛停偝偞偟偠偡偢偣偤健偦偧偨偩偪偫偬偭偮偯偰偱偲偳側偵偶偷偸偹偺偻偼偽偾偿傀傁傂傃傄傅傆傇傈傉傊傋傌傍傎傏傐傑傒傓傔傕傖傗傘備傚傛傜傝傞傟傠傡傢傣傤傥傦傧储傩傪傫催傭傮傯傰傱傲傳傴債傶傷傸傹傺傻傼傽傾傿僀僁僂僃僄僅僆僇僈僉僊僋僌働僎像僐僑僒僓僔僕僖僗僘僙僚僛僜僝僞僟僠僡僢僣僤僥僦僧僨僩僪僫僬僭僮僯僰僱僲僳僴僵僶僷僸價僺僻僼僽僾僿儀儁儂儃億儅儆儇儈儉儊儋儌儍儎儏儐儑儒儓儔儕儖儗儘儙儚儛儜儝儞償儠儡儢儣儤儥儦儧儨儩優儫儬儭儮儯儰儱儲儳儴儵儶儷儸儹儺儻儼儽儾儿兀允兂元兄充兆兇先光兊克兌免兎兏児兑兒兓兔兕兖兗兘兙党兛兜兝兞兟兠兡兢兣兤入兦內全兩兪八公六兮兯兰共兲关兴兵其具典兹兺养兼兽兾兿冀冁冂冃冄内円冇冈冉冊冋册再冎冏冐冑冒冓冔冕冖冗冘写冚军农冝冞冟冠冡冢冣冤冥冦冧冨冩冪冫冬冭冮冯冰冱冲决冴况冶冷冸冹冺冻冼冽冾冿净凁凂凃凄凅准凇凈凉凊凋凌凍凎减凐凑凒凓凔凕凖凗凘凙凚凛凜凝凞凟几凡凢凣凤凥処凧凨凩凪凫凬凭凮凯凰凱凲凳凴凵凶凷凸凹出击凼函凾凿刀刁刂刃刄刅分切刈刉刊刋刌刍刎刏刐刑划刓刔刕刖列刘则刚创刜初刞刟删刡刢刣判別刦刧刨利刪别刬刭刮刯到刱刲刳刴刵制刷券刹刺刻刼刽刾刿剀剁剂剃剄剅剆則剈剉削剋剌前剎剏剐剑剒剓剔剕剖剗剘剙剚剛剜剝剞剟剠剡剢剣剤剥剦剧剨剩剪剫剬剭剮副剰剱割剳剴創剶剷剸剹剺剻剼剽剾剿劀劁劂劃劄劅劆劇劈劉劊劋劌劍劎劏劐劑劒劓劔劕劖劗劘劙劚力劜劝办功加务劢劣劤劥劦劧动助努劫劬劭劮劯劰励劲劳労劵劶劷劸効劺劻劼劽劾势勀勁勂勃勄勅勆勇勈勉勊勋勌勍勎勏勐勑勒勓勔動勖勗勘務勚勛勜勝勞募勠勡勢勣勤勥勦勧勨勩勪勫勬勭勮勯勰勱勲勳勴勵勶勷勸勹勺勻勼勽勾勿匀匁匂匃匄包匆匇匈匉匊匋匌匍匎匏匐匑匒匓匔匕化北匘匙匚匛匜匝匞匟匠匡匢匣匤匥匦匧匨匩匪匫匬匭匮匯匰匱匲匳匴匵匶匷匸匹区医匼匽匾匿區十卂千卄卅卆升午卉半卋卌卍华协卐卑卒卓協单卖南単卙博卛卜卝卞卟占卡卢卣卤卥卦卧卨卩卪卫卬卭卮卯印危卲即却卵卶卷卸卹卺卻卼卽卾卿厀厁厂厃厄厅历厇厈厉厊压厌厍厎厏厐厑厒厓厔厕厖厗厘厙厚厛厜厝厞原厠厡厢厣厤厥厦厧厨厩厪厫厬厭厮厯厰厱厲厳厴厵厶厷厸厹厺去厼厽厾县叀叁参參叄叅叆叇又叉及友双反収叏叐发叒叓叔叕取受变叙叚叛叜叝叞叟叠叡叢口古句另叧叨叩只叫召叭叮可台叱史右叴叵叶号司叹叺叻叼叽叾叿吀吁吂吃各吅吆吇合吉吊吋同名后吏吐向吒吓吔吕吖吗吘吙吚君吜吝吞吟吠吡吢吣吤吥否吧吨吩吪含听吭吮启吰吱吲吳吴吵吶吷吸吹吺吻吼吽吾吿呀呁呂呃呄呅呆呇呈呉告呋呌呍呎呏呐呑呒呓呔呕呖呗员呙呚呛呜呝呞呟呠呡呢呣呤呥呦呧周呩呪呫呬呭呮呯呰呱呲味呴呵呶呷呸呹呺呻呼命呾呿咀咁咂咃咄咅咆咇咈咉咊咋和咍咎咏咐咑咒咓咔咕咖咗咘咙咚咛咜咝咞咟咠咡咢咣咤咥咦咧咨咩咪咫咬咭咮咯咰咱咲咳咴咵咶咷咸咹咺咻咼咽咾咿哀品哂哃哄哅哆哇哈哉哊哋哌响哎哏哐哑哒哓哔哕哖哗哘哙哚哛哜哝哞哟哠員哢哣哤哥哦哧哨哩哪哫哬哭哮哯哰哱哲哳哴哵哶哷哸哹哺哻哼哽哾哿唀唁唂唃唄唅唆唇唈唉唊唋唌唍唎唏唐唑唒唓唔唕唖唗唘唙唚唛唜唝唞唟唠唡唢唣唤唥唦唧唨唩唪唫唬唭售唯唰唱唲唳唴唵唶唷唸唹唺唻唼唽唾唿啀啁啂啃啄啅商啇啈啉啊啋啌啍啎問啐啑啒啓啔啕啖啗啘啙啚啛啜啝啞啟啠啡啢啣啤啥啦啧啨啩啪啫啬啭啮啯啰啱啲啳啴啵啶啷啸啹啺啻啼啽啾啿喀喁喂喃善喅喆喇喈喉喊喋喌喍喎喏喐喑喒喓喔喕喖喗喘喙喚喛喜喝喞喟喠喡喢喣喤喥喦喧喨喩喪喫喬喭單喯喰喱喲喳喴喵営喷喸喹喺喻喼喽喾喿嗀嗁嗂嗃嗄嗅嗆嗇嗈嗉嗊嗋嗌嗍嗎嗏嗐嗑嗒嗓嗔嗕嗖嗗嗘嗙嗚嗛嗜嗝嗞嗟嗠嗡嗢嗣嗤嗥嗦嗧嗨嗩嗪嗫嗬嗭嗮嗯嗰嗱嗲嗳嗴嗵嗶嗷嗸嗹嗺嗻嗼嗽嗾嗿嘀嘁嘂嘃嘄嘅嘆嘇嘈嘉嘊嘋嘌嘍嘎嘏嘐嘑嘒嘓嘔嘕嘖嘗嘘嘙嘚嘛嘜嘝嘞嘟嘠嘡嘢嘣嘤嘥嘦嘧嘨嘩嘪嘫嘬嘭嘮嘯嘰嘱嘲嘳嘴嘵嘶嘷嘸嘹嘺嘻嘼嘽嘾嘿噀噁噂噃噄噅噆噇噈噉噊噋噌噍噎噏噐噑噒噓噔噕噖噗噘噙噚噛噜噝噞噟噠噡噢噣噤噥噦噧器噩噪噫噬噭噮噯噰噱噲噳噴噵噶噷噸噹噺噻噼噽噾噿嚀嚁嚂嚃嚄嚅嚆嚇嚈嚉嚊嚋嚌嚍嚎嚏嚐嚑嚒嚓嚔嚕嚖嚗嚘嚙嚚嚛嚜嚝嚞嚟嚠嚡嚢嚣嚤嚥嚦嚧嚨嚩嚪嚫嚬嚭嚮嚯嚰嚱嚲嚳嚴嚵嚶嚷嚸嚹嚺嚻嚼嚽嚾嚿囀囁囂囃囄囅囆囇囈囉囊囋囌囍囎囏囐囑囒囓囔囕囖囗囘囙囚四囜囝回囟因囡团団囤囥囦囧囨囩囪囫囬园囮囯困囱囲図围囵囶囷囸囹固囻囼国图囿圀圁圂圃圄圅圆圇圈圉圊國圌圍圎圏圐圑園圓圔圕圖圗團圙圚圛圜圝圞土圠圡圢圣圤圥圦圧在圩圪圫圬圭圮圯地圱圲圳圴圵圶圷圸圹场圻圼圽圾圿址坁坂坃坄坅坆均坈坉坊坋坌坍坎坏坐坑坒坓坔坕坖块坘坙坚坛坜坝坞坟坠坡坢坣坤坥坦坧坨坩坪坫坬坭坮坯坰坱坲坳坴坵坶坷坸坹坺坻坼坽坾坿垀垁垂垃垄垅垆垇垈垉垊型垌垍垎垏垐垑垒垓垔垕垖垗垘垙垚垛垜垝垞垟垠垡垢垣垤垥垦垧垨垩垪垫垬垭垮垯垰垱垲垳垴垵垶垷垸垹垺垻垼垽垾垿埀埁埂埃埄埅埆埇埈埉埊埋埌埍城埏埐埑埒埓埔埕埖埗埘埙埚埛埜埝埞域埠埡埢埣埤埥埦埧埨埩埪埫埬埭埮埯埰埱埲埳埴埵埶執埸培基埻埼埽埾埿堀堁堂堃堄堅堆堇堈堉堊堋堌堍堎堏堐堑堒堓堔堕堖堗堘堙堚堛堜堝堞堟堠堡堢堣堤堥堦堧堨堩堪堫堬堭堮堯堰報堲堳場堵堶堷堸堹堺堻堼堽堾堿塀塁塂塃塄塅塆塇塈塉塊塋塌塍塎塏塐塑塒塓塔塕塖塗塘塙塚塛塜塝塞塟塠塡塢塣塤塥塦塧塨塩塪填塬塭塮塯塰塱塲塳塴塵塶塷塸塹塺塻塼塽塾塿墀墁墂境墄墅墆墇墈墉墊墋墌墍墎墏墐墑墒墓墔墕墖増墘墙墚墛墜墝增墟墠墡墢墣墤墥墦墧墨墩墪墫墬墭墮墯墰墱墲墳墴墵墶墷墸墹墺墻墼墽墾墿壀壁壂壃壄壅壆壇壈壉壊壋壌壍壎壏壐壑壒壓壔壕壖壗壘壙壚壛壜壝壞壟壠壡壢壣壤壥壦壧壨壩壪士壬壭壮壯声壱売壳壴壵壶壷壸壹壺壻壼壽壾壿夀夁夂夃处夅夆备夈変夊夋夌复夎夏夐夑夒夓夔夕外夗夘夙多夛夜夝夞够夠夡夢夣夤夥夦大夨天太夫夬夭央夯夰失夲夳头夵夶夷夸夹夺夻夼夽夾夿奀奁奂奃奄奅奆奇奈奉奊奋奌奍奎奏奐契奒奓奔奕奖套奘奙奚奛奜奝奞奟奠奡奢奣奤奥奦奧奨奩奪奫奬奭奮奯奰奱奲女奴奵奶奷奸她奺奻奼好奾奿妀妁如妃妄妅妆妇妈妉妊妋妌妍妎妏妐妑妒妓妔妕妖妗妘妙妚妛妜妝妞妟妠妡妢妣妤妥妦妧妨妩妪妫妬妭妮妯妰妱妲妳妴妵妶妷妸妹妺妻妼妽妾妿姀姁姂姃姄姅姆姇姈姉姊始姌姍姎姏姐姑姒姓委姕姖姗姘姙姚姛姜姝姞姟姠姡姢姣姤姥姦姧姨姩姪姫姬姭姮姯姰姱姲姳姴姵姶姷姸姹姺姻姼姽姾姿娀威娂娃娄娅娆娇娈娉娊娋娌娍娎娏娐娑娒娓娔娕娖娗娘娙娚娛娜娝娞娟娠娡娢娣娤娥娦娧娨娩娪娫娬娭娮娯娰娱娲娳娴娵娶娷娸娹娺娻娼娽娾娿婀婁婂婃婄婅婆婇婈婉婊婋婌婍婎婏婐婑婒婓婔婕婖婗婘婙婚婛婜婝婞婟婠婡婢婣婤婥婦婧婨婩婪婫婬婭婮婯婰婱婲婳婴婵婶婷婸婹婺婻婼婽婾婿媀媁媂媃媄媅媆媇媈媉媊媋媌媍媎媏媐媑媒媓媔媕媖媗媘媙媚媛媜媝媞媟媠媡媢媣媤媥媦媧媨媩媪媫媬媭媮媯媰媱媲媳媴媵媶媷媸媹媺媻媼媽媾媿嫀嫁嫂嫃嫄嫅嫆嫇嫈嫉嫊嫋嫌嫍嫎嫏嫐嫑嫒嫓嫔嫕嫖嫗嫘嫙嫚嫛嫜嫝嫞嫟嫠嫡嫢嫣嫤嫥嫦嫧嫨嫩嫪嫫嫬嫭嫮嫯嫰嫱嫲嫳嫴嫵嫶嫷嫸嫹嫺嫻嫼嫽嫾嫿嬀嬁嬂嬃嬄嬅嬆嬇嬈嬉嬊嬋嬌嬍嬎嬏嬐嬑嬒嬓嬔嬕嬖嬗嬘嬙嬚嬛嬜嬝嬞嬟嬠嬡嬢嬣嬤嬥嬦嬧嬨嬩嬪嬫嬬嬭嬮嬯嬰嬱嬲嬳嬴嬵嬶嬷嬸嬹嬺嬻嬼嬽嬾嬿孀孁孂孃孄孅孆孇孈孉孊孋孌孍孎孏子孑孒孓孔孕孖字存孙孚孛孜孝孞孟孠孡孢季孤孥学孧孨孩孪孫孬孭孮孯孰孱孲孳孴孵孶孷學孹孺孻孼孽孾孿宀宁宂它宄宅宆宇守安宊宋完宍宎宏宐宑宒宓宔宕宖宗官宙定宛宜宝实実宠审客宣室宥宦宧宨宩宪宫宬宭宮宯宰宱宲害宴宵家宷宸容宺宻宼宽宾宿寀寁寂寃寄寅密寇寈寉寊寋富寍寎寏寐寑寒寓寔寕寖寗寘寙寚寛寜寝寞察寠寡寢寣寤寥實寧寨審寪寫寬寭寮寯寰寱寲寳寴寵寶寷寸对寺寻导寽対寿尀封専尃射尅将將專尉尊尋尌對導小尐少尒尓尔尕尖尗尘尙尚尛尜尝尞尟尠尡尢尣尤尥尦尧尨尩尪尫尬尭尮尯尰就尲尳尴尵尶尷尸尹尺尻尼尽尾尿局屁层屃屄居屆屇屈屉届屋屌屍屎屏屐屑屒屓屔展屖屗屘屙屚屛屜屝属屟屠屡屢屣層履屦屧屨屩屪屫屬屭屮屯屰山屲屳屴屵屶屷屸屹屺屻屼屽屾屿岀岁岂岃岄岅岆岇岈岉岊岋岌岍岎岏岐岑岒岓岔岕岖岗岘岙岚岛岜岝岞岟岠岡岢岣岤岥岦岧岨岩岪岫岬岭岮岯岰岱岲岳岴岵岶岷岸岹岺岻岼岽岾岿峀峁峂峃峄峅峆峇峈峉峊峋峌峍峎峏峐峑峒峓峔峕峖峗峘峙峚峛峜峝峞峟峠峡峢峣峤峥峦峧峨峩峪峫峬峭峮峯峰峱峲峳峴峵島峷峸峹峺峻峼峽峾峿崀崁崂崃崄崅崆崇崈崉崊崋崌崍崎崏崐崑崒崓崔崕崖崗崘崙崚崛崜崝崞崟崠崡崢崣崤崥崦崧崨崩崪崫崬崭崮崯崰崱崲崳崴崵崶崷崸崹崺崻崼崽崾崿嵀嵁嵂嵃嵄嵅嵆嵇嵈嵉嵊嵋嵌嵍嵎嵏嵐嵑嵒嵓嵔嵕嵖嵗嵘嵙嵚嵛嵜嵝嵞嵟嵠嵡嵢嵣嵤嵥嵦嵧嵨嵩嵪嵫嵬嵭嵮嵯嵰嵱嵲嵳嵴嵵嵶嵷嵸嵹嵺嵻嵼嵽嵾嵿嶀嶁嶂嶃嶄嶅嶆嶇嶈嶉嶊嶋嶌嶍嶎嶏嶐嶑嶒嶓嶔嶕嶖嶗嶘嶙嶚嶛嶜嶝嶞嶟嶠嶡嶢嶣嶤嶥嶦嶧嶨嶩嶪嶫嶬嶭嶮嶯嶰嶱嶲嶳嶴嶵嶶嶷嶸嶹嶺嶻嶼嶽嶾嶿巀巁巂巃巄巅巆巇巈巉巊巋巌巍巎巏巐巑巒巓巔巕巖巗巘巙巚巛巜川州巟巠巡巢巣巤工左巧巨巩巪巫巬巭差巯巰己已巳巴巵巶巷巸巹巺巻巼巽巾巿帀币市布帄帅帆帇师帉帊帋希帍帎帏帐帑帒帓帔帕帖帗帘帙帚帛帜帝帞帟帠帡帢帣帤帥带帧帨帩帪師帬席帮帯帰帱帲帳帴帵帶帷常帹帺帻帼帽帾帿幀幁幂幃幄幅幆幇幈幉幊幋幌幍幎幏幐幑幒幓幔幕幖幗幘幙幚幛幜幝幞幟幠幡幢幣幤幥幦幧幨幩幪幫幬幭幮幯幰幱干平年幵并幷幸幹幺幻幼幽幾广庀庁庂広庄庅庆庇庈庉床庋庌庍庎序庐庑庒库应底庖店庘庙庚庛府庝庞废庠庡庢庣庤庥度座庨庩庪庫庬庭庮庯庰庱庲庳庴庵庶康庸庹庺庻庼庽庾庿廀廁廂廃廄廅廆廇廈廉廊廋廌廍廎廏廐廑廒廓廔廕廖廗廘廙廚廛廜廝廞廟廠廡廢廣廤廥廦廧廨廩廪廫廬廭廮廯廰廱廲廳廴廵延廷廸廹建廻廼廽廾廿开弁异弃弄弅弆弇弈弉弊弋弌弍弎式弐弑弒弓弔引弖弗弘弙弚弛弜弝弞弟张弡弢弣弤弥弦弧弨弩弪弫弬弭弮弯弰弱弲弳弴張弶強弸弹强弻弼弽弾弿彀彁彂彃彄彅彆彇彈彉彊彋彌彍彎彏彐彑归当彔录彖彗彘彙彚彛彜彝彞彟彠彡形彣彤彥彦彧彨彩彪彫彬彭彮彯彰影彲彳彴彵彶彷彸役彺彻彼彽彾彿往征徂徃径待徆徇很徉徊律後徍徎徏徐徑徒従徔徕徖得徘徙徚徛徜徝從徟徠御徢徣徤徥徦徧徨復循徫徬徭微徯徰徱徲徳徴徵徶德徸徹徺徻徼徽徾徿忀忁忂心忄必忆忇忈忉忊忋忌忍忎忏忐忑忒忓忔忕忖志忘忙忚忛応忝忞忟忠忡忢忣忤忥忦忧忨忩忪快忬忭忮忯忰忱忲忳忴念忶忷忸忹忺忻忼忽忾忿怀态怂怃怄怅怆怇怈怉怊怋怌怍怎怏怐怑怒怓怔怕怖怗怘怙怚怛怜思怞怟怠怡怢怣怤急怦性怨怩怪怫怬怭怮怯怰怱怲怳怴怵怶怷怸怹怺总怼怽怾怿恀恁恂恃恄恅恆恇恈恉恊恋恌恍恎恏恐恑恒恓恔恕恖恗恘恙恚恛恜恝恞恟恠恡恢恣恤恥恦恧恨恩恪恫恬恭恮息恰恱恲恳恴恵恶恷恸恹恺恻恼恽恾恿悀悁悂悃悄悅悆悇悈悉悊悋悌悍悎悏悐悑悒悓悔悕悖悗悘悙悚悛悜悝悞悟悠悡悢患悤悥悦悧您悩悪悫悬悭悮悯悰悱悲悳悴悵悶悷悸悹悺悻悼悽悾悿惀惁惂惃惄情惆惇惈惉惊惋惌惍惎惏惐惑惒惓惔惕惖惗惘惙惚惛惜惝惞惟惠惡惢惣惤惥惦惧惨惩惪惫惬惭惮惯惰惱惲想惴惵惶惷惸惹惺惻惼惽惾惿愀愁愂愃愄愅愆愇愈愉愊愋愌愍愎意愐愑愒愓愔愕愖愗愘愙愚愛愜愝愞感愠愡愢愣愤愥愦愧愨愩愪愫愬愭愮愯愰愱愲愳愴愵愶愷愸愹愺愻愼愽愾愿慀慁慂慃慄慅慆慇慈慉慊態慌慍慎慏慐慑慒慓慔慕慖慗慘慙慚慛慜慝慞慟慠慡慢慣慤慥慦慧慨慩慪慫慬慭慮慯慰慱慲慳慴慵慶慷慸慹慺慻慼慽慾慿憀憁憂憃憄憅憆";
            var rnd = new Random(DateTime.Now.Millisecond);
            //随机取一个姓
            firstName = _seedFirstName[rnd.Next(_seedFirstName.Length - 1)];
            //随机取两个字作名
            lasrName = _seedLastName.Substring(rnd.Next(0, _seedLastName.Length - 1), 1)
                + _seedLastName.Substring(rnd.Next(0, _seedLastName.Length - 1), 1);
            return firstName + lasrName;
        }

        private static void _GarbageClear()
        {
            var dbcontext = new StuDBContext();
            var students = dbcontext.Students.DistinctBy(x => x.FullName).ToList();
            //删除重名
            foreach (var stu in students)
                dbcontext.Students.Where(x => x.FullName == stu.FullName &&
                x.ID != stu.ID).Delete();
        }
    }
}