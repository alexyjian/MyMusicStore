using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 音乐分类
    /// </summary>
    public class Genre
    {
        public object GenreId;
        public readonly object Artist;

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //当前分类包含的专辑
        public virtual ICollection<Album> Albums { get; set; }
        public object ArtistId { get; set; }
        public object PublisherDate { get; set; }
        public object Genres { get; set; }

        //public object Genre { get; set; }

        public Genre()
        {
            ID = Guid.NewGuid();
        }
    }
}
