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
            var genres = new List<Genre>
            {
                new Genre() { Name ="摇滚",Description ="Rock"},
                new Genre() { Name ="爵士",Description ="Jazz"},
                new Genre() { Name ="重金属",Description ="Metal"},
                new Genre() { Name ="慢摇",Description ="DownTempo"},
                new Genre() { Name ="蓝调",Description ="Blue"},
                new Genre() { Name ="拉丁",Description ="Latin"},
                new Genre() { Name ="流行",Description ="Pop"},
                new Genre() { Name ="古典",Description ="Classical"},
                new Genre() { Name ="DJ",Description ="DJ"},
                new Genre() { Name ="嘻哈",Description ="HiHop"},

            };
            foreach (var g in genres)
            {
                _dbContext.Genres.Add(g);
                _dbContext.SaveChanges();

            }

            var artists = new List<Artist>()
            {
                new Artist() { Name="张惠妹",Sex=false,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高，于海外（尤美、日等地）也有一定的知名度，已囊括多项华语圈重要的音乐奖项。" },
                new Artist() { Name="花粥",Sex=false,Description ="花粥是一名优秀的少先队员，英雄联盟召唤师，完全贯彻社会主义核心价值观的神秘地下音乐工作者。" },
                new Artist() { Name="陈粒",Sex=false,Description ="陈粒，又名粒粒，1990年7月26日出生于贵州省贵阳市，中国内地民谣女歌手、独立音乐人、唱作人，前空想家乐队主唱，毕业于上海对外经贸大学。2012年，其所在乐队“空想家乐队”获得“Zippo炙热摇滚大赛”上海赛区冠军。" },
                new Artist() { Name="蔡健雅",Sex=false,Description ="新加坡人，华语著名歌手、词曲作者，音乐制作人。1997年在新加坡由其经纪公司 Music & Movement 旗下的Yellow Music发行英语专辑《Bored》而正式出道，1999年将国语唱片签约于宝丽金唱片旗下，并推出首张国语同名专辑《蔡健雅》。" },
                new Artist() { Name="田馥甄",Sex=false,Description ="田馥甄，艺名Hebe，台湾知名女艺人，女子演唱团体S.H.E组合成员，出生于台湾新竹县新丰乡，于2000年参加“宇宙2000实力美少女争霸战”选秀活动，并于同年与宇宙唱片（华研唱片前身）签约培训，接着在隔年与Selina、Ella组成S.H.E，并于2001年9月11日发行S.H.E首张专辑《女生宿舍》正式出道。" },
                new Artist() { Name="孙燕姿",Sex=false,Description ="孙燕姿（Stefanie Sun），新加坡人，华语流行女歌手，以独特的嗓音和唱腔、扎实的音乐功底著称。2000年签约华纳音乐，发行首张专辑《孙燕姿同名专辑》，以《天黑黑》一曲成名，并获得包括台湾金曲奖在内的亚洲各地15个最佳新人奖，至今仍为华语歌坛之纪录。" },
                new Artist() { Name="毛不易",Sex=true ,Description ="毛不易，原名王维家，1994年10月1日出生于黑龙江省齐齐哈尔市泰来县，中国内地流行乐男歌手，毕业于杭州师范大学护理专业。2017年，参加选秀娱乐节目《明日之子》的比赛，获得全国总决赛冠军，从而正式进入演艺圈；" },
                new Artist() { Name="林俊杰",Sex=true ,Description ="著名男歌手，作曲人、作词人、音乐制作人，偶像与实力兼具。林俊杰出生于新加坡的一个音乐世家。在父母的引导下，4岁就开始学习古典钢琴，不善言辞的他由此发现了另一种与人沟通的语言。" },
                new Artist() { Name="莫文蔚",Sex=false,Description ="莫文蔚 (Karen Joy Morris，艺名Karen Mok)，香港歌手和演员。1993年发行首张粤语唱片《karen莫文蔚》进入娱乐圈；1995年主演电影《大话西游》获得关注。" },
                new Artist() { Name="Fine乐团",Sex=false,Description ="内地流行乐独立音乐人Fine乐团由一男一女组成。男生冠南创作词曲，女生乔西负责演唱" },
                new Artist() { Name="万晓利",Sex=false,Description ="是一位富有浓郁人文色彩的民谣歌手，中国现代民谣的代表人物之一，浮华世界里一位坚定的歌唱者。万晓利给我留下的印象是一把木箱琴和千变万化的人声，后来他出动机的时候，居然拿出一支碗，用勺子在碗边划出丁冬之声，表情是无比虔诚的，效果是出人意料的。 万晓利因其独特的唱腔被观众评为颠覆民谣的歌手。" },
                new Artist() { Name="赵雷",Sex=false,Description ="民谣音乐人赵雷，中国内地新生代民谣歌手。1986年7月20日生于北京，高中时间接触音乐，开始学习吉他。年纪轻轻便踏遍祖国的大江南北，山河东西，足迹遍布陕甘、云藏，为自己的音乐之路，积累了大量时代底蕴与人文滋养。" },
                new Artist() { Name="王三溥",Sex=false,Description ="左手新古典，右手金属，踽踽行于音乐旅途。 微信公众号：王三溥 微博：王三溥" },
                new Artist() { Name="吴莫愁",Sex=false,Description ="吴莫愁（MoMo Wu），中国大陆新生代个性女歌手、新女性主义代言人、90后标志性人物。从小跟随父母亲开大篷车唱游全国，2012年凭《中国好声音》上出色表现获得全国总亚军，一举成名。" },
                new Artist() { Name="G.E.M.邓紫棋",Sex=false,Description ="邓紫棋成长于一个音乐世家，其母亲为上海音乐学院声乐系毕业生，外婆教唱歌，舅父拉小提琴，外公在乐团吹色士风。" },
                new Artist() { Name="Alan Walker",Sex=false,Description ="艾兰·奥拉夫·沃克（Alan Olav Walker），1997年8月24日出生于英国英格兰北安普敦郡，挪威DJ、音乐制作人。 2014年11月，在YouTube上推出个人电音作品《Fade》而出道。" },
            };

            foreach (var a in artists )
            {

                _dbContext.Artist .Add(a);
                _dbContext.SaveChanges();

            }

            new List<Album>
             {
                new Album
                {
                    Title ="The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="摇滚"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="蔡健雅"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title ="偷故事的人",Genre=genres.Single(g=>g.Name=="爵士"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="张惠妹"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                  new Album
                {
                    Title ="粥请客（厘小白）",Genre=genres.Single(g=>g.Name=="流行"),Price =9M,
                    Artist =artists .Single (a=>a.Name =="花粥"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                   new Album
                {
                    Title ="Best Better Ever",Genre=genres.Single(g=>g.Name=="流行"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="陈粒"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                   new Album
                {
                    Title ="渺小",Genre=genres.Single(g=>g.Name=="重金属"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="田馥甄"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title ="逆光",Genre=genres.Single(g=>g.Name=="慢摇"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="孙燕姿"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title ="那时的我们",Genre=genres.Single(g=>g.Name=="蓝调"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="毛不易"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title ="Despacito 缓缓",Genre=genres.Single(g=>g.Name=="拉丁"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="林俊杰"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title ="我们在中场相遇",Genre=genres.Single(g=>g.Name=="古典"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="莫文蔚"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                  new Album
                {
                    Title ="Different World",Genre=genres.Single(g=>g.Name=="DJ"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="Alan Walker"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                   new Album
                {
                    Title ="Diamond Heart (Remixes)",Genre=genres.Single(g=>g.Name=="DJ"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="Alan Walker"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title ="Diamond Heart",Genre=genres.Single(g=>g.Name=="DJ"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="Alan Walker"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title ="Darkside",Genre=genres.Single(g=>g.Name=="DJ"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="Alan Walker"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title ="回忆的沙漏 (10周年版)",Genre=genres.Single(g=>g.Name=="嘻哈"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="G.E.M.邓紫棋"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title ="另一个童话",Genre=genres.Single(g=>g.Name=="嘻哈"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="G.E.M.邓紫棋"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title ="光年之外",Genre=genres.Single(g=>g.Name=="嘻哈"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="G.E.M.邓紫棋"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title ="无所不在",Genre=genres.Single(g=>g.Name=="古典"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="吴莫愁"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title ="大奇葩",Genre=genres.Single(g=>g.Name=="古典"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="吴莫愁"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title ="朝暮",Genre=genres.Single(g=>g.Name=="流行"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="王三溥"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title ="十一月",Genre=genres.Single(g=>g.Name=="流行"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="王三溥"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title ="吉姆餐厅",Genre=genres.Single(g=>g.Name=="拉丁"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="赵雷"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
               new Album
                {
                    Title ="无法长大",Genre=genres.Single(g=>g.Name=="拉丁"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="赵雷"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
               new Album
                {
                    Title ="这一切没有想象的那么糟",Genre=genres.Single(g=>g.Name=="蓝调"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="万晓利"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
               new Album
                {
                    Title ="天秤之舟／牙齿，菠菜和豆腐与诗人，流浪汉和门徒",Genre=genres.Single(g=>g.Name=="蓝调"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="万晓利"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
               new Album
                {
                    Title ="写了好多事都是关于你",Genre=genres.Single(g=>g.Name=="慢摇"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="Fine乐团"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
               new Album
                {
                    Title ="I'm Sorry",Genre=genres.Single(g=>g.Name=="慢摇"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="Fine乐团"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
               new Album
                {
                    Title ="伟大的渺小",Genre=genres.Single(g=>g.Name=="重金属"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="林俊杰"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
               new Album
                {
                    Title ="从头",Genre=genres.Single(g=>g.Name=="摇滚"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="陈粒"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title ="奇妙能力歌 (remix版)",Genre=genres.Single(g=>g.Name=="摇滚"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="陈粒"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
               new Album
                {
                    Title ="无问",Genre=genres.Single(g=>g.Name=="爵士"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="毛不易"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
               new Album
                {
                    Title ="平凡的一天",Genre=genres.Single(g=>g.Name=="爵士"),Price =8.99M,
                    Artist =artists .Single (a=>a.Name =="毛不易"),
                    AlbumArtUrl ="/Content/Images/placeholder.gif"
                },
            }.ForEach(n => _dbContext.Album.Add(n));
            _dbContext.SaveChanges();
        }

            public static void Extend()
        {
            var albums = _dbContext.Album.ToList();
            foreach (var album in albums)
            {
                var item = _dbContext.Album.Find(album.ID);
                item.GenreId = item.Genre.ID.ToString();
                item.ArtistId = item.Artist.ID.ToString();
                _dbContext.SaveChanges();
                Thread.Sleep(3);
            }
        
        }
    }
}