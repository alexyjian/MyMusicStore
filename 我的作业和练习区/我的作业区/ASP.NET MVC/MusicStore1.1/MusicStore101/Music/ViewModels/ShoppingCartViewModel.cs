using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStoreEntity;

namespace Music.ViewModels
{
    /// <summary>
    /// 购物车的视图模型
    /// </summary>
    public class ShoppingCartViewModel
    {
        //所有购物项
        public List<Cart> CartItems { get;set; }
        //总价
        public decimal CartTotaLPrice { get; set; }
        

    }
}