using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
   public class Artist
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        public string Description { get; set; }
        //当前分类包含的专辑
        public virtual ICollection<Album> Albums { get; set; }

        public Artist()
        {
            ID = Guid.NewGuid();
        }
    }
}
