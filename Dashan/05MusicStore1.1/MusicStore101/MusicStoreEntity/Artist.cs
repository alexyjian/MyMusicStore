using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{

    //歌手
  public   class Artist
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; } = true;
        public string Description { get; set; }

        //包含分类的专辑
        public virtual ICollection<Album> Albums { get; set; }
        public Artist()
        {
            ID = Guid.NewGuid();
        }
    }
}
