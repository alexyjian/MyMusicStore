using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewsModel
{
    /// <summary>
    /// 购物车的视图模型
    /// </summary>
    public class ShoppingCartVIewModel
    {
        //所有购物车项
        public List<Cart> CartItems { get; set; }
        //总价
        public decimal CartTotalPrice { get; set; }
    }
}