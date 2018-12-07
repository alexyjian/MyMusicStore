using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    //购物车的实体
    public class Cart
    {
        public Guid ID { get; set; }
        public string CartID { get; set; }//购物车内部编号
        public int Count { get; set; }//专辑的数量
        public DateTime CreateDate { get; set; }

        public virtual Album Album { get; set; }//关联专辑
        public string AlbumID { get; set; }//便于前端编程
        public virtual Person Person { get; set; }//关联用户

        public Cart()
        {
            ID = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }
    }
}
