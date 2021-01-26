using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
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
