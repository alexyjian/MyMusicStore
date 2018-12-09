using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Controllers
{
    /// <summary>
    /// 购物车视图模型
    /// </summary>
    public class ShoppingCartViewModel
    {
        //购物车项
        public List<Cart> CartItems { get; set; }
        //购物车总价
        public decimal CartTotalPrice { get; set; }
    }
}