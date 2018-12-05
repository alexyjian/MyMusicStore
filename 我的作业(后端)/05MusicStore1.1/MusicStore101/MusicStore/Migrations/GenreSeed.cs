using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System.Threading;

namespace MusicStore.Migrations
{
    public class GenreSeed
    {
        private static readonly MusicStoreEntity.EntityDBContext _dbContext = new MusicStoreEntity.EntityDBContext();
        public static void Seed()
        {
            _dbContext.Database.ExecuteSqlCommand("delete albums");
            _dbContext.Database.ExecuteSqlCommand("delete artists");
            _dbContext.Database.ExecuteSqlCommand("delete genres");
            var genres = new List<Genre>()
            {
                new Genre() {Name="摇滚" ,Description="Rock"},
                new Genre() {Name="爵士",Description="Jazz" },
                new Genre() {Name="重金属",Description="Metal" },
                new Genre() {Name="慢摇",Description="DownTempo" },
                new Genre() {Name="蓝调",Description="Blue" },
                new Genre() {Name="拉丁",Description="Latin" },
                new Genre() {Name="流行",Description="Pop" },
                new Genre() {Name="古典",Description="Classical" },
                new Genre() {Name="土嗨" ,Description="DJ"},
                new Genre() {Name="嘻哈",Description="Hip-Hop" },
            };
            foreach (var g in genres)
                _dbContext.Genres.Add(g);

            var artists = new List<Artist>()
                {
                     new Artist() {Name ="孙燕姿",Sex= false,Description="新加坡人，华语流行女歌手，以独特的嗓音和唱腔、扎实的音乐功底著称。2000年签约华纳音乐，发行首张专辑《孙燕姿同名专辑》，以《天黑黑》一曲成名，并获得包括台湾金曲奖在内的亚洲各地15个最佳新人奖，至今仍为华语歌坛之纪录。2003年，发表新专辑《The Moment》，其中《遇见》一曲迅速为听众所熟悉，连年囊括各地颁奖礼最佳女歌手、身处事业巅峰期的她暂别歌坛一年。2004年携《Stefanie》专辑完美复出，并凭此专辑获得2005年第16届金曲奖最佳女歌手，之后又发表《逆光》(2007)、《是时候》(2011)等经典专辑。她的歌积极向上、给人力量，个人风格明显，深受听众喜爱。多次获得各地音乐奖项，六次入围台湾金曲奖最佳女歌手、四次入围最佳专辑、七次获得香港IFPI十大销量国语唱片奖。2014年发行新专辑《克卜勒》，并展开新一轮的克卜勒巡回演唱会" },
                     new Artist() {Name ="华晨宇",Sex = true,Description="1990年2月7日生于湖北十堰 ，中国男歌手，毕业于武汉音乐学院。 2013年，参加湖南卫视《快乐男声》获年度总冠军出道 。2014年1月，首登央视春晚舞台。9月6日-7日，在北京万事达中心连开两场“火星”演唱会 ，随后首张个人专辑《卡西莫多的礼物》发行 ，并凭此专辑获第十五届音乐风云榜年度最受欢迎男歌手等奖项。同年7月31日—8月2日，2015火星演唱会在上海大舞台连开三场。12月，发行第二张专辑《异类》。 2016年7-9月，2016火星演唱会相继在北上深三个城市举办。9月27日，出席亚洲新歌榜2016年度盛典，揽获最佳男歌手奖。10月，加盟东方卫视《天籁之战》。12月2日，获2016MAMA亚洲最佳艺人奖。2017年3月14日，专辑《H》发行。" },
                     new Artist() {Name ="Eminem",Sex = true,Description="是美国的一名说唱歌手。其风格类型为：Hardcore Rap（硬核说唱）。埃米纳姆最大的突破就是证明白人也能介入到黑人一统天下的说唱（RAP）界中，而且获得巨大的成功。同时他的叛逆不仅长期以来深受美国青少年喜爱，也让他在舆论中始终遭到抨击。Eminem获得的奖杯总数窜至历史第三位，居麦当娜和皮特-加布里埃尔之后。" },
                     new Artist() {Name ="Avril",Sex = false,Description="是一位加拿大的唱作歌手及演员。15岁时，她曾与仙妮亚·唐恩同台演出；16岁时，她与爱丽斯塔唱片签订了一份价值200万美元的两张唱片合约。2002年，十七岁的她发行了首张专辑《展翅高飞》，由此开始了她的音乐事业，她在专辑中展现了“朋克滑板族”的形象，常被评论家和音乐出版社称为“流行朋克公主”。由于她在业内的成就和影响，以及她开创了女歌手对受朋克影响的流行音乐领域的驾驭，艾薇儿被认为是推动流行朋克音乐发展的重要艺人。从她首张专辑开始，艾薇儿在全球售出了超过4千万张专辑和超过5千万张单曲，她成为了历史上继席琳·迪翁之后第二畅销的加拿大女歌手。" },
                     new Artist() {Name ="周杰伦",Sex = true,Description="著名歌手，音乐人，词曲创作人，编曲及制作人，MV及电影导演。新世纪华语歌坛领军人物，中国风歌曲始祖，被时代周刊誉为“亚洲猫王”，是2000年后亚洲流行乐坛最具革命性与指标性的创作歌手，亚洲销量超过3100万张，有“亚洲流行天王”之称，开启华语乐坛“R&B时代”与“流行乐中国风”的先河，周杰伦的出现打破了亚洲流行乐坛长年停滞不前的局面，为亚洲流行乐坛翻开了新的一页，是华语乐坛真正把R&B提升到主流高度的人物，引领华语乐坛革命整十年，改写了华语乐坛的流行方向。" },
                     new Artist() {Name ="林肯公园",Sex = true,Description="是一组来自美国加利福尼亚州的摇滚乐队，由乐队主唱查斯特·贝宁顿，麦克·信田、贝斯手菲尼克斯·法雷尔、吉他手布莱德·德尔森、鼓手罗伯·巴登和DJ采样手约瑟夫·韩组成。 林肯公园在2000年以首张专辑《混合理论》（Hybrid Theory）在主流音乐市场上获得成功，专辑销售量超过2400万张。2002年11月发行第二张专辑《流星圣殿》（Meteora）。2002、2006年获得格莱美奖。2007年5月15日发行第三张专辑《末日警钟：毁灭·新生》（Minutes to Midnight） 。2010年，林肯公园发行第四张专辑《烈日千阳》（A Thousand Suns）。2012年，林肯公园推出第五张专辑《生命·进化·原点》（Living Things），于6月26日全球发行。2014年6月13日，乐队发行第六张专辑《狩猎聚会》（The Hunting Party） 。2017年5月19日，林肯公园发行第七张专辑《光芒再现》（One More Light）。同年7月，美国当地时间20日9点，乐队主唱查斯特·贝宁顿在住宅内上吊自杀。 演艺活动外，林肯公园还助力于慈善事业。2005年创立公益组织“Music For Relief”（MFR）。2008年为四川地震灾区提供援助。2011年获得联合国基金会颁发的“全球领袖”奖 。" },
                     new Artist() {Name ="周笔畅",Sex = false,Description="华语流行女歌手，首位获美国格莱美大师为其写歌的华语歌手；首位英文歌被国际歌后翻唱的华语歌手。周笔畅出生于湖南长沙的一个“音乐世家”，2005年参加选秀《超级女声》夺得亚军，，从而红遍大江南北。2006年3月18日签约乐林文化，发行首张EP《周笔畅 1st EP》和首张个人音乐专辑《谁动了我的琴弦》。2008年年底发行“双子专辑”《NOW》&《WOW》并取得优异成绩：在当地零宣传的情况下双双入围台湾最具公信力的唱片销量排行榜G-music前10名，《NOW》更是取得空降亚军的佳绩，开创了内地歌手登陆台湾唱片市场的另一个奇迹。2010年周笔畅首次个人全国巡回演唱会—“唱歌去旅行”2010年5月29日，旅行第一站--广州，创下了40分钟万张门票全部售罄的惊人记录。后周笔畅还自创潮牌Begins，成立个人工作室Begins Studio。代表作品：《笔记》《谁动了我的琴弦》《鱼罐头》。" },
                     new Artist() {Name ="SMAP",Sex = true,Description="结成于1988年4月，并在1991年9月9日以单曲CD“Can't Stop!!-LOVING-”正式出道，是日本杰尼斯事务所旗下的组合，现由木村拓哉、中居正广、稻垣吾郎、香取慎吾、草彅刚五位成员组成。中国总理温家宝2011年5月与SMAP见面交谈，SMAP更为他献唱一曲《世界上唯一的花》。SMAP主要代表作有《世界に一つだけの花》、《夜空ノムコウ》、《らいおんハート》、《仆の半分》、《さかさまの空》等。" },
                     new Artist() {Name ="张惠妹",Sex = false,Description="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手（并且在2011年第二度接受此媒体《Talk Asia》节目专访）。阿妹在1996年三月被著名台湾音乐人陈志远、陈复明发现并签约丰华唱片。并在同年7月在带自己入行的恩师张雨生的《两伊战争－红色热情》专辑中与张雨生男女对唱《最爱的人伤我最深》。同年12月13日，张惠妹在张雨生的协助下发行第一张个人专辑《姐妹》。1998年 举办第一场个人大型户外售票演唱会“妹力四射”，创下台湾歌手有史以来最快举行大型演唱会的纪录。2009年发行的《阿密特》专辑至今仍是金曲奖史上获得最大成功的作品，曾于第21届时擒下包括专辑、制作人、歌手等六项大奖。代表作品：《姐妹》、《我可以抱你吗》、《记得》、《火》、《如果你也听说》、《掉了》、《我最亲爱的》。" },
                     new Artist() {Name ="林俊杰",Sex = true,Description="著名男歌手，作曲人、作词人、音乐制作人，偶像与实力兼具。林俊杰出生于新加坡的一个音乐世家。在父母的引导下，4岁就开始学习古典钢琴，不善言辞的他由此发现了另一种与人沟通的语言。小时候的林俊杰把哥哥林俊峰当作偶像，跟随哥哥的步伐做任何事，直到接触流行音乐后，便爱上创作这一条路。2003年以专辑《乐行者》出道，2004年一曲《江南》红遍两岸三地，凭借其健康的形象，迷人的声线，出众的唱功，卓越的才华，迅速成为华语流行乐坛的领军人物之一，迄今为止共创作数百首音乐作品，唱片销量在全亚洲逾1000万张。2007年成立个人音乐制作公司JFJ，2008创立潮流品牌SMG。2011年被媒体封为“新四大天王”之一，同年8月8日正式加盟华纳音乐，开启事业新乐章。2012年发行故事影像书《记得》，成功跻身畅销书作家行列。获得多项奖项：第15届台湾金曲奖最佳新人奖，6届新加坡金曲奖大奖，6届新加坡词曲版权协会大奖，8届全球华语歌曲排行榜大奖，5届MusicRadio中国TOP排行榜大奖。" },
                     new Artist() {Name ="陈奕迅",Sex = true,Description="著名实力派粤语流行音乐歌手、演员，香港演艺人协会副会长之一，曾被美国《时代杂志》形容为影响香港乐坛风格的人物，同时也是继许冠杰、张学友之后第三个获得“歌神”称号的香港男歌手。同时他也是继张学友后另一个在台湾获得成功的香港歌手，在2003年他成为了第二个拿到台湾金曲奖“最佳国语男演唱人”的香港歌手。陈奕迅曾被《时代》杂志形容为影响香港乐坛风格的人物。2010年，陈奕迅入选全球华人音乐殿堂华语金曲奖“30年经典评选”，成为1990年代出道歌手唯一代表。陈奕迅曾在多个亚太地区获得多个奖项和提名，包括香港地区的“叱咤乐坛男歌手金奖”、“叱咤乐坛我最喜爱的男歌手奖”、“十大劲歌金曲最受欢迎男歌星奖”。代表作品：《爱情转移》、《十年》、《浮夸》、《K歌之王》" },
                     new Artist() {Name ="陈粒",Sex = false,Description="陈粒，又名粒粒，1990年7月26日出生于贵州省贵阳市，中国内地民谣女歌手、独立音乐人、唱作人，前空想家乐队主唱，毕业于上海对外经贸大学。2012年，其所在乐队“空想家乐队”获得“Zippo炙热摇滚大赛”上海赛区冠军。2014年，随空想家乐队推出乐队首张EP专辑《万象》；同年，其演唱的歌曲《奇妙能力歌》入围“第四届阿比鹿音乐奖”年度民谣单曲。2015年，推出首张个人音乐专辑《如也》；同年，推出个人民谣单曲《远辰》。2016年1月，获得“第五届阿比鹿音乐奖”最受欢迎音乐人（民谣）；同年3月8日，化身“粒粒”并推出首支单曲《幻期颐》；同年7月26日，推出第二张个人音乐专辑《小梦大半》。" },
                     new Artist() {Name ="吴亦凡",Sex = true,Description="1990年11月06日出生于广东省广州市，华语影视男演员、流行乐歌手。2007年吴亦凡通过S.M. GlobalAudition Canada加入了韩国SM娱乐公司，参加练习生培训。2012年作为EXO组合成员正式出道，担任EXO/EXO-M队长、主Rapper、门面。2014年5月15日，吴亦凡正式向首尔中央地方法院请求判决与SM娱乐公司专属合同无效。之后吴亦凡回归中国国内发展，出演个人首部电影，担任徐静蕾执导的电影《有一个地方只有我们知道》男主角，凭此获得第3届伦敦国际华语电影节最佳新锐男演员奖。2015年发行首张原创制作单曲《Bad Girl》获第6届全球流行音乐金榜年度最受欢迎新人和亚洲新歌榜年度最具影响力男歌手奖。年底主演电影《老炮儿》上映，因饰演小爷谭小飞一角进一步受到广泛关注。2016年1月博柏利160周年，登上博柏利秀场，同年担任博柏利华人全球代言人。7月主演电影《原来你还在这里》累计票房3.37亿创同年青春片票房纪录。8月主演电影《夏有乔木》上映，以总预售超3600万在同题材影片中拔得头筹4天票房累计过亿，凭此获得日中电影节金鹤奖最佳男主角。11月公布首张英文单曲《JULY》。2017年2月主演电影《西游伏妖篇》票房累计突破16亿，吴亦凡在片中饰演男一号唐三藏。同月受邀第59届格莱美颁奖典礼。" },
                };
            foreach (var a in artists)
                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();


            new List<Album>
            {
                new Album {Title="逆光",Genre = genres.Single(g=>g.Name =="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="孙燕姿"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title="烟火里的尘埃",Genre = genres.Single(g=>g.Name =="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="华晨宇"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title="The Marshall Mathers LP",Genre = genres.Single(g=>g.Name =="嘻哈"),Price=8.99M,Artist=artists.Single(a=>a.Name=="Eminem"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title="The Best Damn Thing",Genre = genres.Single(g=>g.Name =="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="Avril"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title="叶惠美",Genre = genres.Single(g=>g.Name =="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="周杰伦"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title="Numb",Genre = genres.Single(g=>g.Name =="摇滚"),Price=8.99M,Artist=artists.Single(a=>a.Name=="林肯公园"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title="岁月神偷",Genre = genres.Single(g=>g.Name =="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="周笔畅"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title="世界に一つだけの花",Genre = genres.Single(g=>g.Name =="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="SMAP"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title ="勇敢",Genre = genres.Single(g=>g.Name =="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="张惠妹"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title ="不为谁而作的歌",Genre = genres.Single(g=>g.Name =="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="林俊杰"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title ="U-87",Genre = genres.Single(g=>g.Name =="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="陈奕迅"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title ="如也",Genre = genres.Single(g=>g.Name =="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="陈粒"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title ="JULY",Genre = genres.Single(g=>g.Name =="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="吴亦凡"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title ="The Eminem Show",Genre = genres.Single(g=>g.Name =="嘻哈"),Price=8.99M,Artist=artists.Single(a=>a.Name=="Eminem"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title ="依然范特西",Genre = genres.Single(g=>g.Name =="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="周杰伦"), AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album {Title ="异类",Genre = genres.Single(g=>g.Name =="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="华晨宇"), AlbumArtUrl="/Content/images/placeholder.gif"},
            }.ForEach(n => _dbContext.Albums.Add(n));
            _dbContext.SaveChanges();
        }


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
    
