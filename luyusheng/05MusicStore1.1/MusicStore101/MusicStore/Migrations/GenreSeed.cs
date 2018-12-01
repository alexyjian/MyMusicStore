using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
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
            new Genre() { Name = "DJ" ,Description ="DJ"},
            new Genre() { Name = "流行" ,Description ="Pop"},
            new Genre() { Name = "青春" ,Description ="HiHop"},
        };
            foreach (var g in genres)
                _dbContext.Genres.Add(g);
            _dbContext.SaveChanges();
            var artists = new List<Artist>()
            {
                new Artist() {Name ="蔡健雅",Sex =false,Description ="新加坡人，华语著名歌手、词曲作者，音乐制作人。1997年在新加坡由其经纪公司"},
                new Artist() {Name ="张惠妹",Sex =false,Description ="中国台湾著名女歌手，亚洲流行歌坛重量级天后，台湾原住民歌手。张惠妹于华"},
                new Artist() {Name ="王以太",Sex =false,Description =""},
                new Artist() {Name ="The chainsmokers",Sex =false,Description =""},
                new Artist() {Name ="徐秉龙",Sex =true,Description =""},
                new Artist() {Name ="毛不易",Sex =true,Description =""},
                new Artist() {Name ="赵丽颖",Sex =false,Description =""},
                new Artist() {Name ="谭松韵",Sex =false,Description =""},
                new Artist() {Name ="许 ",Sex =false,Description =""},
                new Artist() {Name ="王力宏",Sex =true,Description =""},
                new Artist() {Name ="张学友",Sex =true,Description =""},
                new Artist() {Name ="Coldplay",Sex =true,Description =""},
                new Artist() {Name ="莫文蔚",Sex =false,Description =""},
                new Artist() {Name ="Justin Bieber",Sex =true,Description =""},
                new Artist() {Name ="王菲",Sex =true,Description =""},
                new Artist() {Name ="张震岳",Sex =false,Description =""},
                new Artist() {Name ="胡彦斌",Sex =true,Description =""},
                new Artist() {Name ="S.H.E",Sex =true,Description =""},
                new Artist() {Name ="张国荣",Sex =false,Description =""},
                new Artist() {Name ="周杰伦",Sex =true,Description =""},
                new Artist {Name ="Aaron Copland & London Symphony Orchestra",Sex =true,Description =""},
                new Artist {Name ="Aaron Goldberg",Sex =true,Description =""},
                new Artist {Name ="AC/DC",Sex =true,Description =""},
                new Artist {Name ="Accept",Sex =true,Description =""},
                new Artist {Name ="Adrian Leaper & Doreen de Feis",Sex =true,Description =""},
                new Artist {Name ="Aerosmith",Sex =true,Description =""},
                new Artist {Name ="Aisha Duo",Sex =true,Description =""},
                new Artist {Name ="Alanis Morissette",Sex =true,Description =""},
                new Artist {Name ="Alberto Turco & Noco Schola Gregoriana",Sex =true,Description =""},
                new Artist {Name ="Alice In Chains",Sex =true,Description =""},
                new Artist {Name ="Amy Winehouse",Sex =true,Description =""},
                new Artist {Name ="Anita Ward",Sex =true,Description =""},
                new Artist {Name ="Antonio Carlos Jobim",Sex =true,Description =""},
                new Artist {Name ="Apocalyptica",Sex =true,Description =""},
                new Artist {Name ="Audioslave",Sex =true,Description =""},
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
                new Artist {Name ="Cake"},
                new Artist {Name ="Calexico"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},
                new Artist {Name ="Cake"},

            };
            _dbContext.SaveChanges();

            //var albums = new List<Album>
            ////{
            //     new Artist() {Title ="The Best Of Men At Work",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="The Best Rages On ",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="The Final Concerts(Disc 2)",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="Outbreak",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="周杰伦 Ao Vivo -Vol.02",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="周杰伦 Ao Vivo -Vol.01",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="MacArthu Park Suite",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="Un-Led-Ed",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="The Best Of Ed Motta",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="Adams,John:The Chairman Dances",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="Elis Regina-Minha Historia",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="Pachelbel:Canon & Gigue",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="Unplugged",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="The Cream Of Clapton",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="Unplugged",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="Respighi:Pines of Rome",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="Strauss:Waltzes",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="King For A Day Fool For A Lifetime",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="Deixa Entrar",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="In Your Honor [Disc 1]",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //     new Artist() {Title ="In Your Honor [Disc 1]",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            //};

        }
    }
}