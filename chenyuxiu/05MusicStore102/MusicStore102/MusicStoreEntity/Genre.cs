using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    public class Genre
    {
        //public object Genre;
        public object ArtistId;
        public object Genre;

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Decripon { get; set; }
        public object GenreId { get; set; }
        public object Artist { get; set; }

        public Genre()
        {
            ID = Guid.NewGuid();
        }
    }
}
    /// <summary>
    /// 音乐分类
    /// </summary>
  public class Genre
    {
        public string Description;

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public  virtual ICollection<Album>Albums { get; set; }

    public Genre()
    {
        ID = Guid.NewGuid();
    }
    }
