using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace MusicStore101.Migrations
{
    public class GenreSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();

        //把GenreId和AritsiId赋值
        public static void Seed()
        {
            _dbContext.Database.ExecuteSqlCommand("delete albums");
            _dbContext.Database.ExecuteSqlCommand("delete artists");
            _dbContext.Database.ExecuteSqlCommand("delete genres");
            var genres = new List<Genre>
        {

            new Genre() {Name="摇滚",Description="Rock"},
             new Genre() {Name="爵士",Description="Rock"},
              new Genre() {Name="重金属",Description="Rock"},
               new Genre() {Name="慢摇",Description="Rock"},
                new Genre() {Name="蓝调",Description="Rock"},
                 new Genre() {Name="流行",Description="Rock"},
                  new Genre() {Name="电音",Description="Rock"},
                   new Genre() {Name="民谣",Description="Rock"},
        };
            foreach (var g in genres)
                _dbContext.Genre.Add(g);

            var artists = new List<Artist>
        {
             new Artist() {Name="蔡健雅",Sex=false,Description="新加坡人，华语著名歌手、词曲作者，音乐制作人。1997年在新加坡由其经纪公司 Music & Movement 旗下的Yellow Music发行英语专辑《Bored》而正式出道，1999年将国语唱片签约于宝丽金唱片旗下，并推出首张国语同名专辑《蔡健雅》。2000年因宝丽金唱片并入环球唱片旗下，因此《记念》及之后的唱片皆由台湾环球唱片发行。在此一专辑中，蔡健雅以〈记念〉一曲成功打响在台湾市场的知名度。同年入围台湾第11届金曲奖最佳新人奖。2002年发行《Secret Lavender》专辑。同年以〈打错了〉作曲者身份入围台湾第13届金曲奖最佳作曲人奖，并同时入围最佳国语演唱人奖。2004年首度担任制作人，替梁咏琪制作《归属感》专辑。同年以《陌生人》获得台湾第15届金曲奖最佳国语女演唱人提名。2008年推出专辑《My Space》，同年获台湾第19届金曲奖7项提名，并获得了最佳专辑制作人和最佳国语女歌手两座大奖。近年移居台湾。2012年获最佳国语女歌手奖。代表作品：《呼吸》《陌生人》《空白格》《若你碰到他》《红色高跟鞋》。"},
             new Artist() {Name="田馥甄",Sex=false,Description="田馥甄，艺名Hebe，台湾知名女艺人，女子演唱团体S.H.E组合成员，出生于台湾新竹县新丰乡，于2000年参加“宇宙2000实力美少女争霸战”选秀活动，并于同年与宇宙唱片（华研唱片前身）签约培训，接着在隔年与Selina、Ella组成S.H.E，并于2001年9月11日发行S.H.E首张专辑《女生宿舍》正式出道。2010年下半年，S.H.E正式迈向“单飞不解散”阶段，接着同年9月3日，使用本名“田馥甄”推出首张个人专辑《To Hebe》。"},
              new Artist() {Name="陈粒",Sex=false,Description="陈粒，又名粒粒，1990年7月26日出生于贵州省贵阳市，中国内地民谣女歌手、独立音乐人、唱作人，前空想家乐队主唱，毕业于上海对外经贸大学。2012年，其所在乐队“空想家乐队”获得“Zippo炙热摇滚大赛”上海赛区冠军。2014年，随空想家乐队推出乐队首张EP专辑《万象》；同年，其演唱的歌曲《奇妙能力歌》入围“第四届阿比鹿音乐奖”年度民谣单曲。2015年，推出首张个人音乐专辑《如也》；同年，推出个人民谣单曲《远辰》。2016年1月，获得“第五届阿比鹿音乐奖”最受欢迎音乐人（民谣）；同年3月8日，化身“粒粒”并推出首支单曲《幻期颐》；同年7月26日，推出第二张个人音乐专辑《小梦大半》。"},

        };

            foreach (var a in artists)
                _dbContext.Artist.Add(a);
            _dbContext.SaveChanges();


            //使用Lamda代替foreach
            var alubms = new List<Album>
            {
                new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="民谣"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="摇滚"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="民谣"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif"},


                 new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="摇滚"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                  new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="摇滚"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                    new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="摇滚"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                      new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="摇滚"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                        new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="电音"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                          new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="民谣"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                            new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="民谣"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                              new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="民谣"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                               new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="民谣"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                                new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="电音"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                                 new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="民谣"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},


                                 new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="摇滚"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},
   new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="电音"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif"},
   
      new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="电音"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},

         new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="电音"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif"},

            new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="摇滚"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

               new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="摇滚"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                  new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="电音"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                     new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="爵士"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                        new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="爵士"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                           new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="电音"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                                     new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="爵士"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                                               new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="电音"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                                                         new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="爵士"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                                                                 new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="爵士"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                                                                         new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="爵士"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                                                                                 new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="电音"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                                                                                         new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="慢摇"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                                                                                                 new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="蓝调"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},

                                                                                                         new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="蓝调"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"},



                                new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="流行"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},


                                new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="流行"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},


                                new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="流行"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},


                                new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="民谣"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},


                                new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="电音"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},


                                new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="民谣"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},


                                new Album
                { Title = "The Best Of Men At Work",Genre=genres.Single(g=>g.Name=="电音"),
                    Price =8.99m,Artist=artists.Single(a=>a.Name=="陈粒"),AlbumArtUrl="/Content/Images/placeholder.gif"},

            };/*.ForEach(n => _dbContext.Albums.Add(n));*/
            //_dbContext.SaveChanges();
            foreach (var a in alubms)
                _dbContext.Albums.Add(a);
            _dbContext.SaveChanges();
        }



        //_dbContext.SaveChanges();
        public static void Extend()
        {
            var albums = _dbContext.Albums.ToList();
            foreach (var album in albums)
            {
                var item = _dbContext.Albums.Find(album.ID);
                item.GenreId = item.Genre.ToString();
                item.ArtistId = item.Genre.ToString();
                _dbContext.SaveChanges();
                Thread.Sleep(3);

            }
        }
    }
}
