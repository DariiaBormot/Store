using CoffeeShopDAL.Entities;
using CoffeeShopDAL.Filters.FilterModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopDAL.Filters.FilterImplementations
{
    public class ProductFilter : BaseFilter<Product>
    {
        public ProductFilter(ProductFilterModel filter)
           : base(x =>
               (string.IsNullOrEmpty(filter.Search) || x.Name.ToLower().Contains(filter.Search)) &&
               (!filter.CategoryId.HasValue || x.CategoryId == filter.CategoryId) &&
               (!filter.TypeId.HasValue || x.ProductTypeId == filter.TypeId)
           )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.Category);
            AddOrderBy(x => x.Name);
            ApplyPaging(filter.PageSize * (filter.PageIndex - 1), filter.PageSize);

            if (!string.IsNullOrEmpty(filter.Sort))
            {
                switch (filter.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductFilter(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.Category);
        }
    }
}
