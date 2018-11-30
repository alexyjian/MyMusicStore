using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class ArtistSeed
    {
        static readonly MusicStoreEntity.MusicContext _dbMusicContext = new MusicStoreEntity.MusicContext();
        public static void Seed()
        {
            var Artists = new List<Artist>()
            {
                new Artist () { Name="华晨宇"},
                new Artist () { Name="蔡健雅" },
                new Artist () { Name="王以太" },
                new Artist () { Name="The Chainsmokers" },
                new Artist () { Name="马雨阳" },
                new Artist () { Name="徐秉龙" },
                new Artist () { Name="毛不易" },
                new Artist () { Name="房东的猫" },
                new Artist () { Name="Charlie Puth" },
                new Artist () { Name="艾热" },
                new Artist () { Name="许嵩" },
                new Artist () { Name="王力宏" },
                new Artist () { Name="田馥甄" },
            };
            foreach (var a in Artists)
                _dbMusicContext.Artists.Add(a);
            _dbMusicContext.SaveChanges();
        }
    }
}