using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class OrderViewModel
    {
        public List<Order> CartItems { get; set; }
        public decimal CartTotalPrice { get; set; }
    }
}