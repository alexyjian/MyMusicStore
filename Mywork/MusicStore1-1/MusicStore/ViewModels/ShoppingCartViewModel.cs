using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    /// <summary>
    /// 购物车视图模型
    /// </summary>
    public class ShoppingCartViewModel
    {
        //所有的购物项
        public List<Cart> CartItems { get; set; }

        //总价
        public decimal CartTotalPrice { get; set; }
    }

}