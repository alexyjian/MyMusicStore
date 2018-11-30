using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class AlbumSeed
    {
        static readonly MusicStoreEntity.MusicContext _dbMusicContext = new MusicStoreEntity.MusicContext();
        public static void Seed()
        {
            new List<Album>()
            {
                new Album () { Title = "Bad Habit", Price = 8.9m,Genre = _GetGenreByGenreName("乡村"), GenreId = _GetGenreByGenreName("乡村").ID.ToString(), Artist = _GetArtistByArtistName("华晨宇"), ArtistId = _GetArtistByArtistName("华晨宇").ID.ToString()},
                new Album () { Title="A swim in the love that you give me" , Price = 8.8m,Genre = _GetGenreByGenreName("说唱"), GenreId = _GetGenreByGenreName("说唱").ID.ToString(), Artist = _GetArtistByArtistName("蔡健雅"), ArtistId = _GetArtistByArtistName("蔡健雅").ID.ToString()},
                new Album () { Title="抱紧你" , Price = 8.7m,Genre = _GetGenreByGenreName("摇滚"), GenreId = _GetGenreByGenreName("摇滚").ID.ToString(), Artist = _GetArtistByArtistName("王以太"), ArtistId = _GetArtistByArtistName("王以太").ID.ToString()},
                new Album () { Title="我喜欢的每个女孩都有男朋友" , Price = 8.6m,Genre = _GetGenreByGenreName("古典"), GenreId = _GetGenreByGenreName("古典").ID.ToString(), Artist = _GetArtistByArtistName("The Chainsmokers"), ArtistId = _GetArtistByArtistName("The Chainsmokers").ID.ToString()},
                new Album () { Title="绿色丛林" , Price = 8.5m,Genre = _GetGenreByGenreName("爵士"), GenreId = _GetGenreByGenreName("爵士").ID.ToString(), Artist = _GetArtistByArtistName("马雨阳"), ArtistId = _GetArtistByArtistName("马雨阳").ID.ToString()},
                new Album () { Title="Late Night" , Price = 8.4m,Genre = _GetGenreByGenreName("舞曲"), GenreId = _GetGenreByGenreName("舞曲").ID.ToString(), Artist = _GetArtistByArtistName("徐秉龙"), ArtistId = _GetArtistByArtistName("徐秉龙").ID.ToString()},
                new Album () { Title="Playboy Style" , Price = 8.3m,Genre = _GetGenreByGenreName("Soul"), GenreId = _GetGenreByGenreName("Soul").ID.ToString(), Artist = _GetArtistByArtistName("毛不易"), ArtistId = _GetArtistByArtistName("毛不易").ID.ToString()},
                new Album () { Title="徒花ネクロマンシー" ,Price = 4.9m,Genre = _GetGenreByGenreName("轻音乐"), GenreId = _GetGenreByGenreName("轻音乐").ID.ToString(), Artist = _GetArtistByArtistName("房东的猫"), ArtistId = _GetArtistByArtistName("房东的猫").ID.ToString()},
                new Album () { Title="IKIJIBIKI feat.Taka" , Price = 8.2m,Genre = _GetGenreByGenreName("电子"), GenreId = _GetGenreByGenreName("电子").ID.ToString(), Artist = _GetArtistByArtistName("艾热"), ArtistId = _GetArtistByArtistName("艾热").ID.ToString()},
                new Album () { Title="hectopascal" , Price = 8.1m,Genre = _GetGenreByGenreName("流行"), GenreId = _GetGenreByGenreName("流行").ID.ToString(), Artist = _GetArtistByArtistName("许嵩"), ArtistId = _GetArtistByArtistName("许嵩").ID.ToString()},
                new Album () { Title="倾城时光" , Price = 7.9m,Genre = _GetGenreByGenreName("英伦"), GenreId = _GetGenreByGenreName("英伦").ID.ToString(), Artist = _GetArtistByArtistName("王力宏"), ArtistId = _GetArtistByArtistName("王力宏").ID.ToString()},
                new Album () { Title="喜新恋旧" , Price = 6.9m,Genre = _GetGenreByGenreName("民族"), GenreId = _GetGenreByGenreName("民族").ID.ToString(), Artist = _GetArtistByArtistName("田馥甄"), ArtistId = _GetArtistByArtistName("田馥甄").ID.ToString()},
                new Album () { Title="绝代风华" , Price = 5.9m,Genre = _GetGenreByGenreName("民谣"), GenreId = _GetGenreByGenreName("民谣").ID.ToString(), Artist = _GetArtistByArtistName("Charlie Puth"), ArtistId = _GetArtistByArtistName("Charlie Puth").ID.ToString()},
            }.ForEach(g=>_dbMusicContext.Albums.Add(g));
            _dbMusicContext.SaveChanges();
        }

        static Genre _GetGenreByGenreName(string name)
        {
            return _dbMusicContext.Genres.Single(g => g.Name == name);
        }
        static Artist _GetArtistByArtistName(string name)
        {
            return _dbMusicContext.Artists.Single(g => g.Name == name);
        }
    }
}