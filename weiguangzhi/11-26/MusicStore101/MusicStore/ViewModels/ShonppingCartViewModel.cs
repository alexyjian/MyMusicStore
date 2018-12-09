using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class ShonppingCartViewModel
    {
        //所有的购物项
        public List<Cart> CartItems { get; set; }

        //总价
        public decimal CartTotalPrice { get; set; }
    }
}