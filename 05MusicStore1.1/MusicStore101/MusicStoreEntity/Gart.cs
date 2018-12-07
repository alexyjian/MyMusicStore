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
    public class Gart
    {
        public Guid ID { get; set; }
        public string CartID { get; set; }//
        public int Count { get; set; }

    }
}
