using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                new Genre() { Name="摇滚",Description="Rock"},
                new Genre() { Name="快乐",Description="kl"},
                new Genre() { Name="高兴",Description="gx"},
                new Genre() { Name="兴奋",Description="xf"}
            };
            foreach (var g in genres)
            {
                _dbContext.Genres.Add(g);
                _dbContext.SaveChanges();
            }
        }
    }
}