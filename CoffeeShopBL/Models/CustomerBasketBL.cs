using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopBL.Models
{
    public class CustomerBasketBL
    {
        public string Id { get; set; }
        public List<BasketItemBL> Items { get; set; }
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
        public decimal ShippingPrice { get; set; }
    }
}
