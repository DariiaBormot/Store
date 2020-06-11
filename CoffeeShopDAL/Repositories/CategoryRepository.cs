using CoffeeShopDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopDAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(CoffeeShopContext ctx) : base(ctx) { }

    }
}
