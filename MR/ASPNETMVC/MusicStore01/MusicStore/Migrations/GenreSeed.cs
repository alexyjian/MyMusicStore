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
                new Artist() {Name = "蔡健雅", Sex = false, Description = "代表作《红色高跟鞋》"},
                new Artist() {Name = "周杰伦", Sex = false, Description = "代表作《以父之名》"},
            };
            foreach (var a in artists)
                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();

            //使用Lamda代替foreach
            new List<Album>
            {
                new Album
                {
                    Title = "红色高跟鞋", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artists.Single(a => a.Name == "蔡健雅"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "叶惠美", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artists.Single(a => a.Name == "周杰伦"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
              
            }.ForEach(n => _dbContext.Albums.Add(n));
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