using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
  public  class Cart
    {
         public Guid ID{get;set;}
        public string CartID { get; set; }//购物车内部编号
        public int Count { get; set; }//专辑数量
        public DateTime CartDate { get; set; } //购物时间
        public virtual Albun Album { get; set; } //关联专辑
        public string AlbumID { get; set; }   //便于前段编程 
        public virtual Person Person { get; set; } //关联用户

        public Cart()
        {
            ID = Guid.NewGuid();
            CartDate = DateTime.Now;
        }
    }
}
