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
            _dbContext.Database.ExecuteSqlCommand("delete genres");
            _dbContext.Database.ExecuteSqlCommand("delete albums");
            _dbContext.Database.ExecuteSqlCommand("delete artists");


            var genres = new List<Genre>()
            {
                new Genre() { Name="摇滚",Description="Rock"},
                new Genre() { Name="快乐",Description="kl"},
                new Genre() { Name="高兴",Description="gx"},
                new Genre() { Name="兴奋",Description="xf"}
            };
            foreach (var g in genres)

                _dbContext.Genres.Add(g);

            var artists = new List<Artist>
                {
                    new Artist() { Name="华晨宇",Description="华晨宇，1990年2月7日生于湖北十堰 ，中国男歌手，毕业于武汉音乐学院。 2013年，参加湖南卫视《快乐男声》获年度总冠军出道 。2014年1月，首登央视春晚舞台。9月6日-7日，在北京万事达中心连开两场“火星”演唱会 ，随后首张个人专辑《卡西莫多的礼物》发行 ，并凭此专辑获第十五届音乐风云榜年度最受欢迎男歌手等奖项。同年7月31日—8月2日，2015火星演唱会在上海大舞台连开三场。12月，发行第二张专辑《异类》。 2016年7-9月，2016火星演唱会相继在北上深三个城市举办。9月27日，出席亚洲新歌榜2016年度盛典，揽获最佳男歌手奖。10月，加盟东方卫视《天籁之战》。12月2日，获2016MAMA亚洲最佳艺人奖。2017年3月14日，专辑《H》发行",Sex=true },
                    new Artist() { Name="老狼",Description="中国大陆男歌手，音乐人。于1968年出生于音乐世家，从小就耳濡目染。1989年-1991年 加入中国第一支大学生摇滚乐队“青铜器”担任主唱。1991年—1991大地唱片公司唱片《校园民谣1》的录制，演唱《同桌的你》、《睡在我上铺的兄弟》及《流浪歌手的情人》三首主打歌。1994—1997年 《校园民谣1》发行近六十万张，签约风行音乐工作室。首张个人专辑《恋恋风尘》，专辑发行20天便创下了23万的销售记录，共发行40万张，成为当年中国国内歌手发行量最高的专辑。2000年2月 与华纳唱片签订唱片约，并与“麦田音乐”签订演艺合约。代表作品：《同桌的你》，《恋恋风尘》，《睡在我上铺的兄弟》",Sex=true },
                    new Artist() { Name="洪启",Description="中国大陆男歌手，音乐人。",Sex=true },
                    new Artist() { Name="张学友",Description="中国大陆男歌手，音乐人。",Sex=true },
                    new Artist() { Name="李佳隆",Description="中国大陆男歌手，音乐人。",Sex=true },
                    new Artist() { Name="毛不易",Description="中国大陆男歌手，音乐人。",Sex=true },
                    new Artist() { Name="徐秉龙",Description="中国大陆男歌手，音乐人。",Sex=true },
                    new Artist() { Name="张杰",Description="中国大陆男歌手，音乐人。",Sex=true },
                    new Artist() { Name="王北车",Description="中国大陆男歌手，音乐人。",Sex=true },
                    new Artist() { Name="嘻嘻",Description="中国大陆男歌手，音乐人。",Sex=true }



                };




            foreach (var a in artists)

                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();

            var albums = new List<Album>
                {
                    new Album{Title="xx", Genre=genres.Single(g =>g.Name =="快乐"),Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="qq", Genre=genres.Single(g =>g.Name =="快乐") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="ww", Genre=genres.Single(g =>g.Name =="快乐") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="ee", Genre=genres.Single(g =>g.Name =="快乐") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="rr", Genre=genres.Single(g =>g.Name =="高兴") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="嘻嘻"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="hh", Genre=genres.Single(g =>g.Name =="兴奋") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="嘻嘻"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="xx", Genre=genres.Single(g =>g.Name =="摇滚") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="嘻嘻"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="cc", Genre=genres.Single(g =>g.Name =="快乐") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="嘻嘻"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="das ", Genre=genres.Single(g =>g.Name =="高兴") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="嘻嘻"),AlbumArtUrl="/Content/Images/placeholder.gif" }
                    ,new Album{Title="asd", Genre=genres.Single(g =>g.Name =="兴奋") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="xad", Genre=genres.Single(g =>g.Name =="快乐") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="xsd", Genre=genres.Single(g =>g.Name =="高兴") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="xgf", Genre=genres.Single(g =>g.Name =="兴奋") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="gh", Genre=genres.Single(g =>g.Name =="快乐") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="hh", Genre=genres.Single(g =>g.Name =="高兴") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="sf", Genre=genres.Single(g =>g.Name =="兴奋") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="sf", Genre=genres.Single(g =>g.Name =="摇滚") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="sdf", Genre=genres.Single(g =>g.Name =="快乐") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="xsf", Genre=genres.Single(g =>g.Name =="高兴") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="jf", Genre=genres.Single(g =>g.Name =="兴奋") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="fgh", Genre=genres.Single(g =>g.Name =="快乐") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="xddg", Genre=genres.Single(g =>g.Name =="高兴") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                    new Album{Title="xdg", Genre=genres.Single(g =>g.Name =="摇滚") ,Price=9.99M,Artist=artists.Single(a=>a.Name=="华晨宇"),AlbumArtUrl="/Content/Images/placeholder.gif" }

                };
            foreach (var c in albums)

                _dbContext.Albums.Add(c);
            _dbContext.SaveChanges();

        }

        public static void Extend()
        {
            var albums = _dbContext.Albums.ToList();
            foreach (var album in albums)
            {
                var item = _dbContext.Albums.Find(album.ID);
                item.GenreId = item.Genre.ID.ToString();
                item.ArtisId = item.Artist.ID.ToString();
                _dbContext.SaveChanges();
                Thread.Sleep(3);
            }
        }
    }
}