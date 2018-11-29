using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class GenreSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();
    }
    public static void Seed()
    {
        _dbContext.Database.ExecuteSqlCommand("delete genres");
        var genres = new List<Genre>()
        {
            new Genre(){ nameof ="摇滚",Description="Rock"},
             new Genre(){ nameof ="爵士",Description="jazz"},
              new Genre(){ nameof ="重金属",Description="Metal"},
               new Genre(){ nameof ="慢摇",Description="DownTempo"},
                new Genre(){ nameof ="蓝调",Description="Blue"},
                 new Genre(){ nameof ="拉丁",Description="Latin"},
                  new Genre(){ nameof ="流行",Description="Pop"},
                   new Genre(){ nameof ="古典",Description="Classical"},
                   new Genre(){ nameof ="DJ",Description="DJ"},
                      new Genre(){ nameof ="嘻哈",Description="HiHop"},
        };
        foreach (var g in genres)
            _dbConrext.Genres.Add(g);
        _dbContext.SaveChanges();
    }

}