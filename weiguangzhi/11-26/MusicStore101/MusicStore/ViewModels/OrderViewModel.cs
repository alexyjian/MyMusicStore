using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class OrderViewModel
    {
        //所有的购物项
        public List<Order> orderItems { get; set; }

        //总价
        public decimal OrderTotalPrice { get; set; }

    }
}