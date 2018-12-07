using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStoreEntity.UserAndRole;

namespace MusicStoreEntity
{
    /// <summary>
    /// 购物车的实体
    /// </summary>
   public class Cart
    {
        public Guid ID { get; set; }

        //编号
        public string CartID { get; set; }
        //专辑的数量
        public int Count { get; set; }
        public DateTime CreateDate { get; set; }

        //关联专辑
        public virtual Ablum Ablum { get; set; }
        //便于前端编程
        public string AblumID { get; set; }
        //关联用户
        public virtual Person Person { get; set; }

        public Cart()
        {
            ID=Guid.NewGuid();
            CreateDate=DateTime.Now;
        }
    }
}
