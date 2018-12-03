using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace MusicStore.Migrations
{
    public class GenreSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();

        public static void Seed()
        {
            var genres = new List<Genre>
            {
                new Genre() {Name ="摇滚" ,Description="Rock"},
                new Genre() {Name ="爵士" ,Description="Jazz" },
                new Genre() {Name ="重金属" ,Description="Metal" },
                new Genre() {Name ="后摇" ,Description="Rear"},
                new Genre() {Name ="轻音",Description="K-on" },
                new Genre() {Name ="电音",Description="Electric" },
                new Genre() {Name ="雷鬼",Description="Reggae" },
                new Genre() {Name ="流行" ,Description="Popular"},
            };
            foreach (var g in genres)
                _dbContext.Genres.Add(g);

            _dbContext.SaveChanges();
            var artisrt = new List<Artist>
            {
                new Artist() {Name="蔡健雅", Sex=false,Description="新加坡人，华语著名歌手、词曲作者，音乐制作人。1997年在新加坡由其经纪公司 Music & Movement 旗下的Yellow Music发行英语专辑《Bored》而正式出道，1999年将国语唱片签约于宝丽金唱片旗下，并推出首张国语同名专辑《蔡健雅》。2000年因宝丽金唱片并入环球唱片旗下，因此《记念》及之后的唱片皆由台湾环球唱片发行。在此一专辑中，蔡健雅以〈记念〉一曲成功打响在台湾市场的知名度。同年入围台湾第11届金曲奖最佳新人奖。2002年发行《Secret Lavender》专辑。同年以〈打错了〉作曲者身份入围台湾第13届金曲奖最佳作曲人奖，并同时入围最佳国语演唱人奖。2004年首度担任制作人，替梁咏琪制作《归属感》专辑。同年以《陌生人》获得台湾第15届金曲奖最佳国语女演唱人提名。2008年推出专辑《My Space》，同年获台湾第19届金曲奖7项提名，并获得了最佳专辑制作人和最佳国语女歌手两座大奖。近年移居台湾。2012年获最佳国语女歌手奖。代表作品：《呼吸》《陌生人》《空白格》《若你碰到他》《红色高跟鞋》。"},
                new Artist() {Name="王以太", Sex=true,Description="cdc说唱会馆 王以太 3ho"},
                new Artist() {Name="The Chainsmokers", Sex=true,Description="The Chainsmokers，是来自美国纽约的DJ组合。由成员安德鲁·塔格特和亚历克斯·鲍尔组成，2014年因一曲《#Selfie》而出名。"},
                new Artist() {Name="马雨阳", Sex=true,Description="我知道我不一般，一切就都不一般。"},
                new Artist() {Name="张学友", Sex=true,Description="在亚洲地区和整个华人社会具有影响力的实力派音乐巨星和著名电影演员，香港乐坛“四大天王”之一，在华语地区享有“歌神”的美誉。90年代中期为张学友事业巅峰时期，根据IFPI国际唱片协会统计，张学友的唱片销量仅次于当时如日中天的已故美国歌手迈克尔·杰克逊，当时排名世界第二。截止2006年，其全球正版唱片销量已达1.2亿张之多，为华人之首。影视方面，张学友在1989年获得香港电影金像奖的最佳男配角奖以及1990年的台湾电影金马奖的最佳男配角奖，2002年获得印度新德里电影节的最佳男演员奖。张学友擅长演绎多种音乐风格，近年来尝试R&B乐风和爵士乐，甚至以歌剧唱法来诠释乐曲，同样受到乐迷认同。"},
                new Artist() {Name="五月天", Sex=true,Description="台湾乐团，由乐队团长兼吉他手怪兽、主唱阿信、吉他手石头、贝斯玛莎和鼓手冠佑组成。五月天的前身是SoBand，是由四个师大附中学生组成，329野台开唱的表演所以就改叫五月天，同时也把329当成五月天的成军日。在1997年3月29日改名为“五月天”。乐团的名称是来自贝斯手玛莎在网络论坛上的代号。1999年，台北市立体育场五月天第168场万人演唱会。台湾第一个站上体育场开演唱会的乐团，被视为华语乐团的奇迹，奠定了五月天的live魅力。截至2012年6月，四次夺下金曲奖“最佳乐团奖”，代表作《志明与春娇》、《疯狂世界》、《终结孤单》、《诺亚方舟》等。2017年5月16日入围金曲奖最佳乐团。"},
                new Artist() {Name="胡66", Sex=false,Description="昵称：胡66爱唱歌- 所在地：北京 性别：女 微博：胡66爱唱歌 生日：1998年5月28日"},
                new Artist() {Name="萨顶顶", Sex=false,Description="原名周鹏，中国大陆女歌手，音乐人，制作人。2000年大学期间参加第九届CCTV全国青年歌手大奖赛，获得专业组通俗唱法银奖。最早为人知的作品有一首叫做《咚巴拉》的歌曲，那会儿周鹏还未改名萨顶顶。2006年全新的萨顶顶以《万物生》再次走红。以独具民族特色的服装及具藏传佛教色彩的音乐风格而著名。是中国首位被格莱美邀请的歌手。2008年获得英国BBC世界音乐大奖亚太区最佳歌手大奖。曾经荣获两届“格莱美”世界音乐大奖的法国著名音乐家DEEP FOREST（森林深处），因为有感于中汶川地震，特别联合他最欣赏的中国音乐人萨顶顶（08年“BBC世界音乐大奖”获得亚洲第一歌手大奖）共同创作并演唱了赈灾歌曲《Won't be long》。代表作《万物生》《天地合》《恍如来者》。"},
                new Artist() {Name="Taylor Swift", Sex=false,Description="泰勒·斯威夫特（Taylor Swift），美国乡村音乐著名创作女歌手。1989年出生于美国宾州。2006年与独立唱片公司Big Machine签约并发行首张个人专辑《Taylor Swift》。第二张专辑《Fearless》在2008年11月11日发行，在Billboard排行榜上到达了第一的位置，首支单曲《Love Story》在2008年9月正式发行，成为了第二畅销的乡村单曲，在公告牌最热100中最高排到第四。该专辑也卖出了乡村音乐最高的销售量约60万张，包括其他种类的音乐，也是美国女歌手公开销售最多的专辑。Taylor曾获得美国乡村音乐协会奖年度最佳专辑奖、格莱美年度专辑奖等荣誉。"},
                new Artist() {Name="Selena Gomez", Sex=false,Description="赛琳娜·戈麦斯（Selena Gomez），1992年7月22日出生于美国得克萨斯州，美国女演员、歌手。 在2004年的迪士尼全球才艺计划中，赛琳娜被迪士尼相中并签约。2007年主演原创魔幻喜剧《少年魔法师》，一举成名。2008年主演三部迪士尼原创电影《灰姑娘之舞动奇迹》、《公主保护计划》与《少年魔法师电影: 神秘魔法石》。2009年4月组建乐队Selena Gomez & The Scene；同年9月29日发行首张专辑《Kiss & Tell》。第二张专辑《A Year without Rain》于2010年9月发行。2011年担任MTV欧洲音乐大奖颁奖礼主持人。2013年7月19日发行第三张专辑《Stars Dance》。"},
                new Artist() {Name="Rihanna", Sex=false,Description="蕾哈娜（Rihanna），1988年2月20日出生于巴巴多斯圣迈克尔区，在美国发展的巴巴多斯女歌手、演员、模特。 2005年8月发行首张音乐专辑《Music of the Sun》开始歌唱事业生涯。2008年在第50届格莱美奖上入围“年度制作“和“年度歌曲”在内的六项提名，凭借歌曲《Umbrella》获得“最佳饶舌/演唱合作”奖。 2011年被巴巴多斯政府授予为旅游大使，巴巴多斯政府也将每年的2月20日定为“蕾哈娜日”。2012年首次以演员身份主演的好莱坞科幻战争电影《超级战舰》上映。 2015年4月公开歌曲《American Oxygen》音源与MV。 截至2015年，蕾哈娜在美国公告牌榜上拥有12首冠军单曲，被评选2010年最佳艺人奖，也是蝉联多座格莱美、全英音乐和MTV音乐大奖，并二次获得MTV年度录影带大奖的女歌手。"}

            };
            foreach (var a in artisrt)
                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();
            new List<Album>
            {
                new Album() {Title="dd",Genre =genres.Single(g=>g.Name=="摇滚" ),Artist=artisrt.Single(a=>a.Name=="Taylor Swift"),AlbumArtUrl="/Content/images/placeholder.gif"},
                new Album() { Title="The Best Of Men At Work",Genre =genres.Single(g=>g.Name=="摇滚" ),Price=10.8M,Artist=artisrt.Single(a=>a.Name=="Taylor Swift"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="A Copland Celebration,",Genre =genres.Single(g=>g.Name=="摇滚" ),Price=3.99M,Artist=artisrt.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="For Those About To Rock We",Genre =genres.Single(g=>g.Name=="摇滚" ),Price=4.99M,Artist=artisrt.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Let There Be ",Genre =genres.Single(g=>g.Name=="爵士" ),Price=6.99M,Artist=artisrt.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Balls to the Wall",Genre =genres.Single(g=>g.Name=="爵士" ),Price=2.99M,Artist=artisrt.Single(a=>a.Name=="王以太"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Restless and Wild",Genre =genres.Single(g=>g.Name=="爵士" ),Price=5.99M,Artist=artisrt.Single(a=>a.Name=="王以太"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Górecki: Symphony No. 3",Genre =genres.Single(g=>g.Name=="爵士" ),Price=22.99M,Artist=artisrt.Single(a=>a.Name=="王以太"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Big Ones",Genre =genres.Single(g=>g.Name=="重金属" ),Price=2.99M,Artist=artisrt.Single(a=>a.Name=="The Chainsmokers"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Quiet Songs",Genre =genres.Single(g=>g.Name=="重金属" ),Price=3.99M,Artist=artisrt.Single(a=>a.Name=="Selena Gomez"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Jagged Little Pill",Genre =genres.Single(g=>g.Name=="重金属" ),Price=2.99M,Artist=artisrt.Single(a=>a.Name=="The Chainsmokers"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Frank",Genre =genres.Single(g=>g.Name=="轻音" ),Price=9.99M,Artist=artisrt.Single(a=>a.Name=="The Chainsmokers"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Ring My Bell",Genre =genres.Single(g=>g.Name=="轻音" ),Price=3.99M,Artist=artisrt.Single(a=>a.Name=="马雨阳"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Chill: Brazil",Genre =genres.Single(g=>g.Name=="轻音" ),Price=6.99M,Artist=artisrt.Single(a=>a.Name=="Selena Gomez"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Warner 25 Anos",Genre =genres.Single(g=>g.Name=="电音" ),Price=3.99M,Artist=artisrt.Single(a=>a.Name=="Rihanna"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Plays Metallica By Four Cellos",Genre =genres.Single(g=>g.Name=="电音" ),Price=2.99M,Artist=artisrt.Single(a=>a.Name=="马雨阳"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Revelations",Genre =genres.Single(g=>g.Name=="电音" ),Price=66.99M,Artist=artisrt.Single(a=>a.Name=="张学友"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Audioslave",Genre =genres.Single(g=>g.Name=="电音" ),Price=899M,Artist=artisrt.Single(a=>a.Name=="张学友"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="The Last Night of the Proms",Genre =genres.Single(g=>g.Name=="雷鬼" ),Price=83.99M,Artist=artisrt.Single(a=>a.Name=="五月天"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Sibelius: Finlandia",Genre =genres.Single(g=>g.Name=="雷鬼" ),Price=82.99M,Artist=artisrt.Single(a=>a.Name=="张学友"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Mozart: Symphonies",Genre =genres.Single(g=>g.Name=="雷鬼" ),Price=8.99M,Artist=artisrt.Single(a=>a.Name=="五月天"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="The Best Of Billy Cobham",Genre =genres.Single(g=>g.Name=="后摇" ),Price=3.99M,Artist=artisrt.Single(a=>a.Name=="张学友"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Alcohol Fueled Brewtality Live",Genre =genres.Single(g=>g.Name=="后摇" ),Price=3.99M,Artist=artisrt.Single(a=>a.Name=="五月天"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Carmina Burana",Genre =genres.Single(g=>g.Name=="后摇" ),Price=3.99M,Artist=artisrt.Single(a=>a.Name=="胡66"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Chemical Wedding",Genre =genres.Single(g=>g.Name=="流行" ),Price=2.99M,Artist=artisrt.Single(a=>a.Name=="胡66"),AlbumArtUrl="/Content/images/placeholder.gif" },
                new Album() { Title="Prenda Minha",Genre =genres.Single(g=>g.Name=="流行" ),Price=0.99M,Artist=artisrt.Single(a=>a.Name=="Rihanna"),AlbumArtUrl="/Content/images/placeholder.gif" }
            }.ForEach(n => _dbContext.Albums.Add(n));

            _dbContext.SaveChanges();
        }

        public static void Extend()
        {
            var albums = _dbContext.Albums.ToList();
            foreach (var i in albums)
            {
                var item = _dbContext.Albums.Find(i.ID);
                item.GenreID = item.Genre.ID.ToString();
                item.ArtistID = item.Artist.ID.ToString();
                Thread.Sleep(5);
            }
            _dbContext.SaveChanges();
        }
}
}