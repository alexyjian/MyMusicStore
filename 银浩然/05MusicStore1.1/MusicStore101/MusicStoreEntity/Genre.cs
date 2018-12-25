using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 音乐商店分类
    /// </summary>
   public class Genre
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public Genre()
        {
            ID = Guid.NewGuid();
        }
    }
}
