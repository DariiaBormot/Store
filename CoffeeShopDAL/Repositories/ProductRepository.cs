using CoffeeShopDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopDAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(CoffeeShopContext ctx) : base(ctx) { }

    }
}
