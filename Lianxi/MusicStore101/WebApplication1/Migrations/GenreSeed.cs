using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicStorEntity.Migrations
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
                new Genre() {Name="土嗨",Description="Rock" },
                 new Genre() {Name = "摇滚",Description = "Rock"},
                new Genre() {Name =  "爵士",Description = "Jazz"},
                new Genre() {Name =  "重金属",Description = "重金属"},
                new Genre() {Name =  "蓝调",Description = "Blue"},
                new Genre() {Name =  "拉丁",Description = "Latin"},
                new Genre() {Name =  "流行",Description = "Pop"},
                new Genre() {Name =  "古典",Description = "Classical"},
                new Genre() {Name =  "嘻哈",Description = "HiHop"},
            };
            foreach (var g in genres)
                _dbContext.Genres.Add(g);



            var artists = new List<Artist>()
            { new Artist() {Name = "蔡健雅", Sex = false, Description = "新加坡人，华语著名歌手、词曲作者，音乐制作人。1997年在新加坡由其经纪公司 Music & Movement 旗下的Yellow Music发行英语专辑《Bored》而正式出道，1999年将国语唱片签约于宝丽金唱片旗下，并推出首张国语同名专辑《蔡健雅》。2000年因宝丽金唱片并入环球唱片旗下，因此《记念》及之后的唱片皆由台湾环球唱片发行。在此一专辑中，蔡健雅以〈记念〉一曲成功打响在台湾市场的知名度。同年入围台湾第11届金曲奖最佳新人奖。2002年发行《Secret Lavender》专辑。同年以〈打错了〉作曲者身份入围台湾第13届金曲奖最佳作曲人奖，并同时入围最佳国语演唱人奖。2004年首度担任制作人，替梁咏琪制作《归属感》专辑。同年以《陌生人》获得台湾第15届金曲奖最佳国语女演唱人提名。2008年推出专辑《My Space》，同年获台湾第19届金曲奖7项提名，并获得了最佳专辑制作人和最佳国语女歌手两座大奖。近年移居台湾。2012年获最佳国语女歌手奖。代表作品：《呼吸》《陌生人》《空白格》《若你碰到他》《红色高跟鞋》。"},
             new Artist() {Name = "小小唐", Sex = false, Description = "中国著名土(｡･∀･)ﾉﾞ嗨歌手"},
             new Artist() {Name = "李荣浩", Sex = false, Description = "中国著名土(｡･∀･)ﾉﾞ嗨歌手"},
             new Artist() {Name = "周杰伦", Sex = false, Description = "中国著名土(｡･∀･)ﾉﾞ嗨歌手"},
             new Artist() {Name = "黄学明", Sex = false, Description = "中国著名土(｡･∀･)ﾉﾞ嗨歌手"},
             new Artist() {Name = "假死丁逼波", Sex = false, Description = "中国著名土(｡･∀･)ﾉﾞ嗨歌手"},
             new Artist() {Name = "迈克杰克逊", Sex = false, Description = "中国著名土(｡･∀･)ﾉﾞ嗨歌手"},
             new Artist() {Name = "艾薇儿", Sex = false, Description = "中国著名土(｡･∀･)ﾉﾞ嗨歌手"},
             new Artist() {Name = "林俊杰", Sex = false, Description = "中国著名土(｡･∀･)ﾉﾞ嗨歌手"},
             new Artist() {Name = "蔡依林", Sex = false, Description = "中国著名土(｡･∀･)ﾉﾞ嗨歌手"},
              new Artist() {Name = "崔健", Sex = false, Description = "摇滚歌手"},
            };

            foreach (var a in artists)
                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();

            //使用Lamda代替foreach
            new List<Album>
            {
            new Album
            {
                Title = "Bark at the Moon (Remastered)",
                Genre = genres.Single(g => g.Name == "重金属"),
                Price = 8.99M,
                Artist = artists.Single(a => a.Name == "蔡健雅"),
                AlbumArtUrl = "/Content/Images/placeholder.gif"


                },
               new Album
            {
                Title = "Bark at the Moon (Remastered)",
                Genre = genres.Single(g => g.Name == "爵士"),
                Price = 8.59M,
                Artist = artists.Single(a => a.Name == "小小唐"),
                AlbumArtUrl = "/Content/Images/placeholder.gif"


                },
                 new Album
                 {
                Title = "Bark at the Moon (Remastered)",
                Genre = genres.Single(g => g.Name == "嘻哈"),
                Price = 8.59M,
                Artist = artists.Single(a => a.Name == "李荣浩"),
                AlbumArtUrl = "/Content/Images/placeholder.gif"


                },
                   new Album
                   {
                Title = "Bark at the Moon (Remastered)",
                Genre = genres.Single(g => g.Name == "古典"),
                Price = 8.59M,
                Artist = artists.Single(a => a.Name == "周杰伦"),
                AlbumArtUrl = "/Content/Images/placeholder.gif"


                },
                     new Album
                     {
                Title = "Bark at the Moon (Remastered)",
                Genre = genres.Single(g => g.Name == "蓝调"),
                Price = 8.59M,
                Artist = artists.Single(a => a.Name == "黄学明"),
                AlbumArtUrl = "/Content/Images/placeholder.gif"


                },
                       new Album
                     {
                Title = "Bark at the Moon (Remastered)",
                Genre = genres.Single(g => g.Name == "摇滚"),
                Price = 8.59M,
                Artist = artists.Single(a => a.Name == "崔健"),
                AlbumArtUrl = "/Content/Images/placeholder.gif"


                },
                       new Album
                       {
                Title = "Bark at the Moon (Remastered)",
                Genre = genres.Single(g => g.Name == "流行"),
                Price = 8.59M,
                Artist = artists.Single(a => a.Name == "蔡依林"),
                AlbumArtUrl = "/Content/Images/placeholder.gif"


                },
                         new Album
                         {
                Title = "Bark at the Moon (Remastered)",
                Genre = genres.Single(g => g.Name == "土嗨"),
                Price = 8.59M,
                Artist = artists.Single(a => a.Name == "假死丁逼波"),
                AlbumArtUrl = "/Content/Images/placeholder.gif"


                },
                           new Album
                           {
                Title = "Bark at the Moon (Remastered)",
                Genre = genres.Single(g => g.Name == "土嗨"),
                Price = 8.59M,
                Artist = artists.Single(a => a.Name == "艾薇儿"),
                AlbumArtUrl = "/Content/Images/placeholder.gif"


                },
                             new Album
                             {
                Title = "Bark at the Moon (Remastered)",
                Genre = genres.Single(g => g.Name == "拉丁"),
                Price = 8.59M,
                Artist = artists.Single(a => a.Name == "林俊杰"),
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
