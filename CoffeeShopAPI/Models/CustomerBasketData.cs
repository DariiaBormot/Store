using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopAPI.Models
{
    public class CustomerBasketData
    {
        public CustomerBasketData() { }
        public CustomerBasketData(string id) 
        {
            Id = id;
        }

        [Required]
        public string Id { get; set; }
        public List<BasketItemData> Items { get; set; }
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
        public decimal ShippingPrice { get; set; }
    }
}
