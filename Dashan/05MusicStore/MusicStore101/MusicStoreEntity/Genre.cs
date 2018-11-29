using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
   public class Genre
    {
        public Guid ID {get;set;}
        public String Name { get; set; }
        public String Description { get; set; }
        public Genre()
        {
            ID = Guid.NewGuid();
        }
    }
}
