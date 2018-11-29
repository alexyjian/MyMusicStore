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
        }
    }

}