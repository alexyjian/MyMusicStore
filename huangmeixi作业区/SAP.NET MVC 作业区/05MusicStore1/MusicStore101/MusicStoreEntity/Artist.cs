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
   public  class Artist
    {
        public Guid ID { get; set;}

        public  string  Name { get; set; }

        public bool Sex { get; set; }

        public  string Description { get; set; }//货物名称

        //构造函数
        public Artist()
        {
            ID = Guid.NewGuid();
        }
    }
}
