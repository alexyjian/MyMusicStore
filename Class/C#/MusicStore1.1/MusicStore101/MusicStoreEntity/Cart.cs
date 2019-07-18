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
        public Guid ID { get; set; }

        //购物车内部编号
        public string CartID { get; set; }

        //专辑数量
        public int Count { get; set; } = 1;

        public DateTime CreateDate { get; set; }

        //关键专辑
        public virtual Album Album { get; set; }

        //便于编程
        public string AlbumID { get; set; }

        //关联用户
        public virtual Person Person { get; set; }

        public Cart()
        {
            ID = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }
    }
}
