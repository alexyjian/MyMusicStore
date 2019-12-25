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
        private static readonly MusicStoreEntity.MusicContext dbContext = new MusicStoreEntity.MusicContext();

        public static void Seed()
        {
            dbContext.Database.ExecuteSqlCommand("delete genres");
            dbContext.Database.ExecuteSqlCommand("delete artists");
            dbContext.Database.ExecuteSqlCommand("delete genres");
            var genres=new List<Genre>()
            {
            new Genre() { Name = "DJ",Description="DJ" },
             new Genre() { Name = "慢摇",Description="DownTempo" },
             new Genre() { Name = "重金属",Description="Metal" },
             new Genre() { Name = "嘻哈",Description="HiHop" },
             new Genre() { Name = "蓝调" ,Description="Blue"},
             new Genre() { Name = "拉丁" ,Description="Latin"},
             new Genre() { Name = "流行" ,Description="Pop"},
             new Genre() { Name = "古典" ,Description="Classical"},
             new Genre() { Name = "摇滚",Description="Rook" },
             new Genre() { Name = "爵士",Description="Jazz" }
        };
            foreach (var g in genres)
                dbContext.Genres.Add(g);
            dbContext.SaveChanges();
            var artists = new List<Artist>()
            {
                new Artist() { Name="张杰",Sex=true,Description="中国著名男歌手"},
                new Artist() { Name="林俊杰",Sex=true,Description="中国著名男歌手"},
                new Artist() { Name="周杰伦",Sex=true,Description="中国著名男歌手"},
                new Artist() { Name="张学友",Sex=true,Description="中国著名男歌手"},
                new Artist() { Name="胡歌",Sex=true,Description="中国著名男歌手"},
                new Artist() { Name="许嵩",Sex=true,Description="中国著名男歌手"},
                new Artist() { Name="双笙",Sex=false,Description="中国著名网络女歌手"},
                new Artist() { Name="汪苏泷",Sex=true,Description="中国著名男歌手"},
                new Artist() { Name="泠鸢",Sex=false,Description="中国著名网络女歌手"},
                new Artist() { Name="hanser",Sex=false,Description="中国著名网络女歌手"},
                new Artist() { Name="王力宏",Sex=true,Description="中国著名男歌手"},
                new Artist() { Name="小缘",Sex=false,Description="大毛，中国著名网络女歌手"}
            };
            foreach (var a in artists)
                dbContext.Artists.Add(a);
            dbContext.SaveChanges();
            var albums=new List<Album>()
            {
                new Album() { Title="剑心",Genre=genres.Single(g=>g.Name=="流行"),Price=2.20M,Artist=artists.Single(a=>a.Name=="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="第一夫人",Genre=genres.Single(g=>g.Name=="流行"),Price=2.20M,Artist=artists.Single(a=>a.Name=="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="最美的太阳",Genre=genres.Single(g=>g.Name=="流行"),Price=2.20M,Artist=artists.Single(a=>a.Name=="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="逆战",Genre=genres.Single(g=>g.Name=="流行"),Price=2.20M,Artist=artists.Single(a=>a.Name=="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="着魔",Genre=genres.Single(g=>g.Name=="流行"),Price=2.20M,Artist=artists.Single(a=>a.Name=="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="爱不会绝迹",Genre=genres.Single(g=>g.Name=="古典"),Price=2.20M,Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="江南",Genre=genres.Single(g=>g.Name=="古典"),Price=2.20M,Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="曹操",Genre=genres.Single(g=>g.Name=="古典"),Price=2.20M,Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="背对背拥抱",Genre=genres.Single(g=>g.Name=="古典"),Price=2.20M,Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="修炼爱情",Genre=genres.Single(g=>g.Name=="古典"),Price=2.20M,Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="七里香",Genre=genres.Single(g=>g.Name=="蓝调"),Price=2.20M,Artist=artists.Single(a=>a.Name=="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="青花瓷",Genre=genres.Single(g=>g.Name=="蓝调"),Price=2.20M,Artist=artists.Single(a=>a.Name=="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="夜曲",Genre=genres.Single(g=>g.Name=="蓝调"),Price=2.20M,Artist=artists.Single(a=>a.Name=="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="双节棍",Genre=genres.Single(g=>g.Name=="蓝调"),Price=2.20M,Artist=artists.Single(a=>a.Name=="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="稻香",Genre=genres.Single(g=>g.Name=="蓝调"),Price=2.20M,Artist=artists.Single(a=>a.Name=="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="吻别",Genre=genres.Single(g=>g.Name=="慢摇"),Price=2.20M,Artist=artists.Single(a=>a.Name=="张学友"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="相思风雨中",Genre=genres.Single(g=>g.Name=="慢摇"),Price=2.20M,Artist=artists.Single(a=>a.Name=="张学友"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="情书",Genre=genres.Single(g=>g.Name=="慢摇"),Price=2.20M,Artist=artists.Single(a=>a.Name=="张学友"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="如果这都不算爱",Genre=genres.Single(g=>g.Name=="慢摇"),Price=2.20M,Artist=artists.Single(a=>a.Name=="张学友"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="一千个伤心的理由",Genre=genres.Single(g=>g.Name=="慢摇"),Price=2.20M,Artist=artists.Single(a=>a.Name=="张学友"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="六月的雨",Genre=genres.Single(g=>g.Name=="爵士"),Price=2.20M,Artist=artists.Single(a=>a.Name=="胡歌"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="逍遥叹",Genre=genres.Single(g=>g.Name=="爵士"),Price=2.20M,Artist=artists.Single(a=>a.Name=="胡歌"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="一吻天荒",Genre=genres.Single(g=>g.Name=="爵士"),Price=2.20M,Artist=artists.Single(a=>a.Name=="胡歌"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="光棍",Genre=genres.Single(g=>g.Name=="爵士"),Price=2.20M,Artist=artists.Single(a=>a.Name=="胡歌"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="忘记时间",Genre=genres.Single(g=>g.Name=="爵士"),Price=2.20M,Artist=artists.Single(a=>a.Name=="胡歌"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="素颜",Genre=genres.Single(g=>g.Name=="DJ"),Price=2.20M,Artist=artists.Single(a=>a.Name=="许嵩"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="断桥残雪",Genre=genres.Single(g=>g.Name=="DJ"),Price=2.20M,Artist=artists.Single(a=>a.Name=="许嵩"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="清明雨上",Genre=genres.Single(g=>g.Name=="DJ"),Price=2.20M,Artist=artists.Single(a=>a.Name=="许嵩"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="千百度",Genre=genres.Single(g=>g.Name=="DJ"),Price=2.20M,Artist=artists.Single(a=>a.Name=="许嵩"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="有何不可",Genre=genres.Single(g=>g.Name=="DJ"),Price=2.20M,Artist=artists.Single(a=>a.Name=="许嵩"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="葬花吟",Genre=genres.Single(g=>g.Name=="摇滚"),Price=2.20M,Artist=artists.Single(a=>a.Name=="双笙"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="大鱼",Genre=genres.Single(g=>g.Name=="摇滚"),Price=2.20M,Artist=artists.Single(a=>a.Name=="双笙"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="离歌",Genre=genres.Single(g=>g.Name=="摇滚"),Price=2.20M,Artist=artists.Single(a=>a.Name=="双笙"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="故梦",Genre=genres.Single(g=>g.Name=="摇滚"),Price=2.20M,Artist=artists.Single(a=>a.Name=="双笙"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="九九八十一",Genre=genres.Single(g=>g.Name=="摇滚"),Price=2.20M,Artist=artists.Single(a=>a.Name=="双笙"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="有点甜",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=2.20M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="雨天",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=2.20M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="黑眼圈",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=2.20M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="小流星",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=2.20M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="年轮",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=2.20M,Artist=artists.Single(a=>a.Name=="汪苏泷"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="神的随波逐流",Genre=genres.Single(g=>g.Name=="拉丁"),Price=2.20M,Artist=artists.Single(a=>a.Name=="泠鸢"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="锦鲤抄",Genre=genres.Single(g=>g.Name=="拉丁"),Price=2.20M,Artist=artists.Single(a=>a.Name=="泠鸢"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="寄明月",Genre=genres.Single(g=>g.Name=="拉丁"),Price=2.20M,Artist=artists.Single(a=>a.Name=="泠鸢"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="泼墨漓江",Genre=genres.Single(g=>g.Name=="拉丁"),Price=2.20M,Artist=artists.Single(a=>a.Name=="泠鸢"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="醉",Genre=genres.Single(g=>g.Name=="拉丁"),Price=2.20M,Artist=artists.Single(a=>a.Name=="泠鸢"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="时空之间",Genre=genres.Single(g=>g.Name=="重金属"),Price=2.20M,Artist=artists.Single(a=>a.Name=="hanser"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="猫耳开关",Genre=genres.Single(g=>g.Name=="重金属"),Price=2.20M,Artist=artists.Single(a=>a.Name=="hanser"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="阴阳名仕录",Genre=genres.Single(g=>g.Name=="重金属"),Price=2.20M,Artist=artists.Single(a=>a.Name=="hanser"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="拼凑的断音",Genre=genres.Single(g=>g.Name=="重金属"),Price=2.20M,Artist=artists.Single(a=>a.Name=="hanser"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="缘之空",Genre=genres.Single(g=>g.Name=="重金属"),Price=2.20M,Artist=artists.Single(a=>a.Name=="hanser"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="星光",Genre=genres.Single(g=>g.Name=="流行"),Price=2.20M,Artist=artists.Single(a=>a.Name=="王力宏"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="改变自己",Genre=genres.Single(g=>g.Name=="重金属"),Price=2.20M,Artist=artists.Single(a=>a.Name=="王力宏"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="依然爱你",Genre=genres.Single(g=>g.Name=="古典"),Price=2.20M,Artist=artists.Single(a=>a.Name=="王力宏"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="唯一",Genre=genres.Single(g=>g.Name=="拉丁"),Price=2.20M,Artist=artists.Single(a=>a.Name=="王力宏"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="童话",Genre=genres.Single(g=>g.Name=="摇滚"),Price=2.20M,Artist=artists.Single(a=>a.Name=="王力宏"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="无心",Genre=genres.Single(g=>g.Name=="流行"),Price=2.20M,Artist=artists.Single(a=>a.Name=="小缘"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="aliez",Genre=genres.Single(g=>g.Name=="流行"),Price=2.20M,Artist=artists.Single(a=>a.Name=="小缘"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="温柔之诗",Genre=genres.Single(g=>g.Name=="流行"),Price=2.20M,Artist=artists.Single(a=>a.Name=="小缘"),AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album() { Title="平安经年",Genre=genres.Single(g=>g.Name=="摇滚"),Price=2.20M,Artist=artists.Single(a=>a.Name=="小缘"),AlbumArtUrl = "/Content/Images/placeholder.gif" },
                new Album() { Title="最后的夏天",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=2.20M,Artist=artists.Single(a=>a.Name=="小缘"),AlbumArtUrl="/Content/Images/placeholder.gif"}

            };
            foreach (var n in albums)
                dbContext.Albums.Add(n);
            dbContext.SaveChanges();
        }
        public static void Extend()
        {
            var albums = dbContext.Albums.ToList();
            foreach (var album in albums)
            {
                var item = dbContext.Albums.Find(album.ID);
                item.GenreId = item.Genre.ID.ToString();
                item.ArtistId = item.Artist.ID.ToString();
                dbContext.SaveChanges();
                Thread.Sleep(3);
            }
        }
    }
}