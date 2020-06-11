using CoffeeShopDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopDAL.Repositories
{
    public class ProductTypeRepository : GenericRepository<ProductType>
    {
        public ProductTypeRepository(CoffeeShopContext ctx) : base(ctx) { }
    }

}
