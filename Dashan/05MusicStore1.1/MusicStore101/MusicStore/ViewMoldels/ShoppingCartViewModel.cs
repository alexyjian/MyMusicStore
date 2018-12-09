using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewMoldels
{
    /// <summary>
    /// 购物车的视图模型
    /// </summary>
    public class ShoppingCartViewModel
    {
        //所有的购物项
        public List<Cart> CartItems { get; set; }
        //总价格
        public decimal CartTotaPrice { get; set; }
    }
}