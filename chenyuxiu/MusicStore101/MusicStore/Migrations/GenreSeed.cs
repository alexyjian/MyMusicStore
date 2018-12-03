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
        private static readonly MusicStoreEntity.EntityDbContext _dbcontext = new MusicStoreEntity.EntityDbContext();
        public static void Seed()
        {
            _dbcontext.Database.ExecuteSqlCommand("delete albums");
            _dbcontext.Database.ExecuteSqlCommand("delete artists");
            _dbcontext.Database.ExecuteSqlCommand("delete genres");
            var genres = new List<Genre>()
            {
                new Genre() { Name="摇滚",Description="Rock"},
                new Genre() { Name="爵士",Description="Jazz"},
                new Genre() { Name="重金属",Description="Metal"},
                new Genre() { Name="慢摇",Description="downtempo"},
                new Genre() { Name="蓝调",Description="blue"},
                new Genre() { Name="拉丁",Description="Latin"},
                new Genre() { Name="流行",Description="Pop"},
                new Genre() { Name="古典",Description="classical"},
                new Genre() { Name="DJ",Description="DJ"},
                new Genre() { Name="嘻哈",Description="HiHop"},
            };
            foreach (var g in genres)
                _dbcontext.Genres.Add(g);

            var artists = new List<Artist> {
                new Artist() { Name="黄子韬",Sex=true,Description="黄子韬，黄子韬，1993年5月2日出生于山东省青岛市，中国流行乐男歌手、演员、主持人。。"},
                new Artist() { Name="黄轩",Sex=false,Description="黄轩，黄轩，1985年3月3日出生于甘肃省兰州市，华语影视男演员，毕业于北京舞蹈学院音乐剧系。"},
                new Artist() { Name="彭于晏",Sex=false,Description="彭于晏：1982年3月24日出生于台湾澎湖，中国台湾影视男演员、歌手"},
                new Artist() { Name="邓紫棋",Sex=false,Description="邓紫棋1991年8月16日生于中国上海，4岁移居香港，中国香港创作型女歌手"},
                new Artist() { Name="林俊杰",Sex=true,Description="林俊杰（JJ Lin）981年3月27日出生于新加坡，华语流行乐男歌手、词曲创作者、音乐制作人。"},
                new Artist() { Name="薛之谦",Sex=true,Description="薛之谦（Joker Xue），1983年7月17日出生于上海，华语流行乐男歌手、影视演员、音乐制作人，毕业于格里昂酒店管理学院。 "},
                new Artist() { Name="张艺兴",Sex=false,Description="张艺兴（LAY），1991年10月7日出生于湖南省长沙市，内地流行男歌手、影视演员，男子演唱组合EXO/EXO-M中国籍成员。"},
                new Artist() { Name="蔡徐坤",Sex=false,Description="蔡徐坤，蔡徐坤（KUN），1998年8月2日出生于浙江省，中国内地男歌手、演员、音乐制作人。"},
                new Artist() { Name="李敏镐",Sex=true,Description="李敏镐，李敏镐（이민호、Lee MinHo），1987年6月22日出生于首尔，韩国男演员"},
                new Artist() { Name="乔任梁",Sex=false,Description="乔任梁（KIMI，1987年10月15日-2016年9月16日），出生于上海市，中国内地影视男演员、流行乐歌手，毕业于上海电机学院"},
                new Artist() { Name="杨幂",Sex=true,Description="杨幂，1986年9月12日出生于北京市，中国内地影视女演员、流行乐歌手、影视制片人"},
                new Artist() { Name="陈伟霆",Sex=true,Description="陈伟霆（William Chan），1985年11月21日出生于中国香港，华语影视男演员、歌手、主持人。2003年，因参加全球华人新秀香港区选拔赛而进入演艺圈。"},
                new Artist() { Name="张碧晨",Sex=false,Description="张碧晨，1989年9月10日出生于天津市，华语流行乐女歌手，毕业于天津外国语大学。"},
                new Artist() { Name="范冰冰",Sex=true,Description="范冰冰，1981年9月16日出生于山东青岛，华语影视女演员、制片人、歌手，毕业于上海师范大学谢晋影视艺术学院。"},
            };
            foreach (var a in artists)
                _dbcontext.Artists.Add(a);
            _dbcontext.SaveChanges();

            var albums = new List<Album>
            {
                new Album {
                    Title = "那就这样吧",
                    Genre = genres.Single(g=>g.Name =="摇滚"),
                    Price = 8.99M,
                    Artist=artists.Single(a=>a.Name=="张艺兴"),
                  AlbumArtUrl="/Content/Images/placeholder.gif"},
                 new Album {
                    Title = "追光者",
                    Genre = genres.Single(g=>g.Name =="摇滚"),
                    Price = 8.99M,
                    Artist=artists.Single(a=>a.Name=="黄轩"),
                    AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "平凡之路",
                   Genre = genres.Single(g=>g.Name =="爵士"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="蔡徐坤"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "倒数",
                   Genre = genres.Single(g=>g.Name =="慢摇"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="邓紫棋"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "心安理得",
                   Genre = genres.Single(g=>g.Name =="慢摇"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="林俊杰"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "学不会",
                   Genre = genres.Single(g=>g.Name =="慢摇"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="林俊杰"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "小猫叫",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="黄子韬"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "爱一点",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="杨幂"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "你就不要想起我",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="彭于晏"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "你一定要幸福",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="范冰冰"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "水心机",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="李敏镐"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "心态",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="李敏镐"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                 new Album {
                   Title = "流行音乐歌",
                   Genre = genres.Single(g=>g.Name =="流行"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="范冰冰"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "情花",
                   Genre = genres.Single(g=>g.Name =="流行"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="薛之谦"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "不爱最大",
                   Genre = genres.Single(g=>g.Name =="流行"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张碧晨"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "天真",
                   Genre = genres.Single(g=>g.Name =="流行"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张碧晨"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                 new Album {
                   Title = "风筝",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张碧晨"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "完美的一天",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="李敏镐"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "下着雨",
                   Genre = genres.Single(g=>g.Name =="流行"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="邓紫棋"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "夜空中最亮的星",
                   Genre = genres.Single(g=>g.Name =="流行"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="邓紫棋"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                 new Album {
                   Title = "喜欢你",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="邓紫棋"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "泡沫",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="邓紫棋"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "可惜没如果",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="乔任梁"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "我的秘密",
                   Genre = genres.Single(g=>g.Name =="流行"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="乔任梁"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                 new Album {
                   Title = "告白气球",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="李敏镐"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "那片海",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="邓紫棋"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                 new Album {
                   Title = "爱的魔法",
                   Genre = genres.Single(g=>g.Name =="摇滚"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="李敏镐"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "咖喱咖喱",
                   Genre = genres.Single(g=>g.Name =="流行"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="李敏镐"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                 new Album {
                   Title = "童话",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="乔任梁"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "体面",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="乔任梁"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "因为爱情",
                   Genre = genres.Single(g=>g.Name =="摇滚"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="乔任梁"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "一念之间  ",
                   Genre = genres.Single(g=>g.Name =="流行"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="乔任梁"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                 new Album {
                   Title = "满满",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="乔任梁"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "发现爱",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="乔任梁"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "One Chance新歌+精选&2011这就是爱",
                   Genre = genres.Single(g=>g.Name =="摇滚"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张碧晨"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "为了遇见你",
                   Genre = genres.Single(g=>g.Name =="流行"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张碧晨"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                 new Album {
                   Title = "屋顶",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张碧晨"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "小酒窝",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张碧晨"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                  new Album {
                   Title = "非常幸运",
                   Genre = genres.Single(g=>g.Name =="摇滚"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张碧晨"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "98K",
                   Genre = genres.Single(g=>g.Name =="流行"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张碧晨"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                 new Album {
                   Title = "陷阱",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张碧晨"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "一万个不可能",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张碧晨"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "老人与海",
                   Genre = genres.Single(g=>g.Name =="摇滚"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="范冰冰"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "我的回忆不是我的",
                   Genre = genres.Single(g=>g.Name =="流行"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="范冰冰"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                 new Album {
                   Title = "我以为",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张艺兴"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "十指紧扣",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张艺兴"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "意外",
                   Genre = genres.Single(g=>g.Name =="摇滚"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="林俊杰"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "煎熬",
                   Genre = genres.Single(g=>g.Name =="流行"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="林俊杰"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                 new Album {
                   Title = "烟火里的尘埃",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张艺兴"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
                new Album {
                   Title = "你，好不好",
                   Genre = genres.Single(g=>g.Name =="古典"),
                   Price = 8.99M,
                   Artist=artists.Single(a=>a.Name=="张艺兴"),
                   AlbumArtUrl="/Content/Images/placeholder.gif"},
            };

            /*ForEach(n => _dbcontext.Albums.Add(n));*/
            foreach (var c in albums)
                _dbcontext.Albums.Add(c);
            _dbcontext.SaveChanges();
        }

        //给Genreld和Artistld赋值
        public static void Extend()
        {
            var albums = _dbcontext.Albums.ToList();
            foreach (var album in albums)
            {
                var item = _dbcontext.Albums.Find(album.ID);
                item.GenreId = item.Genre.ID.ToString();
                item.Artistld = item.Artist.ID.ToString();
                _dbcontext.SaveChanges();
                Thread.Sleep(3);
            }
        }
    }
}