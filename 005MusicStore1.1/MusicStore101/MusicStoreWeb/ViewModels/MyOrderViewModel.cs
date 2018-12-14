using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class MyOrderViewModel
    {
        public List<Cart> CartItems { get; set; }

        //总价
        public decimal CartTotalPrice { get; set; }
    }
}