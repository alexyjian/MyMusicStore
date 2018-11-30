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
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();

        public static void Seed()
        {
            _dbContext.Database.ExecuteSqlCommand("delete Albums");
            _dbContext.Database.ExecuteSqlCommand("delete Artists");
            _dbContext.Database.ExecuteSqlCommand("delete Genres");
            //类型
            var genres = new List<Genre>()
            {
                new Genre() { Name="Emo Rap"},
                new Genre() { Name="Trap Rap"},
                new Genre() { Name="Pop Rap"},
                new Genre() { Name="Old Schold"},
                new Genre() { Name="Alternative Rap"},
                new Genre() { Name="Jazz Rap"},
                new Genre() { Name="Disco"},
                new Genre() { Name="Rock"},
                new Genre() { Name="Latin"},
            };
            foreach (var g in genres)
            _dbContext.Genres.Add(g);

            _dbContext.SaveChanges();

            //歌手
            var Artists = new List<Artist>()
            {
                new Artist() { Name="Juice WRLD",Sex=false,Description=""},
                new Artist() { Name="Lil.Jet",Sex=false,Description=""},
                new Artist() { Name="Higher Brothers",Sex=false,Description=""},
                new Artist() { Name="88rising",Sex=false,Description=""},
                new Artist() { Name="Rich Brian",Sex=false,Description=""},
                new Artist() { Name="PO8",Sex=false,Description=""},
                new Artist() { Name="Ty",Sex=false,Description=""},
                new Artist() { Name="MC光光",Sex=false,Description=""},
                new Artist() { Name="XXXTENTACION",Sex=false,Description=""},
                new Artist() { Name="Kc",Sex=false,Description=""},
            };
            foreach (var a in Artists)
                _dbContext.Artists.Add(a);

            _dbContext.SaveChanges();

            //专辑
            new List<Album>()
            {
                new Album {
                    Title ="Sad",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="XXXTENTACION"),
                    AlbumArtUrl="~/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="?",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="XXXTENTACION"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="BAD",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="XXXTENTACION"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="Changes",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="XXXTENTACION"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="17",Price=20.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="XXXTENTACION"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="Revenge",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="XXXTENTACION"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="Look At Me",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="XXXTENTACION"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="play fair(prod.808 mafia)",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="Juice WRLD"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="This Cant Be Happening",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="Juice WRLD"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="Nascar",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="Juice WRLD"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="Wasted",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="Juice WRLD"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="JuiceWRLD 9 9 9",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="Juice WRLD"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="0755",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="Lil.Jet"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="我真的没想好",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Emo Rap"),
                    Artist =Artists.Single(a=>a.Name=="Lil.Jet"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="说句实话",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Pop Rap"),
                    Artist =Artists.Single(a=>a.Name=="Lil.Jet"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="鹰",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Trap Rap"),
                    Artist =Artists.Single(a=>a.Name=="Lil.Jet"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="暴雨",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Pop Rap"),
                    Artist =Artists.Single(a=>a.Name=="Lil.Jet"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="Lover Boy 88",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Pop Rap"),
                    Artist =Artists.Single(a=>a.Name=="Higher Brothers"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="Made In China",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Trap Rap"),
                    Artist =Artists.Single(a=>a.Name=="Higher Brothers"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="Rich",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Trap Rap"),
                    Artist =Artists.Single(a=>a.Name=="Higher Brothers"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="Chanel",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Trap Rap"),
                    Artist =Artists.Single(a=>a.Name=="Higher Brothers"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                new Album {
                    Title ="Black Cab",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Trap Rap"),
                    Artist =Artists.Single(a=>a.Name=="Higher Brothers"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                 new Album {
                    Title ="熊猫(Panda REMIX)",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Trap Rap"),
                    Artist =Artists.Single(a=>a.Name=="Higher Brothers"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                  new Album {
                    Title ="HIGHER BROTHERS",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Trap Rap"),
                    Artist =Artists.Single(a=>a.Name=="Higher Brothers"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                   new Album {
                    Title ="Black Cab",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Trap Rap"),
                    Artist =Artists.Single(a=>a.Name=="Higher Brothers"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                    new Album {
                    Title ="Amen",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Trap Rap"),
                    Artist =Artists.Single(a=>a.Name=="Rich Brian"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                    new Album {
                    Title ="See Me",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Trap Rap"),
                    Artist =Artists.Single(a=>a.Name=="Rich Brian"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                    new Album {
                    Title ="Chaos",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Trap Rap"),
                    Artist =Artists.Single(a=>a.Name=="Rich Brian"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                    new Album {
                    Title ="Glow Like Dat",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Trap Rap"),
                    Artist =Artists.Single(a=>a.Name=="Rich Brian"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },
                    new Album {
                    Title ="Who That Be",Price=8.00M,
                    Genre =genres.Single(g=>g.Name=="Trap Rap"),
                    Artist =Artists.Single(a=>a.Name=="Rich Brian"),
                    AlbumArtUrl="/Content/images/placeholder.gif"
                },

            }.ForEach(n => _dbContext.Albums.Add(n));
            _dbContext.SaveChanges();
        }

        public static void Extend()
        {
            var albums = _dbContext.Albums.ToList();
            foreach (var album in albums)
            {
                var item = _dbContext.Albums.Find(album.ID);
                item.GenreID = item.GenreID.ToString();
                item.ArtistID = item.ArtistID.ToString();
                Thread.Sleep(3);
            }
            _dbContext.SaveChanges();
        }
    }

}