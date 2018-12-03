using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStoreEntity;
using System.Threading;

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
                new Genre() {Name = "摇滚",Description = "Rock"},
                new Genre() {Name =  "爵士",Description = "Jazz"},
                new Genre() {Name =  "重金属",Description = "重金属"},
                new Genre() {Name =  "慢摇",Description = "DownTempo"},
                new Genre() {Name =  "蓝调",Description = "Blue"},
                new Genre() {Name =  "拉丁",Description = "Latin"},
                new Genre() {Name =  "流行",Description = "Pop"},
                new Genre() {Name =  "古典",Description = "Classical"},
                new Genre() {Name =  "DISCO",Description = "DISCO"},
                new Genre() {Name =  "嘻哈",Description = "HiHop"},
            };
            foreach ( var g  in genres)
                _dbContext.Genres.Add(g);

            var artists = new List<Artist>()
            {
                  new Artist() {Name = "欢子",Sex = false,Description = "2003年以一首《恋上你的滋味》出道，出道至2014年，相继发行了《愚爱》《得到你的人却得不到你的心》《其实很寂寞》《我们回不去了》《新欢主义》五张个人原创专辑。2010年期间，《心痛2009》《原谅我一次》《其实很寂寞》《得到你的人却得不到你的心》等歌曲在华语乐坛大热，欢子排名常年跃居各大音乐排行榜前列榜首，专辑销量在内地唱片市场销量前三名。2011年，而凭借歌曲《失恋排行榜》荣获华语金曲奖优秀原创歌手奖和劲歌王最佳新晋歌手奖以及音乐先锋榜乐坛进步奖。"},
                new Artist() {Name = "郑源",Sex = false,Description = "郑源（Jacky），1982年11月2日生于广东阳江，华语流行男歌手，内地情歌王子，著名音乐人，实力唱作人，词曲创作家，华语乐坛情歌界代表性人物之一，北京戏曲学院音乐教授，毕业于星海音乐学院。 " },
                new Artist() {Name = "郑源",Sex = false,Description = "周华健（Emil Wakin Chau），1960年12月22日生于香港西营盘，中国流行乐男歌手、音乐人、演员，毕业于台湾大学。1984年凭借个人创作单曲《谁曾说过》进入演艺圈。1986年加入滚石唱片公司。1987年凭借专辑《心的方向》获得关注；同年参演电影处女作《桂花巷》。1989年发行个人首张概念专辑《最真的梦》，其中歌曲《这城市有爱》获得第2届台湾金曲奖最佳年度歌曲奖。"},
                new Artist() {Name = "张学友",Sex = false,Description ="张学友，1961年7月10日出生于香港，歌手、演员，毕业于香港崇文英文书院。1984年因获得首届香港十八区业余歌唱大赛冠军而出道。1985年发行个人首张专辑《Smile》。1993年发行的专辑《吻别》打破华语唱片在台湾的销量纪录。1995年起连续两年获得世界音乐大奖全球销量最高华人歌手奖。1997年参与策划的音乐剧《雪狼湖》在香港连续演出42场。" },
                new Artist() {Name = "张杰",Sex = false,Description ="张杰，1982年12月20日出生，四川成都人，中国内地流行男歌手。2004年参加选秀节目《我型我秀》，以成名曲《北斗星的爱》出道。已发行10张唱片。2008年以来举办过8场爆满的个人演唱会，在各大权威音乐奖项中先后24次获得“最受欢迎男歌手”称号，2010年在韩国M-net亚洲音乐大赏(MAMA)上获得“亚洲之星”（Best Asian Artist），影响力触及海外。" },
                new Artist() {Name = "邓紫棋",Sex = false,Description ="邓紫棋（G.E.M.），1991年8月16日生于中国上海，4岁移居香港，中国香港创作型女歌手。2009年1月，夺得叱咤乐坛流行榜“叱咤乐坛生力军女歌手金奖”，是该奖的首位未成年获得者。2011年，邓紫棋在香港红馆举行5场个人演唱会。2013年4月，邓紫棋在香港红馆启动 “G.E.M.X.X.X.Live”世界巡回演唱会。2014年，参加《我是歌手第二季》，夺得总决赛亚军。" },
                new Artist() {Name = "王力宏",Sex = false,Description ="王力宏（Leehom Wang），1976年5月17日出生于美国纽约，籍贯浙江义乌。华语流行男歌手、音乐制作人、演员、导演。1995年在台湾地区发行首张专辑《情敌贝多芬》出道。1998年发行专辑《公转自转》，2004年发行Chinked-out专辑《心中的日月》，2005年发行Chinked-out第二辑《盖世英雄》，2008年发行新专辑《心跳》 " },
                new Artist() {Name = "冯提莫",Sex = false,Description ="冯提莫（本名冯亚男），1991年12月19日出生于重庆市万州区，中国内地女歌手、网络主播。" },
                new Artist() {Name = "熊木杏里",Sex = false,Description ="熊木杏里(Anri Kumaki)，1982年1月27日出生于日本长野县千曲市。日本治愈系歌手、作词家和作曲家，日本华纳唱片签约艺人 。2002年，熊木杏里以单曲《窓絵》正式走上乐坛 。2005年，发布了个人第二部专辑《无から出た锖》。2007年2月，发布单曲《春の风》。2012年1月 ，发布单曲《今日になるから》。2014年12月，熊木杏里正式发布专辑《生きているがゆえ》。2016年发布专辑《饰りのない明日》。2017年6月28日发布最新专辑《群青の日々》 。" },
                new Artist() {Name = "仓木麻衣",Sex = false,Description ="仓木麻衣，本名青野真衣。1982年10月28日出生于日本千叶县船桥市，日本女歌手、作词家，所属唱片公司为NORTHERN MUSIC。1999年12月，发行单曲《Love, Day After Tomorrow》在日本正式出道。2000年，发行首张专辑《delicious way》，该专辑累计近400万的销量，并获得公信榜年度销量冠军，随后推出的3张原创专辑也获得公信榜专辑周榜冠军 。2001年，在美国发行英文专辑《Secret of my heart》 。2004年，发行首张精选辑《Wish You The Best》，销量近百万。 2009年，发行第八张专辑《touch Me!》，首周获得公信榜专辑周榜冠军 ，同年的10周年精选辑《ALL MY BEST》亦登上该榜冠军 。2014年，发行双主打单曲《无敌的心/STAND BY YOU》 ，同年12月，发行15周年精选辑《MAI KURAKI BEST 151A -LOVE & HOPE-》。2015年5月20日，发布配信单曲《Serendipity》。2017年2月15日，发行专辑《Smile》 。同年为动画电影《名侦探柯南：唐红的恋歌》演唱主题曲《渡月桥～思君～》 ，并凭借该曲创下连续41张单曲进入公信榜单曲周榜前十位的纪录 。" },
                new Artist() {Name = "徐靖博",Sex = false,Description ="徐靖博，男，营口市人。2003年毕业于中央戏剧学院表演系，著名歌手，音乐制作人。成名代表作:《分手那天》个人单曲《回来我的爱》获得冠军。，男，营口市人。2003年毕业于中央戏剧学院表演系，著名歌手，音乐制作人。成名代表作:《分手那天》个人单曲《回来我的爱》获得冠军。2001年以主演日剧《新宿伤痕恋歌》及演唱单曲《STARS》同时出道。2002年获得日剧学院赏最佳新人奖。2003年主演电影《偶遇极恶少年》。" },
                new Artist() {Name = "中岛美嘉",Sex = false,Description ="中岛美嘉，1983年2月19日出生于日本日置市伊集院町，毕业于鹿儿岛市天保山中学,日本歌手、演员。" },
                new Artist() {Name = "刘德华",Sex = false,Description ="刘德华（Andy Lau），1961年9月出生于中国香港，中国知名演员、歌手、词作人、制片人、电影人，影视歌多栖发展的代表艺人之一。1982年以全优成绩毕业于TVB艺训班签约出道，同年凭《猎鹰》走红，1983年主演《神雕侠侣》在香港创62点收视纪录，后因拒签五年长约被TVB雪藏。" },
                new Artist() {Name = "梁朝伟",Sex = false,Description ="梁朝伟，1962年6月27日出生于中国香港，祖籍广东省台山市，毕业于香港无线训练班第11期，国家一级演员。 1982年，考入无线电视艺员训练班，正式进入演艺界。1984年，因出演电视剧《鹿鼎记》中的韦小宝一角受到关注。1990年，主演电影《喋血街头》。1998年，主演电影《暗花》。" },
            new Artist { Name = "Barry Wordsworth & BBC Concert Orchestra" },
                new Artist { Name = "Berliner Philharmoniker & Hans Rosbaud" },
                new Artist { Name = "Berliner Philharmoniker & Herbert Von Karajan" },
                new Artist { Name = "Billy Cobham" },
                new Artist { Name = "Black Label Society" },
                new Artist { Name = "Black Sabbath" },
                new Artist { Name = "Boston Symphony Orchestra & Seiji Ozawa" },
                new Artist { Name = "Britten Sinfonia, Ivor Bolton & Lesley Garrett" },
                new Artist { Name = "Bruce Dickinson" },
                new Artist { Name = "Buddy Guy" },
                new Artist { Name = "Caetano Veloso" },
                new Artist { Name = "Cake" },
                new Artist { Name = "Calexico" },
                new Artist { Name = "Cássia Eller" },
                new Artist { Name = "Chic" },
                new Artist { Name = "Chicago Symphony Orchestra & Fritz Reiner" },
                new Artist { Name = "Chico Buarque" },
                new Artist { Name = "Chico Science & Nação Zumbi" },
                new Artist { Name = "Choir Of Westminster Abbey & Simon Preston" },
                new Artist { Name = "Chris Cornell" },
                new Artist { Name = "Christopher O'Riley" },
                new Artist { Name = "Cidade Negra" },
                new Artist { Name = "Cláudio Zoli" },
                new Artist { Name = "Creedence Clearwater Revival" },
                new Artist { Name = "David Coverdale" },
                new Artist { Name = "Deep Purple" },
                new Artist { Name = "Dennis Chambers" },
                new Artist { Name = "Djavan" },
                new Artist { Name = "Donna Summer" },
                new Artist { Name = "Dread Zeppelin" },
                new Artist { Name = "Ed Motta" },
                new Artist { Name = "Edo de Waart & San Francisco Symphony" },
                new Artist { Name = "Elis Regina" },
                new Artist { Name = "English Concert & Trevor Pinnock" },
                new Artist { Name = "Eric Clapton" },
                new Artist { Name = "Eugene Ormandy" },
                new Artist { Name = "Faith No More" },
                new Artist { Name = "Falamansa" },
                new Artist { Name = "Foo Fighters" },
                new Artist { Name = "Frank Zappa & Captain Beefheart" },
                new Artist { Name = "Fretwork" },
                new Artist { Name = "Funk Como Le Gusta" },
                new Artist { Name = "Gerald Moore" },
                new Artist { Name = "Gilberto Gil" },
                new Artist { Name = "Godsmack" },
                new Artist { Name = "Gonzaguinha" },
                new Artist { Name = "Göteborgs Symfoniker & Neeme Järvi" },
                new Artist { Name = "Guns N' Roses" },
                new Artist { Name = "Gustav Mahler" },
                new Artist { Name = "Incognito" },
                new Artist { Name = "Iron Maiden" },
                new Artist { Name = "James Levine" },
                new Artist { Name = "Jamiroquai" },
                new Artist { Name = "Jimi Hendrix" },
                new Artist { Name = "Joe Satriani" },
                new Artist { Name = "Jorge Ben" },
                new Artist { Name = "Jota Quest" },
                new Artist { Name = "Judas Priest" },
                new Artist { Name = "Julian Bream" },
                new Artist { Name = "Kent Nagano and Orchestre de l'Opéra de Lyon" },
                new Artist { Name = "Kiss" },
                new Artist { Name = "Led Zeppelin" },
                new Artist { Name = "Legião Urbana" },
                new Artist { Name = "Lenny Kravitz" },
                new Artist { Name = "Les Arts Florissants & William Christie" },
                new Artist { Name = "London Symphony Orchestra & Sir Charles Mackerras" },
                new Artist { Name = "Luciana Souza/Romero Lubambo" },
                new Artist { Name = "Lulu Santos" },
                new Artist { Name = "Marcos Valle" },
                new Artist { Name = "Marillion" },
                new Artist { Name = "Marisa Monte" },
                new Artist { Name = "Martin Roscoe" },
                new Artist { Name = "Maurizio Pollini" },
                new Artist { Name = "Mela Tenenbaum, Pro Musica Prague & Richard Kapp" },
                new Artist { Name = "Men At Work" },
                new Artist { Name = "重金属lica" },
                new Artist { Name = "Michael Tilson Thomas & San Francisco Symphony" },
                new Artist { Name = "Miles Davis" },
                new Artist { Name = "Milton Nascimento" },
                new Artist { Name = "Mötley Crüe" },
                new Artist { Name = "Motörhead" },
                new Artist { Name = "Nash Ensemble" },
                new Artist { Name = "Nicolaus Esterhazy Sinfonia" },
                new Artist { Name = "Nirvana" },
                new Artist { Name = "O Terço" },
                new Artist { Name = "Olodum" },
                new Artist { Name = "Orchestra of The Age of Enlightenment" },
                new Artist { Name = "Os Paralamas Do Sucesso" },
                new Artist { Name = "Ozzy Osbourne" },
                new Artist { Name = "Page & Plant" },
                new Artist { Name = "Paul D'Ianno" },
                new Artist { Name = "Pearl Jam" },
                new Artist { Name = "Pink Floyd" },
                new Artist { Name = "Queen" },
                new Artist { Name = "R.E.M." },
                new Artist { Name = "Raul Seixas" },
                new Artist { Name = "Red Hot Chili Peppers" },
                new Artist { Name = "Roger Norrington, London 古典 Players" },
                new Artist { Name = "Royal Philharmonic Orchestra & Sir Thomas Beecham" },
                new Artist { Name = "Rush" },
                new Artist { Name = "Santana" },
                new Artist { Name = "Scholars Baroque Ensemble" },
                new Artist { Name = "Scorpions" },
                new Artist { Name = "Sergei Prokofiev & Yuri Temirkanov" },
                new Artist { Name = "Sir Georg Solti & Wiener Philharmoniker" },
                new Artist { Name = "Skank" },
                new Artist { Name = "Soundgarden" },
                new Artist { Name = "Spyro Gyra" },
                new Artist { Name = "Stevie Ray Vaughan & Double Trouble" },
                new Artist { Name = "Stone Temple Pilots" },
                new Artist { Name = "System Of A Down" },
                new Artist { Name = "Temple of the Dog" },
                new Artist { Name = "Terry Bozzio, Tony Levin & Steve Stevens" },
                new Artist { Name = "The 12 Cellists of The Berlin Philharmonic" },
                new Artist { Name = "The Black Crowes" },
                new Artist { Name = "The Cult" },
                new Artist { Name = "The Doors" },
                new Artist { Name = "The King's Singers" },
                new Artist { Name = "The Police" },
                new Artist { Name = "The Posies" },
                new Artist { Name = "The Rolling Stones" },
                new Artist { Name = "The Who" },
                new Artist { Name = "Tim Maia" },
                new Artist { Name = "Ton Koopman" },
                new Artist { Name = "U2" },
                new Artist { Name = "UB40" },
                new Artist { Name = "Van Halen" },
                new Artist { Name = "Various Artists" },
                new Artist { Name = "Velvet Revolver" },
                new Artist { Name = "Vinícius De Moraes" },
                new Artist { Name = "Wilhelm Kempff" },
                new Artist { Name = "Yehudi Menuhin" },
                new Artist { Name = "Yo-Yo Ma" },
                new Artist { Name = "Zeca Pagodinho" }
            };
            foreach (var a in artists)
                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();

            //使用Lamda代替foreach
            new List<Album>
            {
                new Album
                {
                    Title = "The Best Of Men At Work", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "欢子"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "A Copland Celebration, Vol. I", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "欢子"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Worlds", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "欢子"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "For Those About To Rock We Salute You", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "欢子"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Let There Be 摇滚", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张学友"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Balls to the Wall", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张学友"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Restless and Wild", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "张学友"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Górecki: Symphony No. 3", Genre = genres.Single(g => g.Name == "古典"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "中岛美嘉"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Big Ones", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Chainsmokers"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Quiet Songs", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Chainsmokers"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Jagged Little Pill", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Chainsmokers"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Facelift", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "The Chainsmokers"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Frank", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "熊木杏里"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Ring My Bell", Genre = genres.Single(g => g.Name == "DISCO"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "熊木杏里"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Chill: Brazil (Disc 2)", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "熊木杏里"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Warner 25 Anos", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "熊木杏里"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Plays Metallica By Four Cellos", Genre = genres.Single(g => g.Name == "重金属"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "郑源"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Revelations", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "郑源"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Audioslave", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "郑源"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "The Last Night of the Proms", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "郑源"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
            }.ForEach(n => _dbContext.Albums.Add(n))};
            _dbContext.SaveChanges();
        }

        //给GenreId和ArtistId赋值
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