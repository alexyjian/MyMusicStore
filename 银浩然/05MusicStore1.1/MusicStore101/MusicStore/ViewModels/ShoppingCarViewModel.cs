using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStoreEntity;

namespace MusicStore.ViewModels
{
    public class ShoppingCarViewModel
    {
        //所有的购物项
        public List<Cart> CartItems { get; set; }

        //总价
        public decimal CarTotalPrice { get; set; }
    }
}