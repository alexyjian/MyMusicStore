using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class GenreSseed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();
        public static void Seed()
        {
            var genres = new List<Genre>()
            {
                 new Genre() { Name = "摇滚",Desciption="Rack"},
                   new Genre() { Name = "DJ",Desciption="DJ"},
                     new Genre() { Name = "流行",Desciption="fashion"},
                       new Genre() { Name = "乡村",Desciption="country"},
                         new Genre() { Name = "爱情",Desciption="LOVE"},
                           new Genre() { Name = "伤感",Desciption="slop over"},
                             new Genre() { Name = "情歌",Desciption="love song"},
            };
            foreach (var g in genres)
            {
                _dbContext.Genres.Add(g);
            }
            _dbContext.SaveChanges();
        }
    }

}