using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 订单明细
    /// </summary>
    public class OrderDetail
    {
        public Guid ID { get; set; }
        public string AlbumID { get; set; }   //专辑的ID
        public virtual Album Album { get; set; }  //专辑
        public  decimal Price { get; set; }
        public  int Count { get; set; }

        public OrderDetail()
        {
            ID = Guid.NewGuid();
        }
    }
}
