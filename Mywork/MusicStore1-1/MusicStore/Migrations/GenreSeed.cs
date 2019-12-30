using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace MusicStore.Migrations
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
                new Genre() {Name="摇滚" ,Description="Rock"},
                new Genre() {Name="流行" ,Description="Pop"},
                new Genre() {Name="蓝调",Description="Blue" },
                new Genre() {Name="爵士" ,Description="Jazz"},
                new Genre() {Name="重金属",Description="Metal" },
                new Genre() {Name="古典" ,Description="Classical"},
                new Genre() {Name="嘻哈",Description="HiHop" },
            };

            foreach (var g in genres)
                _dbContext.Genres.Add(g);


            var artists = new List<Artist>
            {
                new Artist() {Name="李霄云",Sex=false,Description="录音室专辑：《正常人》《房间1501》《你看到的我是蓝色的》 自驾全国旅行创作：《三十禁流浪巡展》 艺术及合作：《虚无-视觉装置展》《恋爱世纪-舞台剧》《STRONG ENGLISH-电台》" },
                new Artist() {Name="花粥",Sex=false,Description="花粥是一名优秀的少先队员，英雄联盟召唤师，完全贯彻社会主义核心价值观的神秘地下音乐工作者。" },
                new Artist() {Name="Alan Walker",Sex=true,Description="艾兰·奥拉夫·沃克（Alan Olav Walker），1997年8月24日出生于英国英格兰北安普敦郡，挪威DJ、音乐制作人。 2014年11月，在YouTube上推出个人电音作品《Fade》而出道。2015年12月，通过索尼音乐发行个人第一首正式单曲《Faded》，该首歌曲的MV在YouTube上的点击量突破了12亿。2016年6月，发行人声伴唱电音单曲《Sing Me To Sleep》 。同年11月6日，获得MTV欧洲音乐奖“最佳挪威艺人”奖[4] 。2017年2月22日，《Faded》入围第37届全英音乐奖“年度英国单曲”奖 。同年5月，发布首支由男声伴唱的电音作品《Tired》 。" },
                new Artist() {Name="陈奕迅",Sex=true,Description="著名实力派粤语流行音乐歌手、演员，香港演艺人协会副会长之一，曾被美国《时代杂志》形容为影响香港乐坛风格的人物，同时也是继许冠杰、张学友之后第三个获得“歌神”称号的香港男歌手。同时他也是继张学友后另一个在台湾获得成功的香港歌手，在2003年他成为了第二个拿到台湾金曲奖“最佳国语男演唱人”的香港歌手。陈奕迅曾被《时代》杂志形容为影响香港乐坛风格的人物。2010年，陈奕迅入选全球华人音乐殿堂华语金曲奖“30年经典评选”，成为1990年代出道歌手唯一代表。陈奕迅曾在多个亚太地区获得多个奖项和提名，包括香港地区的“叱咤乐坛男歌手金奖”、“叱咤乐坛我最喜爱的男歌手奖”、“十大劲歌金曲最受欢迎男歌星奖”。代表作品：《爱情转移》、《十年》、《浮夸》、《K歌之王》。" },
                new Artist() {Name="林俊杰",Sex=true,Description="著名男歌手，作曲人、作词人、音乐制作人，偶像与实力兼具。林俊杰出生于新加坡的一个音乐世家。在父母的引导下，4岁就开始学习古典钢琴，不善言辞的他由此发现了另一种与人沟通的语言。小时候的林俊杰把哥哥林俊峰当作偶像，跟随哥哥的步伐做任何事，直到接触流行音乐后，便爱上创作这一条路。2003年以专辑《乐行者》出道，2004年一曲《江南》红遍两岸三地，凭借其健康的形象，迷人的声线，出众的唱功，卓越的才华，迅速成为华语流行乐坛的领军人物之一，迄今为止共创作数百首音乐作品，唱片销量在全亚洲逾1000万张。2007年成立个人音乐制作公司JFJ，2008创立潮流品牌SMG。2011年被媒体封为“新四大天王”之一，同年8月8日正式加盟华纳音乐，开启事业新乐章。2012年发行故事影像书《记得》，成功跻身畅销书作家行列。获得多项奖项：第15届台湾金曲奖最佳新人奖，6届新加坡金曲奖大奖，6届新加坡词曲版权协会大奖，8届全球华语歌曲排行榜大奖，5届MusicRadio中国TOP排行榜大奖。" },
                new Artist() {Name="邓紫棋",Sex=false,Description="邓紫棋成长于一个音乐世家，其母亲为上海音乐学院声乐系毕业生，外婆教唱歌，舅父拉小提琴，外公在乐团吹色士风。在家人的熏陶下，自小便热爱音乐，喜爱唱歌，与音乐结下不解之缘。G.E.M.在5岁的时候已经开始尝试作曲及填词，13岁完成了8级钢琴。G.E.M.在小学时期就读位于太子道西的中华基督教会协和小学上午校，为2003年的毕业生，同时亦为校内诗歌班成员。其英文名G.E.M.是Get Everybody Moving的缩写，象徵著她希望透过音乐让大家动起来的梦想。2008年出道，2009年在叱咤乐坛流行榜颁奖典礼夺得女新人奖金奖，亦是该奖项历年来最年轻，以及第一位未成年的得奖者。因其广阔的音域，得到不少前辈歌手点名公开赞扬。2014年她参加湖南卫视《我是歌手》第二季名声大震。" },
                new Artist() {Name="林宥嘉",Sex=true,Description="林宥嘉（英文名：Yoga Lin，1987年7月1日－）是台湾著名男歌手。出生于台湾屏东县，是家中长子，有一弟一妹，家里经营建材生意。林宥嘉考上凤山高中后搬到高雄居住，高中毕业后就读于国立东华大学运动与休闲学系。2007年7月6日以20岁大学生的身份，获得台湾中视主办的歌唱选秀节目第一届《超级星光大道》冠军，并与华研国际音乐签约成为歌手。演唱歌曲有《你把我灌醉》《悬崖》《我爱的人》《你是我的眼》等。曾获第十届CCTV-MTV音乐盛典港澳台地区年度最受欢迎潜力歌手奖。林宥嘉拥有独特的声线和极佳的唱功，人称“迷幻唱腔”，“迷幻王子”。代表作包括《说谎》、《伯乐》、《我总是一个人在练习一个人》、《诱》、《自然醒》、《想自由》、《心酸》、《残酷月光》等。2017年5月16日入围金曲奖最佳男歌手奖。" },
                new Artist() {Name="王贰浪",Sex=false,Description="一只市井小巷的炸鸡店咸鱼老板 热爱音乐热爱生活。 腰缠万贯，每日不过三餐；广厦千间，夜寝不过六尺。 但求不多，知足就好，有你们聆听就好。" },
                new Artist() {Name="陈粒",Sex=false,Description="陈粒，又名粒粒，1990年7月26日出生于贵州省贵阳市，中国内地民谣女歌手、独立音乐人、唱作人，前空想家乐队主唱，毕业于上海对外经贸大学。2012年，其所在乐队“空想家乐队”获得“Zippo炙热摇滚大赛”上海赛区冠军。2014年，随空想家乐队推出乐队首张EP专辑《万象》；同年，其演唱的歌曲《奇妙能力歌》入围“第四届阿比鹿音乐奖”年度民谣单曲。2015年，推出首张个人音乐专辑《如也》；同年，推出个人民谣单曲《远辰》。2016年1月，获得“第五届阿比鹿音乐奖”最受欢迎音乐人（民谣）；同年3月8日，化身“粒粒”并推出首支单曲《幻期颐》；同年7月26日，推出第二张个人音乐专辑《小梦大半》。" },
                new Artist() {Name="李荣浩",Sex=true,Description="李荣浩，1985年7月11日生于蚌埠，中国流行音乐制作人、歌手、吉他手。曾为众多艺人创作歌曲以及担任制作人，也曾为多部电影与多款电子游戏制作音乐。2013年9月17日发行个人首张原创专辑《模特》，凭借这张专辑入围第25届金曲奖最佳国语男歌手奖、最佳新人奖、最佳专辑制作人、最佳国语专辑、最佳作词奖等五项大奖提名，成为最大黑马，实现了从制作人到歌手的华丽转身。" },
                new Artist() {Name="张惠妹",Sex=false,Description="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                new Artist() {Name="赵雷",Sex=true,Description="民谣音乐人赵雷，中国内地新生代民谣歌手。1986年7月20日生于北京，高中时间接触音乐，开始学习吉他。年纪轻轻便踏遍祖国的大江南北，山河东西，足迹遍布陕甘、云藏，为自己的音乐之路，积累了大量时代底蕴与人文滋养。赵雷的音乐，虽然没有诗句般的柔情感动，但痞子气的调侃，单纯率直直达你的内心。词作、编曲朴实坦诚以描写生活中细微见长，每一首歌都像一部短剧，折射出他自己的生活、他眼中社会、甚至他心底的梦想，画面感极强。是最具传统北京胡同文化气质的新生代音乐人之一。" },
                new Artist() {Name="Fine乐团",Sex=true,Description="内地流行乐独立音乐人Fine乐团由一男一女组成。男生冠南创作词曲，女生乔西负责演唱" },
                new Artist() {Name="王三溥",Sex=true,Description="左手新古典，右手金属，踽踽行于音乐旅途。 微信公众号：王三溥 微博：王三溥" },
                new Artist() {Name="万晓利",Sex=true,Description="是一位富有浓郁人文色彩的民谣歌手，中国现代民谣的代表人物之一，浮华世界里一位坚定的歌唱者。万晓利给我留下的印象是一把木箱琴和千变万化的人声，后来他出动机的时候，居然拿出一支碗，用勺子在碗边划出丁冬之声，表情是无比虔诚的，效果是出人意料的。 万晓利因其独特的唱腔被观众评为颠覆民谣的歌手。" },
                new Artist() {Name="华晨宇",Sex=true,Description="华晨宇，1990年2月7日生于湖北十堰 ，中国男歌手，毕业于武汉音乐学院。 2013年，参加湖南卫视《快乐男声》获年度总冠军出道 。2014年1月，首登央视春晚舞台。9月6日-7日，在北京万事达中心连开两场“火星”演唱会 ，随后首张个人专辑《卡西莫多的礼物》发行 ，并凭此专辑获第十五届音乐风云榜年度最受欢迎男歌手等奖项。同年7月31日—8月2日，2015火星演唱会在上海大舞台连开三场。12月，发行第二张专辑《异类》。 2016年7-9月，2016火星演唱会相继在北上深三个城市举办。9月27日，出席亚洲新歌榜2016年度盛典，揽获最佳男歌手奖。10月，加盟东方卫视《天籁之战》。12月2日，获2016MAMA亚洲最佳艺人奖。2017年3月14日，专辑《H》发行。" },
                new Artist() {Name="王以太",Sex=true,Description="cdc说唱会馆 王以太 3ho" },
                new Artist() {Name="Chainsmokers",Sex=true,Description="The Chainsmokers，是来自美国纽约的DJ组合。由成员安德鲁·塔格特和亚历克斯·鲍尔组成，2014年因一曲《#Selfie》而出名。" },
                new Artist() {Name="Charlie Puth",Sex=true,Description="小查尔斯·奥托·普斯（英语：Charles Otto Puth Jr.）是一位美国流行歌手，出生于美国新泽西州。2009年创建YouTube频道，上传翻唱视频并拥有一定的知名度。2011年凭借与Emily Luther翻唱的《Someone Like You》获得艾伦赏识。 2015年，凭借与Meghan Trainor合作的《Marvin Gaye》被大家所知。 尚未正式出道即与饶舌天王Wiz khalifa联手合作《速度与激情7》电影片尾曲《See You Again》，官方MV累计超越全球24亿播放次数，空降美国公告牌冠军，并在澳大利亚、奥地利，英国、德国、加拿大、新西兰、爱尔兰、瑞士多个国家排名第一，总计非连续12周登顶美国公告牌单曲榜；缔造美国Spotify单日流媒体播放量最多单曲、Spotify全球26国单周最高收听次数记录；登顶英国单曲排行榜，成为2015年英国销量最快单曲；空降全球100多国iTunes排行榜第一名。此单曲迅速红遍全球，Charlie Puth正式走进人们的视野并获得大量关注。 2016年1月，与Selena Gomez 合作的《We Don't Talk Anymore》更突破它在YouTube上以往的六亿点击率，成为Charlie Puth第二支在Billboard百强单曲榜的前十单曲。" },
                new Artist() {Name="Justin Bieber",Sex=true,Description="加拿大少年歌手Justin Bieber，早期因为在YouTube翻唱其他艺人的歌曲而出名，随后被经纪人挖掘并被Usher培养进入美国音乐歌坛。他是YouTube观看量最多的艺人及首位19岁前拥有五张冠军专辑、在首张专辑发行前就有4首TOP40单曲的歌手。2011《人物》杂志公布的年度好莱坞最富有的年轻人。在“福布斯全球百位巨星排行榜”上贾斯汀连续2年名列第三，男歌手权利排行第一，推特粉丝全球第一。Billboard与VH1评选的当今最具影响童星。" },
                new Artist() {Name="Jony J",Sex=true,Description="独立音乐人，说唱歌手，来自SHOOC.Studio" },
                new Artist() {Name="周杰伦",Sex=true,Description="著名歌手，音乐人，词曲创作人，编曲及制作人，MV及电影导演。新世纪华语歌坛领军人物，中国风歌曲始祖，被时代周刊誉为“亚洲猫王”，是2000年后亚洲流行乐坛最具革命性与指标性的创作歌手，亚洲销量超过3100万张，有“亚洲流行天王”之称，开启华语乐坛“R&B时代”与“流行乐中国风”的先河，周杰伦的出现打破了亚洲流行乐坛长年停滞不前的局面，为亚洲流行乐坛翻开了新的一页，是华语乐坛真正把R&B提升到主流高度的人物，引领华语乐坛革命整十年，改写了华语乐坛的流行方向。" },
                new Artist() {Name="Vicetone",Sex=true,Description="来自荷兰格罗宁根的电音组合Vicetone由出生于同样出生于92的Ruben Den Boer和Victor Pool组成。深受受Eric Prydz及Swedish House Mafia的影响，Boer和Pool决心追随偶像的脚步创作自己的音乐。2012年正式出道，与Monstercat签约，得到与Collin McLoughlin合作机会推出单曲《Heartbeat》一炮而红。2014年在发行了单曲曲《Lowdown》及《Ensemble》后，Vicetone顺理成章的被保送Ultra音乐节。此后作为DJ Mag百大DJ常客，他们又陆续推出了如《What I’ve Waited For》，《No Way Out》和《Way Back》等多支热门单曲。" },
                new Artist() {Name="Beyond",Sex=true,Description="一支来自于中国香港的著名摇滚乐队，也是华人地区的殿堂级乐队之一，成立于1983年，其队名的中文意思为“超越”。乐队属于原创型，其作品以写实为主。乐队曾经有过多次的人事变动，其中以黄家驹、黄家强、黄贯中、叶世荣四人的阵容最广为人知。自从黄家驹于1993年在日本东京意外去世之后，乐队没有再寻找新成员填补。也因此，乐队失去了主要唱作人；但也驱使了后Beyond时期的音乐风格不仅变得具有更重的摇滚味，而且还朝向多元化发展，因此乐队无愧于“超越”二字。2005年Beyond举行了“Beyond The Story Live 2005”世界巡回告别演唱会并宣布解散，三人继续以个人的姿态发展自己的音乐事业。" },
                new Artist() {Name="Rihanna",Sex=true,Description="蕾哈娜（Rihanna），1988年2月20日出生于巴巴多斯圣迈克尔区，在美国发展的巴巴多斯女歌手、演员、模特。 2005年8月发行首张音乐专辑《Music of the Sun》开始歌唱事业生涯。2008年在第50届格莱美奖上入围“年度制作“和“年度歌曲”在内的六项提名，凭借歌曲《Umbrella》获得“最佳饶舌/演唱合作”奖。 2011年被巴巴多斯政府授予为旅游大使，巴巴多斯政府也将每年的2月20日定为“蕾哈娜日”。2012年首次以演员身份主演的好莱坞科幻战争电影《超级战舰》上映。 2015年4月公开歌曲《American Oxygen》音源与MV。 截至2015年，蕾哈娜在美国公告牌榜上拥有12首冠军单曲，被评选2010年最佳艺人奖，也是蝉联多座格莱美、全英音乐和MTV音乐大奖，并二次获得MTV年度录影带大奖的女歌手。" },
                new Artist() {Name="ICE",Sex=true,Description="隶属于SEVEN GURUS音乐厂牌 经纪人联系方式：18515440725 新浪微博：Ice_冰块" },
                new Artist() {Name="朴树",Sex=true,Description="中国大陆歌手，音乐人。1996年10月正式成为“麦田音乐”签约歌手，为简略笔划而定艺名朴树。首支单曲《火车开往冬天》，96年底推出后成绩斐然。99年1月，推出首张个人专辑《我去两千年》。99年12月与华纳唱片正式签订唱片合约，成为其亚太区旗下的第一位内地歌手，其首张专辑《我去两千年》将由华纳重新混录和拍摄最新单曲录影带后，于2000年上半年在海外隆重上市。代表作品：《那些花儿》，《白桦林》，《生如夏花》。主要成就：中歌榜最佳新人奖，最受欢迎男歌手，年度最佳制作人奖。" },
                new Artist() {Name="胡彦斌",Sex=true,Description="胡彦斌 （Tiger Hu） ，男，1983年7月生于上海，著名歌手、创作人、制作人。 2000年，推出个人首支单曲《玛丽莲梦露》，主唱动画片《我为歌狂》相关歌曲。2002年，18岁全亚洲同步发行个人首张专辑《文武双全》；2004年发行专辑《MUSIC 混合体》，一人包办专辑中所有作曲、编曲及制作工作，凭此专辑成为史上“最佳男歌手”最年轻获得者；2007年在EMI旗下创建个人厂牌“风风火火”； 2013年，江苏卫视“全能星战”获得总冠军，荣膺“全能歌王”称号；2014年创立音乐厂牌－太歌、音乐教育品牌－牛班，成为红牛史上唯一艺人代言人。2015年，参加《我是歌手第三季》获得“音乐魔法师”称号。2017年4月，发行个人全新EP专辑《X》。" },
                new Artist() {Name="S.H.E",Sex=true,Description="S.H.E由任家萱（Selina）、田馥甄（Hebe）、陈嘉桦（Ella）组成，2000年共同参加宇宙美少女实力争霸战后受宇宙音乐（现名华研国际音乐）相中并签约，2001年9月11日正式出道。分别代表着温柔、勇气、自信的SELINA、HEBE和ELLA，依照她们e世代的跳跃式思考模式和无厘头的爆笑逻辑，不论在声音或在个性的表现上都能以最自然的、最纯粹的个人特质来发挥她们的个人魅力，呈现出最S.H.E的一面。当年以一首《恋人未满》走红，令首张专辑大卖75万张。其后更凭借《美丽新世界》《Super Star》《波斯猫》《不想长大》《中国话》等多首热门歌曲风靡大街小巷。如今S.H.E已跨足音乐、戏剧、主持、广告、书籍、配音等方面。" },
                new Artist() {Name="徐佳莹",Sex=true,Description="华语流行音乐创作女歌手、金曲奖得主。1984年12月20日生于台湾台中市，籍贯四川省简阳县。" },
                new Artist() {Name="孙燕姿",Sex=true,Description="孙燕姿（Stefanie Sun），新加坡人，华语流行女歌手，以独特的嗓音和唱腔、扎实的音乐功底著称。2000年签约华纳音乐，发行首张专辑《孙燕姿同名专辑》，以《天黑黑》一曲成名，并获得包括台湾金曲奖在内的亚洲各地15个最佳新人奖，至今仍为华语歌坛之纪录。2003年，发表新专辑《The Moment》，其中《遇见》一曲迅速为听众所熟悉，连年囊括各地颁奖礼最佳女歌手、身处事业巅峰期的她暂别歌坛一年。2004年携《Stefanie》专辑完美复出，并凭此专辑获得2005年第16届金曲奖最佳女歌手，之后又发表《逆光》(2007)、《是时候》(2011)等经典专辑。她的歌积极向上、给人力量，个人风格明显，深受听众喜爱。多次获得各地音乐奖项，六次入围台湾金曲奖最佳女歌手、四次入围最佳专辑、七次获得香港IFPI十大销量国语唱片奖。2014年发行新专辑《克卜勒》，并展开新一轮的克卜勒巡回演唱会。" },
                new Artist() {Name="张国荣",Sex=true,Description="张国荣是一位在全球华人社会和亚洲地区具有影响力的著名歌手、演员和音乐人；大中华区乐坛和影坛巨星；演艺圈多栖发展最成功的代表之一。张国荣是香港乐坛的殿堂级歌手之一，曾获得香港乐坛最高荣誉金针奖；他是第一位享誉韩国乐坛的华人歌手，亦是华语唱片在韩国销量纪录保持者。他通晓词曲创作，曾担任过MTV导演、唱片监制、电影编剧、电影监制。他于1991年当选香港电影金像奖影帝；1993年主演的影片《霸王别姬》打破中国内地文艺片在美国的票房纪录，他亦凭此片蜚声国际影坛，获得日本影评人大奖最佳男主角奖以及中国电影表演艺术学会奖特别贡献奖。他曾受邀担任东京国际电影节和柏林国际电影节评委，2005年入选“中国电影百年百位优秀演员”，2010年当选美国CNN评出的“史上最伟大的二十五位亚洲演员”。 香港演艺圈的艺人都喊他为哥哥。2003年4月1日，张国荣因抑郁症病情失控跳楼自杀身亡。" },
                new Artist() {Name="王力宏",Sex=true,Description="中国著名流行歌手、词曲创作音乐人；亚洲华语流行乐坛最具代表性的创作、偶像、实力派音乐偶像巨星。1995年发行首张专辑《情敌贝多芬》在台湾出道，亦是金曲奖中最年轻的封王者，其唱片总销量在全亚洲已超过2500万张。从改编歌曲《龙的传人》融合西方电子节奏和东方旋律的华人中式嘻哈风，再到为华语流行乐注入新元素，进一步将其推向全世界。超高唱片销量便可以证明力宏的影响力毋庸置疑的强。况且身为金曲奖常客，3次接受CNN电视台访问。首创Chinked-out曲风，将中国风推向世界，又用自己写的歌揭露了娱乐圈的众多丑闻，都可以表现他对华语乐坛的巨大贡献。亦参与多部电影工作，2010年进军影坛，首部自导自演的电影《恋爱通告》票房纪录突破5000万，成为票房冠军，其导演才华受到了广大好评。" }

            };
            foreach (var a in artists)
                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();

            var albums = new List<Album>
                {
                new Album
                { Title = "正常人", Genre = genres.Single(g => g.Name =="爵士"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="李霄云"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "粥请客（厘小白）", Genre = genres.Single(g => g.Name =="爵士"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="花粥"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "Different World", Genre = genres.Single(g => g.Name =="流行"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="Alan Walker"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "L.O.V.E.", Genre = genres.Single(g => g.Name =="古典"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="陈奕迅"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "Until The Day", Genre = genres.Single(g => g.Name =="嘻哈"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "Victoria", Genre = genres.Single(g => g.Name =="嘻哈"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "The GREAT YOGA", Genre = genres.Single(g => g.Name =="蓝调"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="林宥嘉"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "你是年少的欢喜", Genre = genres.Single(g => g.Name =="流行"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="王贰浪"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "Best Better Ever", Genre = genres.Single(g => g.Name =="重金属"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "耳朵", Genre = genres.Single(g => g.Name =="摇滚"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="李荣浩"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "Are You Ready", Genre = genres.Single(g => g.Name =="古典"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="张惠妹"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "At The Age of Nineteen", Genre = genres.Single(g => g.Name =="摇滚"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="赵雷"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "写了好多事都是关于你", Genre = genres.Single(g => g.Name =="摇滚"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="Fine乐团"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "十一月", Genre = genres.Single(g => g.Name =="重金属"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="王三溥"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "太阳看起来圆圆的", Genre = genres.Single(g => g.Name =="古典"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="万晓利"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                new Album
                { Title = "寒鸦少年", Genre = genres.Single(g => g.Name =="摇滚"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif", },


                 new Album
                { Title = "Feel & Sight", Genre = genres.Single(g => g.Name =="嘻哈"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="王以太"),AlbumArtUrl="/Content/Images/placeholder.gif", },


                 new Album
                { Title = "Beach House", Genre = genres.Single(g => g.Name =="流行"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="Chainsmokers"),AlbumArtUrl="/Content/Images/placeholder.gif", },


                  new Album
                { Title = "The Way I Am (Slushii Remix)", Genre = genres.Single(g => g.Name =="蓝调"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="Charlie Puth"),AlbumArtUrl="/Content/Images/placeholder.gif", },


                  new Album
                { Title = "Love Yourself (Afrobeat Refix)", Genre = genres.Single(g => g.Name =="爵士"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="Justin Bieber"),AlbumArtUrl="/Content/Images/placeholder.gif", },


                   new Album
                { Title = "Big Things Start Small", Genre = genres.Single(g => g.Name =="嘻哈"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="Jony J"),AlbumArtUrl="/Content/Images/placeholder.gif", },


                   new Album
                { Title = "不爱我就拉倒", Genre = genres.Single(g => g.Name =="流行"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif", },


                   new Album
                { Title = "Something Strange", Genre = genres.Single(g => g.Name =="蓝调"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="Vicetone"),AlbumArtUrl="/Content/Images/placeholder.gif", },


                   new Album
                { Title = "More", Genre = genres.Single(g => g.Name =="摇滚"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="Beyond"),AlbumArtUrl="/Content/Images/placeholder.gif", },


                   new Album
                { Title = "Consideration (Dance Remixes)", Genre = genres.Single(g => g.Name =="摇滚"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="Rihanna"),AlbumArtUrl="/Content/Images/placeholder.gif", },


                   new Album
                { Title = "FEELING DOPE", Genre = genres.Single(g => g.Name =="嘻哈"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="ICE"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                   new Album
                { Title = "No Fear In My Heart", Genre = genres.Single(g => g.Name =="古典"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="朴树"),AlbumArtUrl="/Content/Images/placeholder.gif", },


                   new Album
                { Title = "疤", Genre = genres.Single(g => g.Name =="流行"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="胡彦斌"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                   new Album
                { Title = "SHERO", Genre = genres.Single(g => g.Name =="流行"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="S.H.E"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                   new Album
                { Title = "一江水", Genre = genres.Single(g => g.Name =="蓝调"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                    new Album
                { Title = "极美", Genre = genres.Single(g => g.Name =="爵士"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="孙燕姿"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                    new Album
                { Title = "Miss You Much, Leslie", Genre = genres.Single(g => g.Name =="古典"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="张国荣"),AlbumArtUrl="/Content/Images/placeholder.gif", },

                     new Album
                { Title = "CrossFire", Genre = genres.Single(g => g.Name =="重金属"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="王力宏"),AlbumArtUrl="/Content/Images/placeholder.gif", }

            };
            albums.ForEach(n => _dbContext.Albums.Add(n));
            _dbContext.SaveChanges();
        }

        //给GenreId和ArtistId赋值
        public static void Extend()
        {
            var albums = _dbContext.Albums.ToList();
            foreach(var album in albums)
            {
                var item = _dbContext.Albums.Find(album.ID);
                item.GenreId = item.Genre.ID.ToString();
                item.ArtistId = item.Artist.ID.ToString();
                _dbContext.SaveChanges();
                Thread.Sleep(3);
            }
        }
    }
}