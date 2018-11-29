using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class GenreSeed
    {
        static readonly MusicStoreEntity.MusicContext _dbMusicContext = new MusicStoreEntity.MusicContext();
        public static void Seed()
        {
            var genres = new List<Genre>()
            {
                new Genre () { Name="流行" },
                new Genre () { Name="摇滚" },
                new Genre () { Name="民谣" },
                new Genre () { Name="电子" },
                new Genre () { Name="舞曲" },
                new Genre () { Name="说唱" },
                new Genre () { Name="轻音乐" },
                new Genre () { Name="爵士" },
                new Genre () { Name="乡村" },
                new Genre () { Name="Soul" },
                new Genre () { Name="古典" },
                new Genre () { Name="民族" },
                new Genre () { Name="英伦" },
            };
            foreach (var g in genres)
                _dbMusicContext.Genres.Add(g);
            _dbMusicContext.SaveChanges();
        }
    }
}