using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 购物车实体
    /// </summary>
   public class Cart
    {
        public Guid ID{ get; set; }
        public string CartID { get; set; }
        public int Count { get; set; } = 1;  //专辑的数量
        public DateTime CreateDate { get; set; }
        public virtual Album Album { get; set; }
        public string AlbumID { get; set; }
        public virtual Person Person { get; set; }
        public Cart()
        {
            ID = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }

    }
}
