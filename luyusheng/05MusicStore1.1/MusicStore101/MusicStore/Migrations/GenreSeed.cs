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

            var artists = new List<Artist>()
            {
                new Artist() {Name ="",Sex =false,Description =""},
                new Artist() {Name ="",Sex =false,Description =""},
                new Artist() {Name ="",Sex =false,Description =""},
                new Artist() {Name ="",Sex =false,Description =""},
                new Artist() {Name ="",Sex =true,Description =""},
                new Artist() {Name ="",Sex =true,Description =""},
                new Artist() {Name ="",Sex =false,Description =""},
                new Artist() {Name ="",Sex =false,Description =""},
                new Artist() {Name ="",Sex =false,Description =""},
                new Artist() {Name ="",Sex =true,Description =""},
                new Artist() {Name ="",Sex =true,Description =""},
                new Artist() {Name ="",Sex =true,Description =""},
                new Artist() {Name ="",Sex =false,Description =""},
                new Artist() {Name ="",Sex =true,Description =""},
                new Artist() {Name ="",Sex =true,Description =""},
                new Artist() {Name ="",Sex =false,Description =""},
                new Artist() {Name ="",Sex =true,Description =""},
                new Artist() {Name ="",Sex =true,Description =""},
                new Artist() {Name ="",Sex =false,Description =""},
                new Artist() {Name ="",Sex =true,Description =""},
            };

            var albums = new List<Album>
            {
                 new Artist() {Title ="The Best Of Men At Work",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="The Best Rages On ",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="The Final Concerts(Disc 2)",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="Outbreak",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="周杰伦 Ao Vivo -Vol.02",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="周杰伦 Ao Vivo -Vol.01",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="MacArthu Park Suite",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="Un-Led-Ed",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="The Best Of Ed Motta",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="Adams,John:The Chairman Dances",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="Elis Regina-Minha Historia",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="Pachelbel:Canon & Gigue",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="Unplugged",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="The Cream Of Clapton",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="Unplugged",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="Respighi:Pines of Rome",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="Strauss:Waltzes",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="King For A Day Fool For A Lifetime",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="Deixa Entrar",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="In Your Honor [Disc 1]",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
                 new Artist() {Title ="In Your Honor [Disc 1]",Genre =genres.Single(g =>g.Name =="Rock"),Price =8.99M,Artist =artists.Single(a=>a.Name ==""),AlbumArtUrl="/Contem"},
            };
            _dbContext.SaveChanges();
        }
    }
}