using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 分类
    /// </summary>
   public class Genre
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        //当前分类包含的专辑
        public virtual ICollection<Albun> Albun { get; set; }
        public Genre()
        {
            ID = Guid.NewGuid();
        }
    }
}
