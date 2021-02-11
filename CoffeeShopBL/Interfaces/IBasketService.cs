using CoffeeShopBL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopBL.Interfaces
{
    public interface IBasketService
    {
        Task<CustomerBasketBL> GetBasketAsync(string basketId);
        Task<CustomerBasketBL> UpdateBasketAsync(CustomerBasketBL basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
