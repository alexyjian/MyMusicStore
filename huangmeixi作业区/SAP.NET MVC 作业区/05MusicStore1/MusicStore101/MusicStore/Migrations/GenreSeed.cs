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
            new Artist() { Name="林俊杰",Sex=true,Description="著名男歌手，作曲人、作词人、音乐制作人，偶像与实力兼具。林俊杰出生于新加坡的一个音乐世家。在父母的引导下，4岁就开始学习古典钢琴，不善言辞的他由此发现了另一种与人沟通的语言。小时候的林俊杰把哥哥林俊峰当作偶像，跟随哥哥的步伐做任何事，直到接触流行音乐后，便爱上创作这一条路。2003年以专辑《乐行者》出道，2004年一曲《江南》红遍两岸三地，凭借其健康的形象，迷人的声线，出众的唱功，卓越的才华，迅速成为华语流行乐坛的领军人物之一，迄今为止共创作数百首音乐作品，唱片销量在全亚洲逾1000万张。2007年成立个人音乐制作公司JFJ，2008创立潮流品牌SMG。2011年被媒体封为“新四大天王”之一，同年8月8日正式加盟华纳音乐，开启事业新乐章。2012年发行故事影像书《记得》，成功跻身畅销书作家行列。获得多项奖项：第15届台湾金曲奖最佳新人奖，6届新加坡金曲奖大奖，6届新加坡词曲版权协会大奖，8届全球华语歌曲排行榜大奖，5届MusicRadio中国TOP排行榜大奖。"},
            new Artist() { Name="五月天",Sex=true,Description="台湾乐团，由乐队团长兼吉他手怪兽、主唱阿信、吉他手石头、贝斯玛莎和鼓手冠佑组成。五月天的前身是SoBand，是由四个师大附中学生组成，329野台开唱的表演所以就改叫五月天，同时也把329当成五月天的成军日。在1997年3月29日改名为“五月天”。乐团的名称是来自贝斯手玛莎在网络论坛上的代号。1999年，台北市立体育场五月天第168场万人演唱会。台湾第一个站上体育场开演唱会的乐团，被视为华语乐团的奇迹，奠定了五月天的live魅力。截至2012年6月，四次夺下金曲奖“最佳乐团奖”，代表作《志明与春娇》、《疯狂世界》、《终结孤单》、《诺亚方舟》等。2017年5月16日入围金曲奖最佳乐团。"},
            new Artist() { Name="魏晨",Sex=true,Description="中国内地男歌手、演员，2007年参加湖南卫视快乐男声荣获年度总季军，2009年、2010年在国内首部青春励志偶像剧《一起来看流星雨》及《一起又看流星雨》中饰演叶烁，有“少女杀手”之称，誉为：“亚洲人气小天王”“内地全能偶像”，2010年发行首张专辑《千方百计》、2011年发行第二张专辑《破晓》，2012年10月15日发行第三张个人专辑《V SPACE》均销量火爆并获得多项大奖，深受乐坛及歌迷肯定。"},
            new Artist() { Name="李荣浩",Sex=true,Description="李荣浩，1985年7月11日生于蚌埠，中国流行音乐制作人、歌手、吉他手。曾为众多艺人创作歌曲以及担任制作人，也曾为多部电影与多款电子游戏制作音乐。2013年9月17日发行个人首张原创专辑《模特》，凭借这张专辑入围第25届金曲奖最佳国语男歌手奖、最佳新人奖、最佳专辑制作人、最佳国语专辑、最佳作词奖等五项大奖提名，成为最大黑马，实现了从制作人到歌手的华丽转身。"},
            new Artist() { Name="周杰论",Sex=true,Description="著名歌手，音乐人，词曲创作人，编曲及制作人，MV及电影导演。新世纪华语歌坛领军人物，中国风歌曲始祖，被时代周刊誉为“亚洲猫王”，是2000年后亚洲流行乐坛最具革命性与指标性的创作歌手，亚洲销量超过3100万张，有“亚洲流行天王”之称，开启华语乐坛“R&B时代”与“流行乐中国风”的先河，周杰伦的出现打破了亚洲流行乐坛长年停滞不前的局面，为亚洲流行乐坛翻开了新的一页，是华语乐坛真正把R&B提升到主流高度的人物，引领华语乐坛革命整十年，改写了华语乐坛的流行方向。"},
            new Artist() { Name="林有加",Sex=true,Description="新加坡人，华语著名歌手、词曲作者，音乐制作人。1997年在新加坡由其经纪公司 Music & Movement 旗下的Yellow Music发行英语专辑《Bored》而正式出道，1999年将国语唱片签约于宝丽金唱片旗下，并推出首张国语同名专辑《蔡健雅》。2000年因宝丽金唱片并入环球唱片旗下，因此《记念》及之后的唱片皆由台湾环球唱片发行。在此一专辑中，蔡健雅以〈记念〉一曲成功打响在台湾市场的知名度。同年入围台湾第11届金曲奖最佳新人奖。2002年发行《Secret Lavender》专辑。同年以〈打错了〉作曲者身份入围台湾第13届金曲奖最佳作曲人奖，并同时入围最佳国语演唱人奖。2004年首度担任制作人，替梁咏琪制作《归属感》专辑。同年以《陌生人》获得台湾第15届金曲奖最佳国语女演唱人提名。2008年推出专辑《My Space》，同年获台湾第19届金曲奖7项提名，并获得了最佳专辑制作人和最佳国语女歌手两座大奖。近年移居台湾。2012年获最佳国语女歌手奖。代表作品：《呼吸》《陌生人》《空白格》《若你碰到他》《红色高跟鞋》。"},

            };
            foreach(var b in artists)
                _dbContext.Artists.Add(b);
            _dbContext.SaveChanges();
            //遍历歌手

            var albums = new List<Album>
            {
           
             new Album { Title="演员",Genre=genres.Single(g=>g.Name=="流行"),Price=8.99M,Artist=artists.Single(a=>a.Name=="薛之谦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="意外",Genre=genres.Single(g=>g.Name=="流行"),Price=7.99M,Artist=artists.Single(a=>a.Name=="薛之谦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="哑巴",Genre=genres.Single(g=>g.Name=="流行"),Price=6.99M,Artist=artists.Single(a=>a.Name=="薛之谦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="像风一样的男子",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="烟火里的尘埃",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="我管你",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="异类",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="无聊人",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="我的滑板鞋",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="回忆的沙漏",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="毒苹果",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="邓紫棋"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="穿越火线",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="光年之外",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="另一个通话",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="小星星",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="有点甜",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="为你写诗",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="不分手的恋爱",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
             new Album { Title="三国杀",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
            new Album { Title="追光者",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="薛之谦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
            new Album { Title="万有引力",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="薛之谦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
            new Album { Title="红色高跟鞋",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},
            new Album { Title="陌生人",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},
            new Album { Title="思念是一种病",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},
            new Album { Title="重来",Genre=genres.Single(g=>g.Name=="流行"),Price=9.99M,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

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