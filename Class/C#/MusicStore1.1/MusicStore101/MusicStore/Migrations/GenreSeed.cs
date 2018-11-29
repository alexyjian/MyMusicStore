
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class GenreSeed
    {
        private static readonly EntityDbContext _dbContext = new EntityDbContext();

        public static void Seed()
        {
            var genres = new List<Genre>()
            {
                new Genre() { Name = "摇滚"},
                new Genre() { Name = "爵士"},
                new Genre() { Name = "重金属"},
                new Genre() { Name = "慢摇"},
                new Genre() { Name = "蓝调"},
                new Genre() { Name = "拉丁"},
                new Genre() { Name = "流行"},
                new Genre() { Name = "古典"},
                new Genre() { Name = "DJ"},
                new Genre() { Name = "嘻哈"},
            };
            foreach (var g in genres)
            {
                _dbContext.Genres.Add(g);
            }
            _dbContext.SaveChanges();
        }
    }
}