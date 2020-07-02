using CoffeeShopDAL.Entities;
using CoffeeShopDAL.Filters.FilterModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopDAL.Filters.FilterImplementations
{
    public class ProductFilterCountProducts : BaseFilter<Product>
    {
        public ProductFilterCountProducts(ProductFilterModel filter)
         : base(x =>
             (string.IsNullOrEmpty(filter.Search) || x.Name.ToLower().Contains(filter.Search)) &&
             (!filter.CategoryId.HasValue || x.CategoryId == filter.CategoryId) &&
             (!filter.TypeId.HasValue || x.ProductTypeId == filter.TypeId)
         )
        { }

    }
}
