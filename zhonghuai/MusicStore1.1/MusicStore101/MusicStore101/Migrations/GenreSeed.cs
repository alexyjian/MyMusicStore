using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore101.Migrations
{
    public class GenreSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();
    

    public static void  Seed()
    {
        _dbContext.Database.ExecuteSqlCommand("delete genres");
        var genres = new List<Genre>
        {
       
            new Genre() {Name="摇滚"},
             new Genre() {Name="爵士"},
              new Genre() {Name="重金属"},
               new Genre() {Name="慢摇"},
                new Genre() {Name="蓝调"},
                 new Genre() {Name="流行"},
                  new Genre() {Name="电音"},
                   new Genre() {Name="民谣"},
        };
        foreach (var g in genres)
           _dbContext.Genre.Add(g);
        _dbContext.SaveChanges();
    }
 }
}