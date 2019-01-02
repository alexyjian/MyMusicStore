using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        //所有购物车项
        public List<Cart> CarItems { get; set; }
        //总价
        public decimal CartTotaIprice { get; set; }
    }
}