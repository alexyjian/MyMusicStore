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
        public static readonly MusicStoreEntity.MusicContext _dbContext = new MusicStoreEntity.MusicContext();

        public static void Seed()
        {
            _dbContext.Database.ExecuteSqlCommand("delete ablums");
            _dbContext.Database.ExecuteSqlCommand("delete artists");
            _dbContext.Database.ExecuteSqlCommand("delete genres");
            var genres = new List<Genre>()
            {
                new Genre() {Name="古典",Description="Classical" },
                new Genre() {Name="摇滚",Description="Rock" },
                new Genre() {Name="蓝调",Description="Blues" },
                new Genre() {Name="流行",Description="Popular" },
                new Genre() {Name="慢摇",Description="Slow wave" },
                new Genre() {Name="爵士",Description="Sir" },
                new Genre() {Name="拉丁",Description="Latin" },
                new Genre() {Name="DJ",Description="DJ" },
                new Genre() {Name="嘻哈",Description="HipHop" },
            };

            foreach (var g in genres)
                _dbContext.Genres.Add(g);

            var artists = new List<Artist>()
            {
                new Artist() {Name = "张学友", Sex = true, Description = ""},
                new Artist() {Name = "周杰伦", Sex = true, Description = ""},
                new Artist() {Name = "张杰", Sex = true, Description = ""},
                new Artist() {Name = "那英", Sex = false, Description = ""},
                new Artist() {Name = "李宇春", Sex = false, Description = ""},
                new Artist() {Name = "Taylor Swift", Sex = false, Description = ""}
            };
            foreach (var a in artists)
                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();

            //使用lamda代替foreach
            new List<Ablum>
            {
                new Ablum
                {
                    Title = "吻别", Genre = genres.Single(g => g.Name == "流行"), Price = 10M,
                    Artist = artists.Single(a => a.Name == "张学友"), AlbumArtUrl = "/Content/Images/35.jpg"
                },
                new Ablum
                {
                    Title = "好久不见", Genre = genres.Single(g => g.Name == "流行"), Price = 10M,
                    Artist = artists.Single(a => a.Name == "张学友"), AlbumArtUrl = "/Content/Images/35.jpg"
                },
                new Ablum
                {
                    Title = "如果这不算爱", Genre = genres.Single(g => g.Name == "古典"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "张学友"), AlbumArtUrl = "/Content/Images/35.jpg"
                },
                new Ablum
                {
                    Title = "不爱我就拉倒", Genre = genres.Single(g => g.Name == "摇滚"), Price = 30M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/36.jpg"
                },
                new Ablum
                {
                    Title = "等你下课", Genre = genres.Single(g => g.Name == "摇滚"), Price = 26M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/36.jpg"
                },
                new Ablum
                {
                    Title = "给我一首歌的时间", Genre = genres.Single(g => g.Name == "流行"), Price = 15M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/36.jpg"
                },
                new Ablum
                {
                    Title = "不能说的秘密", Genre = genres.Single(g => g.Name == "流行"), Price = 35M,
                    Artist = artists.Single(a => a.Name == "周杰伦"), AlbumArtUrl = "/Content/Images/36.jpg"
                },
                new Ablum
                {
                    Title = "这就是爱", Genre = genres.Single(g => g.Name == "蓝调"), Price = 18M,
                    Artist = artists.Single(a => a.Name == "张杰"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Ablum
                {
                    Title = "爱不解释", Genre = genres.Single(g => g.Name == "蓝调"), Price = 20M,
                    Artist = artists.Single(a => a.Name == "张杰"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Ablum
                {
                    Title = "一路之下", Genre = genres.Single(g => g.Name == "古典"), Price = 30M,
                    Artist = artists.Single(a => a.Name == "张杰"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Ablum
                {
                    Title = "只要平凡", Genre = genres.Single(g => g.Name == "流行"), Price = 26M,
                    Artist = artists.Single(a => a.Name == "张杰"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Ablum
                {
                    Title = "不想想你", Genre = genres.Single(g => g.Name == "古典"), Price = 16M,
                    Artist = artists.Single(a => a.Name == "张杰"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Ablum
                {
                    Title = "Precious", Genre = genres.Single(g => g.Name == "流行"), Price = 10M,
                    Artist = artists.Single(a => a.Name == "张杰"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Ablum
                {
                    Title = "Precious", Genre = genres.Single(g => g.Name == "慢摇"), Price = 30M,
                    Artist = artists.Single(a => a.Name == "张杰"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Ablum
                {
                    Title = "默", Genre = genres.Single(g => g.Name == "慢摇"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "那英"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Ablum
                {
                    Title = "相爱恨早", Genre = genres.Single(g => g.Name == "拉丁"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "那英"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Ablum
                {
                    Title = "一笑而过", Genre = genres.Single(g => g.Name == "慢摇"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "那英"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Ablum
                {
                    Title = "那又怎样", Genre = genres.Single(g => g.Name == "慢摇"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "那英"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Ablum
                {
                    Title = "相见不如怀念", Genre = genres.Single(g => g.Name == "慢摇"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "那英"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Ablum
                {
                    Title = "和你一样", Genre = genres.Single(g => g.Name == "DJ"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "李宇春"), AlbumArtUrl = "/Content/Images/33.jpg"
                },
                new Ablum
                {
                    Title = "动物世界", Genre = genres.Single(g => g.Name == "DJ"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "李宇春"), AlbumArtUrl = "/Content/Images/33.jpg"
                },
                new Ablum
                {
                    Title = "野蛮生长", Genre = genres.Single(g => g.Name == "DJ"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "李宇春"), AlbumArtUrl = "/Content/Images/33.jpg"
                },
                new Ablum
                {
                    Title = "无花果", Genre = genres.Single(g => g.Name == "DJ"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "李宇春"), AlbumArtUrl = "/Content/Images/33.jpg"
                },
                new Ablum
                {
                    Title = "1987我不知会遇见你", Genre = genres.Single(g => g.Name == "DJ"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "李宇春"), AlbumArtUrl = "/Content/Images/33.jpg"
                },
                new Ablum
                {
                    Title = "Shake It Off", Genre = genres.Single(g => g.Name == "蓝调"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "Taylor Swift"), AlbumArtUrl = "/Content/Images/66.jpg"
                },
                new Ablum
                {
                    Title = "Red", Genre = genres.Single(g => g.Name == "蓝调"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "Taylor Swift"), AlbumArtUrl = "/Content/Images/66.jpg"
                },
                new Ablum
                {
                    Title = "Delicate", Genre = genres.Single(g => g.Name == "蓝调"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "Taylor Swift"), AlbumArtUrl = "/Content/Images/66.jpg"
                },
                new Ablum
                {
                    Title = "Del", Genre = genres.Single(g => g.Name == "蓝调"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "Taylor Swift"), AlbumArtUrl = "/Content/Images/66.jpg"
                },
                new Ablum
                {
                    Title = "licate", Genre = genres.Single(g => g.Name == "蓝调"), Price = 25M,
                    Artist = artists.Single(a => a.Name == "Taylor Swift"), AlbumArtUrl = "/Content/Images/66.jpg"
                },

            }.ForEach(n => _dbContext.Ablums.Add(n));
               
            _dbContext.SaveChanges();
        }

        //给GenreId和Ablums赋值
        public static void Extend()
        {
            //把所有专辑查出来
            var albums = _dbContext.Ablums.ToList();
            foreach (var album in albums)
            {
                var item = _dbContext.Ablums.Find(album.ID);
                item.GenreId = item.Genre.ID.ToString();
                item.ArtistId = item.Artist.ID.ToString();
                _dbContext.SaveChanges();
                Thread.Sleep(3);
            }
        }

    }
}