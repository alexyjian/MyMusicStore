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
                new Genre(){Name="摇  滚",Description="Rock"     },
                new Genre(){Name="爵  士",Description="Jazz"     },
                new Genre(){Name="重金属",Description="Meta"     },
                new Genre(){Name="慢  摇",Description="DownTempo"},
                new Genre(){Name="蓝  调",Description="Blue"     },
                new Genre(){Name="拉  丁",Description="Latin"    },
                new Genre(){Name="流  行",Description="Pop"      },
                new Genre(){Name="古  典",Description="Classical"},
                new Genre(){Name="D    J",Description="DJ"       },
                new Genre(){Name="嘻  哈",Description="HiHop"    },
            };
            foreach (var g in genres)
                _dbContext.Genres.Add(g);
            _dbContext.SaveChanges();
        }
    }
}