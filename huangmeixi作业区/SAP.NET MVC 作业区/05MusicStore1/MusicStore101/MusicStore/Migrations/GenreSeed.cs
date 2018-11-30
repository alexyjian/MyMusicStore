using MusicStoreEntity;
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
                new Genre() {Name = "摇滚",Description = "Yaogun"},
                new Genre() {Name =  "爵士",Description = "Jazz"},
                new Genre() {Name =  "重金属",Description = "Metal"},
                new Genre() {Name =  "慢摇",Description = "DownTempo"},
                new Genre() {Name =  "蓝调",Description = "Blue"},
                new Genre() {Name =  "拉丁",Description = "Latin"},
                new Genre() {Name =  "流行",Description = "Pop"},
                new Genre() {Name =  "古典",Description = "Classical"},
                new Genre() {Name =  "DJ",Description = "DJ"},
                new Genre() {Name =  "嘻哈",Description = "HiHop"},
            };

            foreach (var g in genres)
                _dbContext.Genres.Add(g);
            _dbContext.SaveChanges();

            //歌手
            var artists = new List<Artist>()
            {
            new Artist() { Name="薛之谦",Sex=false,Description="薛之谦（Joker Xue），1983年7月17日出生于上海，华语流行乐男歌手、影视演员、音乐制作人，毕业于格里昂酒店管理学院。 2005年，参加选秀节目《我型我秀》正式出道 。2006年，发行首张同名专辑《薛之谦》，随后凭借歌曲《认真的雪》获得广泛关注。2008年，发行专辑《深深爱过你》并在上海举行个人首场演唱会“谦年传说” 。2013年，专辑《几个薛之谦》获得MusicRadio中国TOP排行榜内地推荐唱片。2014年，专辑《意外》获得第21届东方风云榜颁奖最佳唱作人 ；2015年6月，薛之谦首度担当制作人并发行原创EP《绅士》，2016年，凭借EP《绅士》、《一半》获得第16届全球华语歌曲排行榜多项奖项，而歌曲《初学者》则获得年度二十大金曲奖。2017年4月，开启“我好像在哪见过你”全国巡回演唱会。"},
            new Artist() { Name="华晨宇",Sex=false,Description="华晨宇（华晨宇，1990年2月7日生于湖北十堰 ，中国男歌手，毕业于武汉音乐学院。 2013年，参加湖南卫视《快乐男声》获年度总冠军出道 。2014年1月，首登央视春晚舞台。9月6日-7日，在北京万事达中心连开两场“火星”演唱会 ，随后首张个人专辑《卡西莫多的礼物》发行 ，并凭此专辑获第十五届音乐风云榜年度最受欢迎男歌手等奖项。同年7月31日—8月2日，2015火星演唱会在上海大舞台连开三场。12月，发行第二张专辑《异类》。 2016年7-9月，2016火星演唱会相继在北上深三个城市举办。9月27日，出席亚洲新歌榜2016年度盛典，揽获最佳男歌手奖。10月，加盟东方卫视《天籁之战》。12月2日，获2016MAMA亚洲最佳艺人奖。2017年3月14日，专辑《H》发行。"},
            new Artist() { Name="邓紫棋",Sex=true,Description="邓紫棋成长于一个音乐世家，其母亲为上海音乐学院声乐系毕业生，外婆教唱歌，舅父拉小提琴，外公在乐团吹色士风。在家人的熏陶下，自小便热爱音乐，喜爱唱歌，与音乐结下不解之缘。G.E.M.在5岁的时候已经开始尝试作曲及填词，13岁完成了8级钢琴。G.E.M.在小学时期就读位于太之道西的中华基督教会协和小学上午校，为2003年的毕业生，同时亦为校内诗歌班成员。其英文名G.E.M.是Get Everybody Moving的缩写，象徵著她希望透过音乐让大家动起来的梦想。2008年出道，2009年在叱咤乐坛流行榜颁奖典礼夺得女新人奖金奖，亦是该奖项历年来最年轻，以及第一位未成年的得奖者。因其广阔的音域，得到不少前辈歌手点名公开赞扬。2014年她参加湖南卫视《我是歌手》第二季名声大震。"},
            new Artist() { Name="汪苏泷",Sex=false,Description="汪苏泷，内地创作新人，就读于沈阳音乐学院歌曲创作与MIDI制作系，音乐风格上偏多元化，有R&B、中国风、RAP、金属摇滚，等等，将种种时下最流行的音乐元素都融入其创作中。2013年1月25日获得音乐先锋榜“最佳创作新人”大奖。代表作：《桃花扇》、《万有引力》等。"},
            new Artist() { Name="蔡健雅",Sex=true,Description="新加坡人，华语著名歌手、词曲作者，音乐制作人。1997年在新加坡由其经纪公司 Music & Movement 旗下的Yellow Music发行英语专辑《Bored》而正式出道，1999年将国语唱片签约于宝丽金唱片旗下，并推出首张国语同名专辑《蔡健雅》。2000年因宝丽金唱片并入环球唱片旗下，因此《记念》及之后的唱片皆由台湾环球唱片发行。在此一专辑中，蔡健雅以〈记念〉一曲成功打响在台湾市场的知名度。同年入围台湾第11届金曲奖最佳新人奖。2002年发行《Secret Lavender》专辑。同年以〈打错了〉作曲者身份入围台湾第13届金曲奖最佳作曲人奖，并同时入围最佳国语演唱人奖。2004年首度担任制作人，替梁咏琪制作《归属感》专辑。同年以《陌生人》获得台湾第15届金曲奖最佳国语女演唱人提名。2008年推出专辑《My Space》，同年获台湾第19届金曲奖7项提名，并获得了最佳专辑制作人和最佳国语女歌手两座大奖。近年移居台湾。2012年获最佳国语女歌手奖。代表作品：《呼吸》《陌生人》《空白格》《若你碰到他》《红色高跟鞋》。"},
            new Artist() { Name="林俊杰",Sex=false,Description="著名男歌手，作曲人、作词人、音乐制作人，偶像与实力兼具。林俊杰出生于新加坡的一个音乐世家。在父母的引导下，4岁就开始学习古典钢琴，不善言辞的他由此发现了另一种与人沟通的语言。小时候的林俊杰把哥哥林俊峰当作偶像，跟随哥哥的步伐做任何事，直到接触流行音乐后，便爱上创作这一条路。2003年以专辑《乐行者》出道，2004年一曲《江南》红遍两岸三地，凭借其健康的形象，迷人的声线，出众的唱功，卓越的才华，迅速成为华语流行乐坛的领军人物之一，迄今为止共创作数百首音乐作品，唱片销量在全亚洲逾1000万张。2007年成立个人音乐制作公司JFJ，2008创立潮流品牌SMG。2011年被媒体封为“新四大天王”之一，同年8月8日正式加盟华纳音乐，开启事业新乐章。2012年发行故事影像书《记得》，成功跻身畅销书作家行列。获得多项奖项：第15届台湾金曲奖最佳新人奖，6届新加坡金曲奖大奖，6届新加坡词曲版权协会大奖，8届全球华语歌曲排行榜大奖，5届MusicRadio中国TOP排行榜大奖。"},
            new Artist() { Name="五月天",Sex=false,Description="台湾乐团，由乐队团长兼吉他手怪兽、主唱阿信、吉他手石头、贝斯玛莎和鼓手冠佑组成。五月天的前身是SoBand，是由四个师大附中学生组成，329野台开唱的表演所以就改叫五月天，同时也把329当成五月天的成军日。在1997年3月29日改名为“五月天”。乐团的名称是来自贝斯手玛莎在网络论坛上的代号。1999年，台北市立体育场五月天第168场万人演唱会。台湾第一个站上体育场开演唱会的乐团，被视为华语乐团的奇迹，奠定了五月天的live魅力。截至2012年6月，四次夺下金曲奖“最佳乐团奖”，代表作《志明与春娇》、《疯狂世界》、《终结孤单》、《诺亚方舟》等。2017年5月16日入围金曲奖最佳乐团。"},
            new Artist() { Name="魏晨",Sex=false,Description="中国内地男歌手、演员，2007年参加湖南卫视快乐男声荣获年度总季军，2009年、2010年在国内首部青春励志偶像剧《一起来看流星雨》及《一起又看流星雨》中饰演叶烁，有“少女杀手”之称，誉为：“亚洲人气小天王”“内地全能偶像”，2010年发行首张专辑《千方百计》、2011年发行第二张专辑《破晓》，2012年10月15日发行第三张个人专辑《V SPACE》均销量火爆并获得多项大奖，深受乐坛及歌迷肯定。"},
            new Artist() { Name="李荣浩",Sex=false,Description="李荣浩，1985年7月11日生于蚌埠，中国流行音乐制作人、歌手、吉他手。曾为众多艺人创作歌曲以及担任制作人，也曾为多部电影与多款电子游戏制作音乐。2013年9月17日发行个人首张原创专辑《模特》，凭借这张专辑入围第25届金曲奖最佳国语男歌手奖、最佳新人奖、最佳专辑制作人、最佳国语专辑、最佳作词奖等五项大奖提名，成为最大黑马，实现了从制作人到歌手的华丽转身。"},
            new Artist() { Name="周杰论",Sex=false,Description="著名歌手，音乐人，词曲创作人，编曲及制作人，MV及电影导演。新世纪华语歌坛领军人物，中国风歌曲始祖，被时代周刊誉为“亚洲猫王”，是2000年后亚洲流行乐坛最具革命性与指标性的创作歌手，亚洲销量超过3100万张，有“亚洲流行天王”之称，开启华语乐坛“R&B时代”与“流行乐中国风”的先河，周杰伦的出现打破了亚洲流行乐坛长年停滞不前的局面，为亚洲流行乐坛翻开了新的一页，是华语乐坛真正把R&B提升到主流高度的人物，引领华语乐坛革命整十年，改写了华语乐坛的流行方向。"},
            new Artist() { Name="王力宏",Sex=false,Description="中国著名流行歌手、词曲创作音乐人；亚洲华语流行乐坛最具代表性的创作、偶像、实力派音乐偶像巨星。1995年发行首张专辑《情敌贝多芬》在台湾出道，亦是金曲奖中最年轻的封王者，其唱片总销量在全亚洲已超过2500万张。从改编歌曲《龙的传人》融合西方电子节奏和东方旋律的华人中式嘻哈风，再到为华语流行乐注入新元素，进一步将其推向全世界。超高唱片销量便可以证明力宏的影响力毋庸置疑的强。况且身为金曲奖常客，3次接受CNN电视台访问。首创Chinked-out曲风，将中国风推向世界，又用自己写的歌揭露了娱乐圈的众多丑闻，都可以表现他对华语乐坛的巨大贡献。亦参与多部电影工作，2010年进军影坛，首部自导自演的电影《恋爱通告》票房纪录突破5000万，成为票房冠军，其导演才华受到了广大好评。"},
            new Artist() { Name="孙燕姿",Sex=true,Description="孙燕姿（Stefanie Sun），新加坡人，华语流行女歌手，以独特的嗓音和唱腔、扎实的音乐功底著称。2000年签约华纳音乐，发行首张专辑《孙燕姿同名专辑》，以《天黑黑》一曲成名，并获得包括台湾金曲奖在内的亚洲各地15个最佳新人奖，至今仍为华语歌坛之纪录。2003年，发表新专辑《The Moment》，其中《遇见》一曲迅速为听众所熟悉，连年囊括各地颁奖礼最佳女歌手、身处事业巅峰期的她暂别歌坛一年。2004年携《Stefanie》专辑完美复出，并凭此专辑获得2005年第16届金曲奖最佳女歌手，之后又发表《逆光》(2007)、《是时候》(2011)等经典专辑。她的歌积极向上、给人力量，个人风格明显，深受听众喜爱。多次获得各地音乐奖项，六次入围台湾金曲奖最佳女歌手、四次入围最佳专辑、七次获得香港IFPI十大销量国语唱片奖。2014年发行新专辑《克卜勒》，并展开新一轮的克卜勒巡回演唱会。"},
            new Artist() { Name="田馥甄",Sex=true,Description="田馥甄，艺名Hebe，台湾知名女艺人，女子演唱团体S.H.E组合成员，出生于台湾新竹县新丰乡，于2000年参加“宇宙2000实力美少女争霸战”选秀活动，并于同年与宇宙唱片（华研唱片前身）签约培训，接着在隔年与Selina、Ella组成S.H.E，并于2001年9月11日发行S.H.E首张专辑《女生宿舍》正式出道。2010年下半年，S.H.E正式迈向“单飞不解散”阶段，接着同年9月3日，使用本名“田馥甄”推出首张个人专辑《To Hebe》。"},
            new Artist() { Name="曲婉婷",Sex=true,Description="中国女歌手，原创音乐人。首位签约加拿大顶级唱片公司Nettwerk的中国国籍女歌手。紧接着，由她创作的《我的歌声里》等3首歌曲被奔驰公司选中。作为公司签约的第一个华人女歌手，公司给曲婉婷的定位是亚洲市场、北美市场一起闯。凭借《我的歌声里》而在网络迅速走红。2010年回到中国发展。2012年加盟环球音乐，作为首位在国内未发片便先在国外发片的华语原创流行女歌手，并在同年4月24日在北美首发个人第一张专辑《Everything In The World》。2013年受央视春晚邀请担任表演嘉宾。代表作品：《Drenched》《我的歌声里》《承认》《Jar Of Love》。"},
            new Artist() { Name="梁静茹",Sex=true,Description="华语著名女歌手，马来西亚人。被称为“情歌天后”。梁静茹出生在马来西亚，来台湾前得过许多歌唱比赛奖项。在一次歌唱比赛中有幸得到李宗盛肯定，并带其进入滚石唱片。于1999年9月发行自己的第一张个人专辑《一夜长大》。2000年发行的《勇气》则几乎令她一夜成名。2004年《燕尾蝶》发行，这是梁静茹的转型大碟，专辑中尝试是摇滚曲风，把梁静茹的独特嗓音发挥到极致，也获得了众多好评。2005年的《可惜不是你》在其演绎下生动感人、催人泪下，有着很高的知名度和传唱度。代表作品：《勇气》、《分手快乐》、《宁夏》、《丝路》、《暖暖》、《崇拜》、《情歌》、《爱久见人心》。"},
            new Artist() { Name="杨丞琳",Sex=true,Description="中国台湾流行歌手，集歌手、演员、主持人等多方位发展的的全能艺人。2000年加入4 in love组合出道，曾参演过《流星花园》“小优”一角，戏份虽不多仍成为观众焦点。2002年末主持综艺节目《我猜我猜我猜猜猜》长达4年。2005年凭借专辑《暧昧》和偶像剧《恶魔在身边》而走红，有着“亚洲全能天后”、“勇敢天后”与“可爱教主”之称。2010年凭借主演的偶像剧《海派甜心》夺得第45届电视金钟奖最佳女演员，封获“金钟影后”称号。个人在香港红馆连开3场创下5年来台湾第1位女歌手纪录。2013年发布新歌《为爱启程》。"},
            new Artist() { Name="张碧晨",Sex=true,Description="张碧晨，1989年9月10日出生于中国天津，中国女歌手。 2013年，张碧晨以韩国女子组合“Sunny days ”出道，并获得“K-POP ”世界庆典“最优秀奖”。2014年7月，张碧晨参加第三季《中国好声音》，以一首《她说》进入那英组，并于10月7日以一首《时间去哪儿了》荣获第三季《中国好声音》全国总冠军，成为《中国好声音》首位女冠军。"},
            new Artist() { Name="戴佩妮",Sex=true,Description="马来西亚人，著名全创作型华语女歌手。文学与舞蹈养成她强烈的创作欲，从未学过音乐的她在17岁时决定提笔开始词曲创作，从小即受西方摇滚乐的洗礼，作品偏好各式摇滚曲风，但Folk、R&B等曲式亦有尝试。2000出道至今已发行10张个人全创作专辑和1张乐团专辑1张乐团EP，为他人发表作嫁歌曲十余首。曾获17届台湾“金曲奖”最佳作曲人的殊荣，并多次入围“金曲奖”。2009年作为导演的戴佩妮凭借导方大同《黑白》MV、方炯镔《风》MV入围第20届金曲奖“最佳音乐录影带”奖。代表作品：《怎样》《街角的祝福》《你要的爱》《爱疯了》。"},
            new Artist() { Name="Sweety",Sex=true,Description="Sweety，英文原意为糖果、蜜饯，也指台湾的女子歌唱组合，由刘品言（言言）和曾之乔（乔乔）所组成。于2003年出道，在戏剧唱片上都有亮眼的表现。言言在2007年生日后单飞，到巴黎熟悉当地语言后，现已主修设计课程。言言于2009年暑假过后，把学校由巴黎转至上海分校以方便工作，并重返演艺界，但Sweety同台的踪影仍寥寥可数，不过两人私下仍是好朋友。目前两人属不同经纪公司，但据两人透露，将来仍有合作的机会。"},
            new Artist() { Name="周笔畅",Sex=true,Description="华语流行女歌手，首位获美国格莱美大师为其写歌的华语歌手；首位英文歌被国际歌后翻唱的华语歌手。周笔畅出生于湖南长沙的一个“音乐世家”，2005年参加选秀《超级女声》夺得亚军，，从而红遍大江南北。2006年3月18日签约乐林文化，发行首张EP《周笔畅 1st EP》和首张个人音乐专辑《谁动了我的琴弦》。2008年年底发行“双子专辑”《NOW》&《WOW》并取得优异成绩：在当地零宣传的情况下双双入围台湾最具公信力的唱片销量排行榜G-music前10名，《NOW》更是取得空降亚军的佳绩，开创了内地歌手登陆台湾唱片市场的另一个奇迹。2010年周笔畅首次个人全国巡回演唱会—“唱歌去旅行”2010年5月29日，旅行第一站--广州，创下了40分钟万张门票全部售罄的惊人记录。后周笔畅还自创潮牌Begins，成立个人工作室Begins Studio。代表作品：《笔记》《谁动了我的琴弦》《鱼罐头》。"},
            new Artist() { Name="张信哲",Sex=false,Description="中国台湾著名男歌手，其嗓音清澈而明亮，尤其擅长抒情慢歌，是华语乐坛公认的“情歌王子”，在20世纪90年代与叱咤华语乐坛的“四大天王”齐名。从小在教会长大的张信哲是牧师之子。他在学校歌唱比赛被发掘，签给滚石唱片的子公司巨石音乐，成功凭第一张专辑《说谎》一炮而红，一年内连续推出三张唱片。1995年，在与巨石音乐约满后，张信哲成立了自己的音乐工作室潮水音乐，并加盟科艺百代旗下附属厂牌种子音乐，凭着《宽容》专辑隔年就赢得了金曲奖最佳国语男歌手奖。服役退伍后重返歌坛，演唱《难以抗拒你容颜》依旧畅销。后来沉寂一年，后期加入经纪公司百娱时代，推出《心事》专辑，主打歌为李宗盛写的《爱如潮水》，成功将张信哲推上巅峰。代表作品：《爱就一个字》、《过火》、《爱如潮水》。"},
            new Artist() { Name="李玉刚",Sex=false,Description="中国歌剧舞剧院国家一级演员、著名表演艺术家、全国青联委员，一位来自吉林省四平市公主岭农村的小伙子。李玉刚的表演将中国民族艺术、传统戏曲、歌剧辅以时尚包装，被海外媒体称为“中国国宝级艺术家”。2006年获央视《星光大道》年度季军，以超高人气成 “无冕之王”。"},
            new Artist() { Name="胡歌",Sex=false,Description="中国著名男演员、歌手，有“古装王子”的美称。2005年毕业于上海戏剧学院01级表演系本科，在电视连续剧《仙剑奇侠传》中成功塑造了豪爽深情的“李逍遥”而成名，他还为此剧唱插曲《六月的雨》《逍遥叹》等。胡歌主演过多部广为人知的影视剧，多部电视剧打破电视台收视记录。其人擅长摄影，文采飞扬，志做导演，频唱影视剧歌曲。2013年，主演的话剧《如梦之梦》和《永远的尹雪艳》登上舞台。"},





            };
            foreach(var b in artists)
                _dbContext.Artists.Add(b);
            _dbContext.SaveChanges();
            //遍历歌手

            var albums = new List<Album>
            {
           
             new Album { Title="演员",Genre=genres.Single(g=>g.Name=="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="薛之谦"),AlbumArtUrl="/Content/Images/"},
             new Album { Title="意外",Genre=genres.Single(g=>g.Name=="流行"),Price=7.99M,Artist=artists.Single(a=>a.Name=="薛之谦"),AlbumArtUrl="/Content/Images/XZQ.PNG"},
             new Album { Title="哑巴",Genre=genres.Single(g=>g.Name=="流行"),Price=6.99M,Artist=artists.Single(a=>a.Name=="薛之谦"),AlbumArtUrl="/Content/Images/XZQ.PNG"},
             new Album { Title="像风一样的男子",Genre=genres.Single(g=>g.Name=="摇滚"),Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="烟火里的尘埃",Genre=genres.Single(g=>g.Name=="摇滚"),Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="我管你",Genre=genres.Single(g=>g.Name=="摇滚"),Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="异类",Genre=genres.Single(g=>g.Name=="摇滚"),Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="无聊人",Genre=genres.Single(g=>g.Name=="摇滚"),Price=9.99M,Artist=artists.Single(a=>a.Name=="邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="我的滑板鞋",Genre=genres.Single(g=>g.Name=="拉丁"),Price=9.99M,Artist=artists.Single(a=>a.Name=="邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="回忆的沙漏",Genre=genres.Single(g=>g.Name=="拉丁"),Price=9.99M,Artist=artists.Single(a=>a.Name=="邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="毒苹果",Genre=genres.Single(g=>g.Name=="拉丁"),Price=9.99M,Artist=artists.Single(a=>a.Name=="邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="穿越火线",Genre=genres.Single(g=>g.Name=="拉丁"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="光年之外",Genre=genres.Single(g=>g.Name=="重金属"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="另一个通话",Genre=genres.Single(g=>g.Name=="重金属"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="小星星",Genre=genres.Single(g=>g.Name=="重金属"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="有点甜",Genre=genres.Single(g=>g.Name=="重金属"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="为你写诗",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="不分手的恋爱",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="三国杀",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="追光者",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="万有引力",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="红色高跟鞋",Genre=genres.Single(g=>g.Name=="慢摇"),Price=9.99M,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="陌生人",Genre=genres.Single(g=>g.Name=="慢摇"),Price=9.99M,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="思念是一种病",Genre=genres.Single(g=>g.Name=="慢摇"),Price=9.99M,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="小酒窝",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="美人鱼",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="背对背拥抱",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="一千年以后",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="飞云之下",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="温柔",Genre=genres.Single(g=>g.Name=="DJ"),Price=9.99M,Artist=artists.Single(a=>a.Name=="五月天"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="听不到",Genre=genres.Single(g=>g.Name=="DJ"),Price=9.99M,Artist=artists.Single(a=>a.Name=="五月天"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="超人",Genre=genres.Single(g=>g.Name=="DJ"),Price=9.99M,Artist=artists.Single(a=>a.Name=="五月天"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="星空物语",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="魏晨"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="花开那年",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="魏晨"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="年少有为",Genre=genres.Single(g=>g.Name=="慢摇"),Price=9.99M,Artist=artists.Single(a=>a.Name=="李荣浩"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="老街",Genre=genres.Single(g=>g.Name=="慢摇"),Price=9.99M,Artist=artists.Single(a=>a.Name=="李荣浩"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="手牵手",Genre=genres.Single(g=>g.Name=="慢摇"),Price=9.99M,Artist=artists.Single(a=>a.Name=="周杰论"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="青花瓷",Genre=genres.Single(g=>g.Name=="蓝调"),Price=9.99M,Artist=artists.Single(a=>a.Name=="周杰论"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="爱一点",Genre=genres.Single(g=>g.Name=="蓝调"),Price=9.99M,Artist=artists.Single(a=>a.Name=="王力宏"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="依然爱你",Genre=genres.Single(g=>g.Name=="蓝调"),Price=9.99M,Artist=artists.Single(a=>a.Name=="王力宏"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="遇见",Genre=genres.Single(g=>g.Name=="蓝调"),Price=9.99M,Artist=artists.Single(a=>a.Name=="孙燕姿"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="逆光",Genre=genres.Single(g=>g.Name=="蓝调"),Price=9.99M,Artist=artists.Single(a=>a.Name=="孙燕姿"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="雨天",Genre=genres.Single(g=>g.Name=="慢摇"),Price=9.99M,Artist=artists.Single(a=>a.Name=="孙燕姿"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="小幸运",Genre=genres.Single(g=>g.Name=="慢摇"),Price=9.99M,Artist=artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="只对你有感觉",Genre=genres.Single(g=>g.Name=="爵士"),Price=9.99M,Artist=artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="魔鬼中的天使",Genre=genres.Single(g=>g.Name=="慢摇"),Price=9.99M,Artist=artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="没有什么不同",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="曲婉婷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="爱的勇气",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="曲婉婷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="勇气",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="梁静茹"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="带我走",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="杨丞琳"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="左边",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="杨丞琳"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="我可以忘记你",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="戴佩妮"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="小小",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="戴佩妮"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="樱花草",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="Sweety"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="还是喜欢你",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="Sweety"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="原来你还在这里",Genre=genres.Single(g=>g.Name=="爵士"),Price=9.99M,Artist=artists.Single(a=>a.Name=="周笔畅"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="过火",Genre=genres.Single(g=>g.Name=="爵士"),Price=9.99M,Artist=artists.Single(a=>a.Name=="张信哲"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="刚好遇见你",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="李玉刚"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="雨花石",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="李玉刚"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="新贵妃醉酒",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="李玉刚"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="月光",Genre=genres.Single(g=>g.Name=="慢摇"),Price=9.99M,Artist=artists.Single(a=>a.Name=="胡歌"),AlbumArtUrl="/Content/Images/placeholder.gif"},







            }; foreach (var a in albums)
                _dbContext.Albums.Add(a);
            _dbContext.SaveChanges();
        }


        //把Genreid和
        public static void Extend()
        {
            var albums = _dbContext.Albums.ToList();
            foreach (var album in albums)
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