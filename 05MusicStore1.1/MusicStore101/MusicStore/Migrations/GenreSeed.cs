using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStoreEntity;

namespace MusicStore.Migrations
{
    public class GenreSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();

        public static void Seed()
        {
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

            foreach ( var g  in genres)
                _dbContext.Genres.Add(g);

            _dbContext.SaveChanges();
        }
    }
}