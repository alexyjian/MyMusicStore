using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 保存和点赞的实体
    /// </summary>
   public  class Like
    {
        public Guid ID { get; set; }
        public Reply Reply { get; set; }
        public bool IsNotLike { get; set; } //like 保存true ，hate 保存为false
        public virtual  Person Person { get; set; }
        public DateTime CreateDateTime { get; set; }
        public Like()
        {
            ID = Guid.NewGuid();
            CreateDateTime = DateTime.Now;
        }
    }
}
