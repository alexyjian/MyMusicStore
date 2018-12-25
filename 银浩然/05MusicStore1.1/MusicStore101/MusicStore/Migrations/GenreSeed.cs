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
                new Genre() {Name =  "重金属",Description = "Metal"},
                new Genre() {Name =  "慢摇",Description = "DownTempo"},
                new Genre() {Name =  "蓝调",Description = "Blue"},
                new Genre() {Name =  "拉丁",Description = "Latin"},
                new Genre() {Name =  "流行",Description = "Pop"},
                new Genre() {Name =  "古典",Description = "Classical"},
                new Genre() {Name =  "DJ",Description = "DJ"},
                new Genre() {Name =  "嘻哈",Description = "HiHop"},
            };

            foreach (var g in genres)
                _dbContext.Genres.Add(g);

            var artists = new List<Artist>()
            {
                new Artist(){Name = "孙耀威",Sex = true,Description="1973年1月3日生于香港，香港著名歌手、演员、主持的全能型活跃艺人。"},
                new Artist(){Name = "周杰伦",Sex = true,Description="著名歌手，音乐人，词曲创作人，编曲及制作人，MV及电影导演。新世纪华语歌坛领军人物，中国风歌曲始祖，被时代周刊誉为“亚洲猫王”。"},
                new Artist(){Name = "林俊杰",Sex = true,Description="著名男歌手，作曲人、作词人、音乐制作人，偶像与实力兼具。"},
                new Artist(){Name = "张芸京",Sex = false,Description="被称为“摇滚小天后”台湾女歌手。"},
                new Artist(){Name = "金莎",Sex = false,Description="金莎（kym），中国流行女歌手、演员。"},
                new Artist(){Name = "张杰",Sex = true,Description="华语歌坛新生代领军人物，偶像与实力兼具的超人气天王。"},
                new Artist(){Name = "赵雷",Sex = true,Description="民谣音乐人赵雷，中国内地新生代民谣歌手。"},
                new Artist(){Name = "梁静茹",Sex = false,Description="华语著名女歌手，马来西亚人。被称为“情歌天后”。"},
                new Artist(){Name = "毛不易",Sex = true,Description="毛不易，原名王维家，1994年10月1日出生于黑龙江省齐齐哈尔市泰来县，中国内地流行乐男歌手，毕业于杭州师范大学护理专业。"},
                new Artist(){Name = "徐佳莹",Sex = false,Description="华语流行音乐创作女歌手、金曲奖得主。1984年12月20日生于台湾台中市，籍贯四川省简阳县。"},
            };
            foreach (var a in artists)
                _dbContext.Artists.Add(a);

            var albums = new List<Album>()
            {
                new Album
                {
                    Title="爱的故事上集",Genre=genres.Single(g =>g.Name=="摇滚"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="孙耀威"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title="爱的故事下集",Genre=genres.Single(g =>g.Name=="摇滚"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="孙耀威"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                  new Album
                {
                    Title="相爱很难",Genre=genres.Single(g =>g.Name=="摇滚"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="孙耀威"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                   new Album
                {
                    Title="仍然喜欢你",Genre=genres.Single(g =>g.Name=="摇滚"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="孙耀威"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                    new Album
                {
                    Title="明知故犯",Genre=genres.Single(g =>g.Name=="摇滚"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="孙耀威"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="夜曲",Genre=genres.Single(g =>g.Name=="爵士"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title="稻香",Genre=genres.Single(g =>g.Name=="爵士"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                  new Album
                {
                    Title="布拉格广场",Genre=genres.Single(g =>g.Name=="爵士"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                   new Album
                {
                    Title="告白气球",Genre=genres.Single(g =>g.Name=="爵士"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                    new Album
                {
                    Title="青花瓷",Genre=genres.Single(g =>g.Name=="爵士"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="周杰伦"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="江南",Genre=genres.Single(g =>g.Name=="蓝调"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="背对背拥抱",Genre=genres.Single(g =>g.Name=="蓝调"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="可惜没如果",Genre=genres.Single(g =>g.Name=="蓝调"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="修炼爱情",Genre=genres.Single(g =>g.Name=="蓝调"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="小酒窝",Genre=genres.Single(g =>g.Name=="蓝调"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="林俊杰"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="偏爱",Genre=genres.Single(g =>g.Name=="嘻哈"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="张芸京"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title="春泥",Genre=genres.Single(g =>g.Name=="嘻哈"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="张芸京"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                  new Album
                {
                    Title="情人结",Genre=genres.Single(g =>g.Name=="嘻哈"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="张芸京"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                   new Album
                {
                    Title="黑裙子",Genre=genres.Single(g =>g.Name=="嘻哈"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="张芸京"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                    new Album
                {
                    Title="相反的我",Genre=genres.Single(g =>g.Name=="嘻哈"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="张芸京"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="星月神话",Genre=genres.Single(g =>g.Name=="古典"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="金莎"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title="画中仙",Genre=genres.Single(g =>g.Name=="古典"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="金莎"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                  new Album
                {
                    Title="梦千年之恋",Genre=genres.Single(g =>g.Name=="古典"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="金莎"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                   new Album
                {
                    Title="最后一个夏天",Genre=genres.Single(g =>g.Name=="古典"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="金莎"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                    new Album
                {
                    Title="爱的魔法",Genre=genres.Single(g =>g.Name=="古典"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="金莎"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="我们都一样",Genre=genres.Single(g =>g.Name=="流行"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title="这，就是爱",Genre=genres.Single(g =>g.Name=="流行"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                  new Album
                {
                    Title="第一夫人",Genre=genres.Single(g =>g.Name=="流行"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                   new Album
                {
                    Title="天下",Genre=genres.Single(g =>g.Name=="流行"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                    new Album
                {
                    Title="着魔",Genre=genres.Single(g =>g.Name=="流行"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="张杰"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="成都",Genre=genres.Single(g =>g.Name=="重金属"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="赵雷"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                 new Album
                {
                    Title="南方姑娘",Genre=genres.Single(g =>g.Name=="重金属"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="赵雷"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                  new Album
                {
                    Title="理想",Genre=genres.Single(g =>g.Name=="重金属"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="赵雷"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                   new Album
                {
                    Title="画",Genre=genres.Single(g =>g.Name=="重金属"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="赵雷"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                    new Album
                {
                    Title="少年锦时",Genre=genres.Single(g =>g.Name=="重金属"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="赵雷"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="勇气",Genre=genres.Single(g =>g.Name=="慢摇"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="梁静茹"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                  new Album
                {
                    Title="宁夏",Genre=genres.Single(g =>g.Name=="慢摇"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="梁静茹"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                    new Album
                {
                    Title="分手快乐",Genre=genres.Single(g =>g.Name=="慢摇"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="梁静茹"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                      new Album
                {
                    Title="暖暖",Genre=genres.Single(g =>g.Name=="慢摇"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="梁静茹"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                        new Album
                {
                    Title="会过去的",Genre=genres.Single(g =>g.Name=="慢摇"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="梁静茹"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="平凡的一天",Genre=genres.Single(g =>g.Name=="DJ"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="毛不易"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="无问",Genre=genres.Single(g =>g.Name=="DJ"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="毛不易"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="不染",Genre=genres.Single(g =>g.Name=="DJ"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="毛不易"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="消愁",Genre=genres.Single(g =>g.Name=="DJ"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="毛不易"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="像我这样的人",Genre=genres.Single(g =>g.Name=="DJ"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="毛不易"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="身骑白马",Genre=genres.Single(g =>g.Name=="拉丁"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="最初的记忆",Genre=genres.Single(g =>g.Name=="拉丁"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="一江水",Genre=genres.Single(g =>g.Name=="拉丁"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="失落沙洲",Genre=genres.Single(g =>g.Name=="拉丁"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
                new Album
                {
                    Title="最美的遇见",Genre=genres.Single(g =>g.Name=="拉丁"),Price=8.99M,
                    Artist=artists.Single(a=>a.Name=="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },
            };
            foreach (var n in albums)
                _dbContext.Albums.Add(n);
            _dbContext.SaveChanges();
        }

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