using CoffeeShopBL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopBL.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductBL>> GetAll();
        Task<ProductBL> GetById(int id);
    }
}
