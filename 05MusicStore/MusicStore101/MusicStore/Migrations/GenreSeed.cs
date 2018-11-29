using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class GenreSeed
    {
        private static readonly MusicStoreEntity.MusicContext dbContext = new MusicStoreEntity.MusicContext();

        public static void Seed()
        {
            dbContext.Database.ExecuteSqlCommand("delete genres");
            var genres=new List<Genre>()
            {
            new Genre() { Name = "DJ",Description="DJ" },
             new Genre() { Name = "慢摇",Description="DownTempo" },
             new Genre() { Name = "重金属",Description="Metal" },
             new Genre() { Name = "嘻哈",Description="HiHop" },
             new Genre() { Name = "蓝调" ,Description="Blue"},
             new Genre() { Name = "拉丁" ,Description="Latin"},
             new Genre() { Name = "流行" ,Description="Pop"},
             new Genre() { Name = "古典" ,Description="Classical"},
             new Genre() { Name = "摇滚",Description="Rook" },
             new Genre() { Name = "爵士",Description="Jazz" }
        };
            foreach (var g in genres)
                dbContext.Genres.Add(g);
            dbContext.SaveChanges();
        }
    }
}