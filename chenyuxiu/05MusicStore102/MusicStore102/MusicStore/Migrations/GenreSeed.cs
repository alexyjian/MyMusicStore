using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;

namespace MusicStore.Migrations
{
    public class GenreSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();
        private static MusicStoreEntity.Genre a;

        public static void Seed()
        {
            _dbContext.Database.ExecuteSqlCommand("delete albums");
            _dbContext.Database.ExecuteSqlCommand("delete artists");
            _dbContext.Database.ExecuteSqlCommand("delete genres");
            var genres = new List<Genre>()
            {
                new Genre () {Name="摇滚",Description="Rock"},
                 new Genre () {Name="爵士",Description="Jazz"},
                  new Genre () {Name="黄金属",Description="Metal"},
                   new Genre () {Name="蓝调",Description="DownTempo"},
                    new Genre () {Name="拉丁",Description="Blue"},
                     new Genre () {Name="流行",Description="Pop"},
                      new Genre () {Name="古典",Description="Classical"},
                      new Genre () {Name="DJ",Description="DJ"},
                      new Genre () {Name="嘻哈",Description="HiHop"},
            };
            foreach (var g in genres)
                _dbContext.Genres.Add(g);

            var artits = new List<Artist>()
        {
new Artist(){Name ="黄子涛",Sex=false,Description="中国青岛男演员 中国男歌手、演员。2010年，参加MBC《伟大的诞生》海选比赛 ，现场被SM公司星探相中签约并成为其旗下练习生"},
new Artist(){Name ="黄轩",Sex=false,Description="中国青岛男演员 出生于甘肃兰州，毕业于北京舞蹈学院音乐剧系，中国影视剧演员。"},
new Artist(){Name ="杨幂",Sex=false,Description="中国青岛男演员 出生于北京市，中国内地影视女演员、流行乐歌手、影视制片人。"},
new Artist(){Name ="罗志祥",Sex=false,Description="出生于台湾省基隆市，中国台湾男歌手、主持人、舞者、演员。"},
new Artist(){Name ="林志颖",Sex=false,Description="中国青岛男演员 出生于台湾，毕业于台北市华冈艺术学校，中国台湾男演员、歌手、赛车手。发表多张唱片并出演多部影视剧作品，"},
new Artist(){Name ="乔任梁",Sex=false,Description="中国青岛男演员 出生于上海市，中国内地影视男演员、流行乐歌手，毕业于上海电机学院"},
new Artist(){Name ="马天宇",Sex=false,Description="中国青岛男演员  出生于山东省德州武城县，2009年毕业于北京电影学院，"},
new Artist(){Name ="李易峰",Sex=false,Description="中国青岛男演员 流行乐歌手、影视制片人，毕业于四川师范大学电影电视学院。"},
new Artist(){Name ="周冬雨",Sex=false,Description="中国青岛男演员 出生于河北省石家庄市，毕业于北京电影学院2011级本科班，中国内地影视女演员。"},
new Artist(){Name ="杨洋",Sex=false,Description="中国青岛男演员 中国内地男演员，1991年9月9日出生于上海，籍贯安徽合肥，毕业于中国人民解放军艺术学院2003级舞蹈系。"},
new Artist(){Name ="陈翔",Sex=false,Description="中国青岛男演员 出生于甘肃天水，中国歌手、影视演员。"},
new Artist(){Name ="邓紫棋",Sex=false,Description="中国青岛男演员 生于中国上海，4岁移居香港，中国香港创作型女歌手。"},

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
        };
            foreach (var a in artits) ;
            _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();

            //使用Lamda代替foreach
            new List<Album>
            {
           new Album
                {
                    Title = "The Best Of Men At Work", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artits.Single(a => a.Name == "黄子涛"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "A Copland Celebration, Vol. I", Genre = genres.Single(g => g.Name == "古典"),
                    Price = 8.99M, Artist = artits.Single(a => a.Name == "黄子涛"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Worlds", Genre = genres.Single(g =>g.Name == "爵士"), Price = 8.99M,
                    Artist = artits.Single(a => a.Name == "黄子涛"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "For Those About To Rock We Salute You", Genre = genres.Single(g => g.Name == "摇滚"),
                    Price = 8.99M, Artist = artits.Single(a => a.Name == "黄子涛"),
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "黄轩 III", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artits.Single(a => a.Name == "黄轩"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "黄轩", Genre = genres.Single(g => g.Name == "摇滚"), Price = 8.99M,
                    Artist = artits.Single(a => a.Name == "毛不易"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Axé Bahia 2001", Genre = genres.Single(g => g.Name == "流行"), Price = 8.99M,
                    Artist = artits.Single(a => a.Name == "黄轩"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Sambas De Enredo 2001", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artits.Single(a => a.Name == "黄轩"), AlbumArtUrl = "/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title = "Vozes do MPB", Genre = genres.Single(g => g.Name == "拉丁"), Price = 8.99M,
                    Artist = artits.Single(a => a.Name == "黄轩"), AlbumArtUrl = "/Content/Images/placeholder.gif"
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