using CoffeeShopBL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopBL.Interfaces
{
    public interface IProductService : IGenericService<ProductBL>
    {
        Task<IEnumerable<ProductBL>> GetListByFilter(ProductFilterModelBL filter);
        Task<ProductBL> GetItemByFilter(ProductFilterModelBL filter);
    }
}
