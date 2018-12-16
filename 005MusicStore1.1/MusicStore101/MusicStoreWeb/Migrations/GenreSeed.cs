using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace MusicStoreWeb.Migrations
{
    public class GenreSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();
        public static void Seed()
        {
            _dbContext.Database.ExecuteSqlCommand("delete albums");
            _dbContext.Database.ExecuteSqlCommand("delete artists");
            _dbContext.Database.ExecuteSqlCommand("delete genres");
            var genres = new List<Genre>()
            {
                new Genre() { Name="摇滚",Description = "Rock"},
                new Genre() { Name="爵士",Description = "Jazz"},
                new Genre() { Name="重金属",Description = "Metal"},
                new Genre() { Name="慢摇",Description = "DownTempo"},
                new Genre() { Name="蓝调",Description = "Blue"},
                new Genre() { Name="拉丁",Description = "Latin"},
                new Genre() { Name="流行",Description = "Pop"},
                new Genre() { Name="古典",Description = "Classical"},
                new Genre() { Name="DJ",Description = "DJ"},
                new Genre() { Name="嘻哈",Description ="HiHop"},
            };
            foreach (var g in genres)
                _dbContext.Genres.Add(g);


            var artists = new List<Artist>()
            {
                new Artist() { Name ="张惠妹",Sex = false,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                new Artist() { Name ="赵雷",Sex = true,Description = "民谣音乐人赵雷，中国内地新生代民谣歌手。1986年7月20日生于北京，高中时间接触音乐，开始学习吉他。年纪轻轻便踏遍祖国的大江南北，山河东西，足迹遍布陕甘、云藏，为自己的音乐之路，积累了大量时代底蕴与人文滋养。赵雷的音乐，虽然没有诗句般的柔情感动，但痞子气的调侃，单纯率直直达你的内心。词作、编曲朴实坦诚以描写生活中细微见长，每一首歌都像一部短剧，折射出他自己的生活、他眼中社会、甚至他心底的梦想，画面感极强。是最具传统北京胡同文化气质的新生代音乐人之一。"},
                new Artist() { Name ="老狼",Sex = true,Description = "中国大陆男歌手，音乐人。于1968年出生于音乐世家，从小就耳濡目染。1989年-1991年 加入中国第一支大学生摇滚乐队“青铜器”担任主唱。1991年—1991大地唱片公司唱片《校园民谣1》的录制，演唱《同桌的你》、《睡在我上铺的兄弟》及《流浪歌手的情人》三首主打歌。1994—1997年 《校园民谣1》发行近六十万张，签约风行音乐工作室。首张个人专辑《恋恋风尘》，专辑发行20天便创下了23万的销售记录，共发行40万张，成为当年中国国内歌手发行量最高的专辑。2000年2月 与华纳唱片签订唱片约，并与“麦田音乐”签订演艺合约。代表作品：《同桌的你》，《恋恋风尘》，《睡在我上铺的兄弟》。"},
                new Artist() { Name ="陈楚生",Sex = true,Description = "中国著名歌手、原创音乐人。2003年获得在长沙举行的全国PUB歌手大赛冠军。2007快乐男声获得全国总冠军走入走入大众视线并积累了高人气。2007年7月，发行首支单曲《有没有人告诉你》，11月8日，发行个人EP《原来我一直都不孤。2009年10月28日 陈楚生签约华谊兄弟。作为华语乐坛最具影响力男歌手之一，陈楚生在各大权威音乐奖项中多次获封“最佳男歌手”、“最佳唱作人”、“最佳创作歌手”等荣誉称号。代表作品：《有没有人告诉你》《 山楂花》《瘾》《 风起时想你》《 原来我一直都不孤单》。"},
                new Artist() { Name ="陶喆",Sex = false,Description = "“R&B音乐教父”，代表作《今天你要嫁给我》、《爱很简单》、《就是爱你》、《一念之间》、《Melody》、《爱我还是他》等。出道至今，陶喆已获得了内地及港台音乐演唱和制作的各类大奖。音乐已成为他最高追求，2013即将启动筹拍制作电影。"},
                new Artist() { Name ="蔡健雅",Sex = false,Description = "新加坡人，华语著名歌手、词曲作者，音乐制作人。1997年在新加坡由其经纪公司 Music & Movement 旗下的Yellow Music发行英语专辑《Bored》而正式出道，1999年将国语唱片签约于宝丽金唱片旗下，并推出首张国语同名专辑《蔡健雅》。2000年因宝丽金唱片并入环球唱片旗下，因此《记念》及之后的唱片皆由台湾环球唱片发行。在此一专辑中，蔡健雅以〈记念〉一曲成功打响在台湾市场的知名度。同年入围台湾第11届金曲奖最佳新人奖。2002年发行《Secret Lavender》专辑。同年以〈打错了〉作曲者身份入围台湾第13届金曲奖最佳作曲人奖，并同时入围最佳国语演唱人奖。2004年首度担任制作人，替梁咏琪制作《归属感》专辑。同年以《陌生人》获得台湾第15届金曲奖最佳国语女演唱人提名。2008年推出专辑《My Space》，同年获台湾第19届金曲奖7项提名，并获得了最佳专辑制作人和最佳国语女歌手两座大奖。近年移居台湾。2012年获最佳国语女歌手奖。代表作品：《呼吸》《陌生人》《空白格》《若你碰到他》《红色高跟鞋》。"},
                new Artist() { Name ="杨宗纬",Sex = true,Description = "大学时期参加台湾歌唱选秀节目《超级星光大道》获选为第一届“人气王”。比赛的时候，杨宗纬歌声阳刚而细腻，富含感情，辨识度高，感染力强，以演唱抒情歌曲见长，选曲跨越性别界线，无论是男女歌手的抒情歌曲，经过他重新诠释之后，常常都可以得到不输原唱或甚至超越原唱的评价。出道后屡创多项记录，包括发行首张专辑，便以新人之姿登上台北小巨蛋举办个人演唱会，也是唯一一位创下2年内包办“三金一亚”（台湾金曲奖，金钟奖，金马奖及亚太影展）颁奖典礼演唱嘉宾的歌手。歌声阳刚而细腻，有高度感染力与辨识度，富含感情，被誉为“催泪歌神”，又昵称“鸽王”。"},
                new Artist() { Name ="G.E.M.邓紫棋",Sex = false,Description = "邓紫棋成长于一个音乐世家，其母亲为上海音乐学院声乐系毕业生，外婆教唱歌，舅父拉小提琴，外公在乐团吹色士风。在家人的熏陶下，自小便热爱音乐，喜爱唱歌，与音乐结下不解之缘。G.E.M.在5岁的时候已经开始尝试作曲及填词，13岁完成了8级钢琴。G.E.M.在小学时期就读位于太子道西的中华基督教会协和小学上午校，为2003年的毕业生，同时亦为校内诗歌班成员。其英文名G.E.M.是Get Everybody Moving的缩写，象徵著她希望透过音乐让大家动起来的梦想。2008年出道，2009年在叱咤乐坛流行榜颁奖典礼夺得女新人奖金奖，亦是该奖项历年来最年轻，以及第一位未成年的得奖者。因其广阔的音域，得到不少前辈歌手点名公开赞扬。2014年她参加湖南卫视《我是歌手》第二季名声大震。"},
                new Artist() { Name ="林宥嘉",Sex = true,Description = "林宥嘉（英文名：Yoga Lin，1987年7月1日－）是台湾著名男歌手。出生于台湾屏东县，是家中长子，有一弟一妹，家里经营建材生意。林宥嘉考上凤山高中后搬到高雄居住，高中毕业后就读于国立东华大学运动与休闲学系。2007年7月6日以20岁大学生的身份，获得台湾中视主办的歌唱选秀节目第一届《超级星光大道》冠军，并与华研国际音乐签约成为歌手。演唱歌曲有《你把我灌醉》《悬崖》《我爱的人》《你是我的眼》等。曾获第十届CCTV-MTV音乐盛典港澳台地区年度最受欢迎潜力歌手奖。林宥嘉拥有独特的声线和极佳的唱功，人称“迷幻唱腔”，“迷幻王子”。代表作包括《说谎》、《伯乐》、《我总是一个人在练习一个人》、《诱》、《自然醒》、《想自由》、《心酸》、《残酷月光》等。2017年5月16日入围金曲奖最佳男歌手奖。"},
                new Artist() { Name ="薛之谦",Sex = true,Description = "薛之谦（Joker Xue），1983年7月17日出生于上海，华语流行乐男歌手、影视演员、音乐制作人，毕业于格里昂酒店管理学院。 2005年，参加选秀节目《我型我秀》正式出道 。2006年，发行首张同名专辑《薛之谦》，随后凭借歌曲《认真的雪》获得广泛关注。2008年，发行专辑《深深爱过你》并在上海举行个人首场演唱会“谦年传说” 。2013年，专辑《几个薛之谦》获得MusicRadio中国TOP排行榜内地推荐唱片。2014年，专辑《意外》获得第21届东方风云榜颁奖最佳唱作人 ；2015年6月，薛之谦首度担当制作人并发行原创EP《绅士》，2016年，凭借EP《绅士》、《一半》获得第16届全球华语歌曲排行榜多项奖项，而歌曲《初学者》则获得年度二十大金曲奖。2017年4月，开启“我好像在哪见过你”全国巡回演唱会。"},
                new Artist() { Name ="花粥",Sex = false,Description = "花粥是一名优秀的少先队员，英雄联盟召唤师，完全贯彻社会主义核心价值观的神秘地下音乐工作者。"},
                new Artist() { Name ="李荣浩",Sex = true,Description = "李荣浩，1985年7月11日生于蚌埠，中国流行音乐制作人、歌手、吉他手。曾为众多艺人创作歌曲以及担任制作人，也曾为多部电影与多款电子游戏制作音乐。2013年9月17日发行个人首张原创专辑《模特》，凭借这张专辑入围第25届金曲奖最佳国语男歌手奖、最佳新人奖、最佳专辑制作人、最佳国语专辑、最佳作词奖等五项大奖提名，成为最大黑马，实现了从制作人到歌手的华丽转身。"},
                new Artist() { Name ="王力宏",Sex = true,Description = "中国著名流行歌手、词曲创作音乐人；亚洲华语流行乐坛最具代表性的创作、偶像、实力派音乐偶像巨星。1995年发行首张专辑《情敌贝多芬》在台湾出道，亦是金曲奖中最年轻的封王者，其唱片总销量在全亚洲已超过2500万张。从改编歌曲《龙的传人》融合西方电子节奏和东方旋律的华人中式嘻哈风，再到为华语流行乐注入新元素，进一步将其推向全世界。超高唱片销量便可以证明力宏的影响力毋庸置疑的强。况且身为金曲奖常客，3次接受CNN电视台访问。首创Chinked-out曲风，将中国风推向世界，又用自己写的歌揭露了娱乐圈的众多丑闻，都可以表现他对华语乐坛的巨大贡献。亦参与多部电影工作，2010年进军影坛，首部自导自演的电影《恋爱通告》票房纪录突破5000万，成为票房冠军，其导演才华受到了广大好评。"},
                new Artist() { Name ="张杰",Sex = true,Description = "华语歌坛新生代领军人物，偶像与实力兼具的超人气天王。2004年出道至今，已发行9张高品质唱片，唱片销量称冠内地群雄。2008年以来举办过9场爆满的个人演唱会，在各大权威音乐奖项中先后21次获得“最受欢迎男歌手”称号，2012年度中国TOP排行榜内地最佳男歌手，2010年在韩国M-net亚洲音乐大赏(MAMA)上获得“亚洲之星”（Best Asian Artist）大奖，影响力触及海外。2010年作为歌手代表受邀担任博鳌亚洲论坛表演嘉宾。2012年在北京人民大会堂开启了巡演的历程，同年捐资200万作为北斗星空爱心基金创始基金，并启动“张杰音乐梦想教室”公益项目，自2012年10月份起已陆续在全国各地建立了六所“张杰音乐梦想教室”。"},
                new Artist() { Name ="周杰伦",Sex = true,Description = "著名歌手，音乐人，词曲创作人，编曲及制作人，MV及电影导演。新世纪华语歌坛领军人物，中国风歌曲始祖，被时代周刊誉为“亚洲猫王”，是2000年后亚洲流行乐坛最具革命性与指标性的创作歌手，亚洲销量超过3100万张，有“亚洲流行天王”之称，开启华语乐坛“R&B时代”与“流行乐中国风”的先河，周杰伦的出现打破了亚洲流行乐坛长年停滞不前的局面，为亚洲流行乐坛翻开了新的一页，是华语乐坛真正把R&B提升到主流高度的人物，引领华语乐坛革命整十年，改写了华语乐坛的流行方向。"},
                new Artist() { Name ="王菲",Sex = false,Description = "中国著名女歌手、演员。是继邓丽君后大中华地区成就最高、影响力最大的华语女歌手。以其极具辨识度的天籁空灵般嗓音，在华语歌坛创造了属于她自己的时代。她是首位登上美国《时代周刊》封面并接受CNN专访的华语歌手。她是身价最高，演唱会上座率最高，演唱会票房累计最高的华语女歌手。王菲北京出生。1987年放弃厦门大学生物系的录取跟随父母移居香港，并拜师戴思聪学习声乐，1989年签约新艺宝唱片公司并发行了第一张个人专辑，从此正式步入乐坛，曾使用艺名王靖雯。她于1994年在香港红馆第一次举办演唱会，就以连续18场的纪录打破新人红馆演唱会纪录，至今仍未有人打破。王菲自2005年逐渐淡出歌坛，2010-2012年开始复出大规模巡回演唱会。代表作品：《我愿意》《执迷不悔》《天空》《红豆》《流年》《催眠》。"},
                new Artist() { Name ="蔡依林",Sex = false,Description = "中国台湾著名流行女歌手。1999年在台湾地区出道，被媒体冠以“少男杀手”称号，于7月份推出了第一支个人单曲EP《和世界做邻居》，9月正式推出首张国语专辑《Jolin 1019》，知名度迅速上升，获得大量人气。当时与孙燕姿、萧亚轩、梁静茹并称台湾四小天后。2003年3月，推出转型作品《看我72变》专辑，获得巨大成功。2007年受颁第十八届台湾金曲奖最佳国语女演唱人。2008年，《Love Love Love》在中国北京奥运会赛场的强力播送下空降荷兰X-Tips单曲榜冠军，并打破历史指数纪录，成为首位夺冠的亚洲歌手。后被法国杂志《亚洲音乐》评选为十位亚洲最佳女歌手之一，且是唯一一位华人歌手。蔡依林出道至今多次担任唱片的歌词创作，参与演唱会策划及MV制作。代表作品：《说爱你》、《看我72变》、《爱情36计》、《大艺术家》、《舞娘》、《日不落》、《美人计》。"},
                new Artist() { Name ="徐佳莹",Sex = false,Description = "华语流行音乐创作女歌手、金曲奖得主。1984年12月20日生于台湾台中市，籍贯四川省简阳县。"},
            };
            foreach (var a in artists)
                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();

            //使用Lamda代替foreach
            new List<Album>
            {
                new Album { Title ="人质",Genre = genres.Single(g =>g.Name =="摇滚"),Price = 8.99M,Artist = artists.Single(a => a.Name =="张惠妹"),AlbumArtUrl = "/Content/Images/ZHMprint1.jpg"},
                new Album { Title ="母系社会",Genre = genres.Single(g =>g.Name =="摇滚"),Price = 8.99M,Artist = artists.Single(a => a.Name =="张惠妹"),AlbumArtUrl = "/Content/Images/ZHMprint2.jpg"},
                new Album { Title ="三天三夜",Genre = genres.Single(g =>g.Name =="摇滚"),Price = 8.99M,Artist = artists.Single(a => a.Name =="张惠妹"),AlbumArtUrl = "/Content/Images/ZHMprint3.jpg"},
                new Album { Title ="三月",Genre = genres.Single(g =>g.Name =="摇滚"),Price = 8.99M,Artist = artists.Single(a => a.Name =="张惠妹"),AlbumArtUrl = "/Content/Images/ZHMprint4.jpg"},
                new Album { Title ="成都",Genre = genres.Single(g =>g.Name =="摇滚"),Price = 8.99M,Artist = artists.Single(a => a.Name =="赵雷"),AlbumArtUrl = "/Content/Images/ZLprint1.jpg"},
                new Album { Title ="啊刁",Genre = genres.Single(g =>g.Name =="摇滚"),Price = 8.99M,Artist = artists.Single(a => a.Name =="赵雷"),AlbumArtUrl = "/Content/Images/ZLprint2.jpg"},
                new Album { Title ="无法长大",Genre = genres.Single(g =>g.Name =="摇滚"),Price = 8.99M,Artist = artists.Single(a => a.Name =="赵雷"),AlbumArtUrl = "/Content/Images/ZLprint3.jpg"},
                new Album { Title ="十九岁",Genre = genres.Single(g =>g.Name =="摇滚"),Price = 8.99M,Artist = artists.Single(a => a.Name =="赵雷"),AlbumArtUrl = "/Content/Images/ZLprint4.jpg"},
                new Album { Title ="家乡",Genre = genres.Single(g =>g.Name =="摇滚"),Price = 8.99M,Artist = artists.Single(a => a.Name =="赵雷"),AlbumArtUrl = "/Content/Images/ZLprint5.jpg"},
                new Album { Title ="北京的冬天",Genre = genres.Single(g =>g.Name =="摇滚"),Price = 8.99M,Artist = artists.Single(a => a.Name =="赵雷"),AlbumArtUrl = "/Content/Images/ZLprint6.jpg"},
                new Album { Title ="同桌的你",Genre = genres.Single(g =>g.Name =="爵士"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="青春在见",Genre = genres.Single(g =>g.Name =="爵士"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="在路上",Genre = genres.Single(g =>g.Name =="爵士"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="米店",Genre = genres.Single(g =>g.Name =="爵士"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="礼物",Genre = genres.Single(g =>g.Name =="爵士"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="老狼"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="风起时，想你",Genre = genres.Single(g =>g.Name =="爵士"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="陈楚生"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="我知道你离我不远",Genre = genres.Single(g =>g.Name =="爵士"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="陈楚生"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="自己的太阳",Genre = genres.Single(g =>g.Name =="爵士"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="陈楚生"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="醉",Genre = genres.Single(g =>g.Name =="爵士"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="陈楚生"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="一夜知秋",Genre = genres.Single(g =>g.Name =="爵士"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="陈楚生"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="就是爱你",Genre = genres.Single(g =>g.Name =="重金属"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="陶喆"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="爱很简单",Genre = genres.Single(g =>g.Name =="重金属"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="陶喆"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="小镇姑娘",Genre = genres.Single(g =>g.Name =="重金属"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="陶喆"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="一念之间",Genre = genres.Single(g =>g.Name =="重金属"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="陶喆"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="我们的故事",Genre = genres.Single(g =>g.Name =="重金属"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="陶喆"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="红色高跟鞋",Genre = genres.Single(g =>g.Name =="重金属"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="越来越不懂",Genre = genres.Single(g =>g.Name =="重金属"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="陌生人",Genre = genres.Single(g =>g.Name =="重金属"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="别找我麻烦",Genre = genres.Single(g =>g.Name =="重金属"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="空白格",Genre = genres.Single(g =>g.Name =="重金属"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="其实都没有",Genre = genres.Single(g =>g.Name =="慢摇"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="杨宗纬"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="国王与乞丐",Genre = genres.Single(g =>g.Name =="慢摇"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="杨宗纬"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="那个男人",Genre = genres.Single(g =>g.Name =="慢摇"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="杨宗纬"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="初爱",Genre = genres.Single(g =>g.Name =="慢摇"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="杨宗纬"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="忘了我",Genre = genres.Single(g =>g.Name =="慢摇"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="杨宗纬"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="再见",Genre = genres.Single(g =>g.Name =="慢摇"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="G.E.M.邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="喜欢你",Genre = genres.Single(g =>g.Name =="慢摇"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="G.E.M.邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="泡沫",Genre = genres.Single(g =>g.Name =="慢摇"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="G.E.M.邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="A.I.N.Y 爱你",Genre = genres.Single(g =>g.Name =="慢摇"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="G.E.M.邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="多远都要在一起",Genre = genres.Single(g =>g.Name =="慢摇"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="G.E.M.邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="说谎",Genre = genres.Single(g =>g.Name =="蓝调"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="林宥嘉"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="成全",Genre = genres.Single(g =>g.Name =="蓝调"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="林宥嘉"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="浪费",Genre = genres.Single(g =>g.Name =="蓝调"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="林宥嘉"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="心酸",Genre = genres.Single(g =>g.Name =="蓝调"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="林宥嘉"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="想自由",Genre = genres.Single(g =>g.Name =="蓝调"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="林宥嘉"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="演员",Genre = genres.Single(g =>g.Name =="蓝调"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="薛之谦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="意外",Genre = genres.Single(g =>g.Name =="蓝调"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="薛之谦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="暧昧",Genre = genres.Single(g =>g.Name =="蓝调"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="薛之谦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="刚刚好",Genre = genres.Single(g =>g.Name =="蓝调"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="薛之谦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="绅士",Genre = genres.Single(g =>g.Name =="蓝调"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="薛之谦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="盗将行",Genre = genres.Single(g =>g.Name =="拉丁"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="花粥"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="出山",Genre = genres.Single(g =>g.Name =="拉丁"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="花粥"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="纸短情长",Genre = genres.Single(g =>g.Name =="拉丁"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="花粥"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="遥不可及的你",Genre = genres.Single(g =>g.Name =="拉丁"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="花粥"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="活该",Genre = genres.Single(g =>g.Name =="拉丁"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="花粥"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="李白",Genre = genres.Single(g =>g.Name =="拉丁"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="李荣浩"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="模特",Genre = genres.Single(g =>g.Name =="拉丁"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="李荣浩"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="作曲家",Genre = genres.Single(g =>g.Name =="拉丁"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="李荣浩"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="念念又不忘",Genre = genres.Single(g =>g.Name =="拉丁"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="李荣浩"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="我知道是你",Genre = genres.Single(g =>g.Name =="拉丁"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="李荣浩"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="好心分手",Genre = genres.Single(g =>g.Name =="流行"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="王力宏"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="爱一点",Genre = genres.Single(g =>g.Name =="流行"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="王力宏"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="唯一",Genre = genres.Single(g =>g.Name =="流行"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="王力宏"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="大城小爱",Genre = genres.Single(g =>g.Name =="流行"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="王力宏"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="我们的故事",Genre = genres.Single(g =>g.Name =="流行"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="王力宏"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="他不懂",Genre = genres.Single(g =>g.Name =="流行"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="这，就是爱",Genre = genres.Single(g =>g.Name =="流行"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="仰望星空",Genre = genres.Single(g =>g.Name =="流行"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="逆战",Genre = genres.Single(g =>g.Name =="流行"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="夜空中最亮的星",Genre = genres.Single(g =>g.Name =="流行"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="一路向北",Genre = genres.Single(g =>g.Name =="流行"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="七里香",Genre = genres.Single(g =>g.Name =="古典"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="轨迹",Genre = genres.Single(g =>g.Name =="古典"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="说话的幸福呢",Genre = genres.Single(g =>g.Name =="古典"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="彩虹",Genre = genres.Single(g =>g.Name =="古典"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="匆匆那年",Genre = genres.Single(g =>g.Name =="古典"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="王菲"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="因为爱情",Genre = genres.Single(g =>g.Name =="古典"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="王菲"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="红豆",Genre = genres.Single(g =>g.Name =="古典"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="王菲"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="传奇",Genre = genres.Single(g =>g.Name =="古典"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="王菲"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="容易受伤的女人",Genre = genres.Single(g =>g.Name =="古典"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="王菲"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="倒带",Genre = genres.Single(g =>g.Name =="古典"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="蔡依林"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="今天你要嫁给我",Genre = genres.Single(g =>g.Name =="DJ"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="蔡依林"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="日不落",Genre = genres.Single(g =>g.Name =="DJ"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="蔡依林"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="天空",Genre = genres.Single(g =>g.Name =="DJ"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="蔡依林"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="柠檬草的味道",Genre = genres.Single(g =>g.Name =="DJ"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="蔡依林"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="最美的遇见",Genre = genres.Single(g =>g.Name =="DJ"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="失落沙洲",Genre = genres.Single(g =>g.Name =="DJ"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="突然好想你",Genre = genres.Single(g =>g.Name =="DJ"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="最初的记忆",Genre = genres.Single(g =>g.Name =="DJ"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="太难",Genre = genres.Single(g =>g.Name =="DJ"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album { Title ="不能说的秘密",Genre = genres.Single(g =>g.Name =="DJ"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/ZJLprint9.png"},
                new Album { Title ="安静",Genre = genres.Single(g =>g.Name =="嘻哈"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/ZJLprint12.png"},
                new Album { Title ="爱情废柴",Genre = genres.Single(g =>g.Name =="嘻哈"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/ZJLprint11.png"},
                new Album { Title ="稻香",Genre = genres.Single(g =>g.Name =="嘻哈"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/ZJLprint10.png"},
                new Album { Title ="告别气球",Genre = genres.Single(g =>g.Name =="嘻哈"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/ZJLprint7.png"},
                new Album { Title ="搁浅",Genre = genres.Single(g =>g.Name =="嘻哈"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/ZJLprint8.png"},
                new Album { Title ="龙卷风",Genre = genres.Single(g =>g.Name =="嘻哈"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/ZJLprint6.png"},
                new Album { Title ="明明就",Genre = genres.Single(g =>g.Name =="嘻哈"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/ZJLprint5.png"},
                new Album { Title ="蒲公英的约定",Genre = genres.Single(g =>g.Name =="嘻哈"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/ZJLprint4.png"},
                new Album { Title ="算什么男人",Genre = genres.Single(g =>g.Name =="嘻哈"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/ZJLprint3.png"},
                new Album { Title ="我不配",Genre = genres.Single(g =>g.Name =="嘻哈"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/ZJLprint2.png"},
                new Album { Title ="千里之外",Genre =genres.Single(g =>g.Name =="流行"),Price = 8.99M,Artist = artists.Single(a =>a.Name =="周杰伦"),AlbumArtUrl="/Content/Images/ZJLprint1.png"},
            }.ForEach(n => _dbContext.Albums.Add(n));

            _dbContext.SaveChanges();
        }

        //给Genreld和ArtistId赋值
        public static void Extend()
        {
            var albums = _dbContext.Albums.ToList();
            foreach (var album in albums)
            {
                var item = _dbContext.Albums.Find(album.ID);
                item.Genreld = item.Genre.ID.ToString();
                item.ArtistId = item.Artist.ID.ToString();
                _dbContext.SaveChanges();
                Thread.Sleep(3);
            }
        }
    }
}