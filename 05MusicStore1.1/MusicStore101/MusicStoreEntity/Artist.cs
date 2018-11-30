using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 歌手
    /// </summary>
    public class Artist
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; } = true;
        public string Description { get; set; }

        public Artist()
        {
            ID = Guid.NewGuid();
        }
    }
}
