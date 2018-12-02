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
            new Genre() { Name = "摇滚",Description ="Rock" },
            new Genre() { Name = "爵士" ,Description ="Jazz"},
            new Genre() { Name = "伤感" ,Description ="ShKa"},
            new Genre() { Name = "慢摇",Description ="DownTempo" },
            new Genre() { Name = "抖音",Description ="Yidou" },
            new Genre() { Name = "火山视频" ,Description ="HoShan"},
            new Genre() { Name = "古风" ,Description ="Classical"},
            new Genre() { Name = "DISCO" ,Description ="DISCO"},
            new Genre() { Name = "流行" ,Description ="Pop"},
            new Genre() { Name = "青春" ,Description ="HiHop"},
        };
            foreach (var g in genres)
                _dbContext.Genres.Add(g);

            var artists = new List<Artist>()
            {
                new Artist() {Name ="蔡健雅",Sex =false,Description ="新加坡人，华语著名歌手、词曲作者，音乐制作人。1997年在新加坡由其经纪公司"},
                new Artist() {Name ="张惠妹",Sex =false,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="王以太",Sex =false,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="苏有朋",Sex =false,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="徐秉龙",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="毛不易",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="赵丽颖",Sex =false,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="谭松韵",Sex =false,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="吴秀波 ",Sex =false,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="王力宏",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="张学友",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="Coldplay",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="莫文蔚",Sex =false,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="Justin Bieber",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="王菲",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="张震岳",Sex =false,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="胡彦斌",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="S.H.E",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="张国荣",Sex =false,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist() {Name ="周杰伦",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Aaron Copland & London Symphony Orchestra",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Aaron Goldberg",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="AC/DC",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Accept",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Adrian Leaper & Doreen de Feis",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Aerosmith",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Aisha Duo",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Alanis Morissette",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Alberto Turco & Noco Schola Gregoriana",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Alice In Chains",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Amy Winehouse",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Anita Ward",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Antonio Carlos Jobim",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Apocalyptica",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Audioslave",Sex =true,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华人世界名气极高,于海外(尤美、日等地)也有一定的知名度,已多项华语圈重要的音乐奖项。也是台湾首位接受美国CNN专访的歌手"},
                new Artist {Name ="Barry Wordsworth & BBC Concert Orchestra"},
                new Artist {Name ="Berliner Philharmoniker & Hans Rosbaud"},
                new Artist {Name ="Berliner Philharmoniker & Herbert Von Karajan"},
                new Artist {Name ="Billy Cobham"},
                new Artist {Name ="Black Label Society"},
                new Artist {Name ="Black Sabbath"},
                new Artist {Name ="Boston Symphony Orchestra & Seiji Ozawa"},
                new Artist {Name ="Britten Sinfonia,Ivor Bolton & Lesley Garrett"},
                new Artist {Name ="Bruce Dickinson"},
                new Artist {Name ="Buddy Guy"},
                new Artist {Name ="Caetano Veloso"},
                new Artist {Name ="Roger Norrington,London 古风 Players"},
                new Artist {Name ="Royal Philharmonic Orchestra & Sir Thomas Beecham"},
                new Artist {Name ="Calexico"},
                new Artist {Name ="The 12 Cellists of The Berlin Philharmonic"},
                new Artist {Name ="The Cult"},
                new Artist {Name ="The Black Crowes"},
                new Artist {Name ="The Cult"},
                new Artist {Name ="The Doors"},
                new Artist {Name ="The King's Singers"},
                new Artist {Name ="The Police"},
                new Artist {Name ="The Police"},
                new Artist {Name ="The Rolling Stones"},
                new Artist {Name ="The Who"},
                new Artist {Name ="Tim Maia"},
                new Artist {Name ="Ton Koopman"},
                new Artist {Name ="U2"},
                new Artist {Name ="UB40"},
                new Artist {Name ="Van Halen"},
                new Artist {Name ="Various Artists"},
                new Artist {Name ="Velvet Revolver"},
                new Artist {Name ="Vinicius De Moraes"},
                new Artist {Name ="Yehudi Mempff"},
                new Artist {Name ="Yo-Yo Ma"},
                new Artist {Name ="Zeca Pagodinho"},

            };
            foreach (var a in artists)
                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();

            //使用Lamda代替foreach
            new List<Album>
            {
                 new Album
                 { Title = "The Best Of Men At Work",Genre = genres.Single(g =>g.Name == "摇滚"),Price = 8.99M,
                   Artist = artists.Single(a => a.Name == "蔡健雅"),
                   AlbumArtUrl = "/Content/Images/placeholder.gif"},

                 new Album {Title = "A Copland Celebration,Vol.1",Genre =genres.Single(g =>g.Name =="爵士"),Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "张惠妹"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif"},

                 new Album { Title = "Worlds",Genre = genres.Single(g =>g.Name == "爵士"),Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "王以太"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif" },

                 new Album {Title = "For Those About To Rock We Salute You",Genre =genres.Single(g =>g.Name == "青春"),Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "苏有朋"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif" },

                 new Album { Title = "Let There Be Rock ", Genre = genres.Single(g =>g.Name == "摇滚"),Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "徐秉龙"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif" },

                 new Album { Title = "Bslls to the Wall",Genre = genres.Single(g =>g.Name == "抖音"),Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "毛不易"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif" },

                 new Album { Title = "Restless and Wild",Genre = genres.Single(g =>g.Name == "古风"),Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "赵丽颖"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif" },

                 new Album { Title = "Gorecki Symphony No.3",Genre = genres.Single(g => g.Name == "青春"), Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "谭松韵"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif" },



                 new Album { Title = "Quiet Songs",Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "王力宏"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif"},

                 new Album { Title = "Jagged Little Pill", Genre = genres.Single(g => g.Name == "青春"), Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "张学友"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif"},

                 new Album { Title = "Facelift",Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "Coldplay"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif"},

                 new Album { Title = "Warner 25 Anos", Genre = genres.Single(g => g.Name == "爵士"), Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "张震岳"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif" },

                 new Album { Title = "Plays Metallica By Four Cllos",Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "胡彦斌"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif" },

                 new Album { Title = "Revelations",Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "张国荣"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif"},

                 new Album { Title = "Audioslave",Genre = genres.Single(g => g.Name == "古风"), Price = 8.99M,
                     Artist = artists.Single(a => a.Name == "周杰伦"),
                     AlbumArtUrl = "/Content/Images/placeholder.gif"},

            }.ForEach(n => _dbContext.Albums.Add(n));
             _dbContext.SaveChanges();
        }

        //给GenreId和AristId赋值
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