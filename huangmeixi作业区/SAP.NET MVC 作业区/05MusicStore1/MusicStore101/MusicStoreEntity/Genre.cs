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

        public Guid ID { get; set; }
        public string Name { get; set; }//名字
        public string Description { get; set; }//描述
        
        public  virtual ICollection<Album> Albums { get; set; }//当前分类包含的专辑

        public Genre()
        {
            ID = Guid.NewGuid();
        }
    }
}