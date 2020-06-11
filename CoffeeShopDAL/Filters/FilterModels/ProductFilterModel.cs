using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopDAL.Filters.FilterModels
{
    public class ProductFilterModel
    {
        public int PageIndex { get; set; } 
        public int PageSize { get; set; }
        public string Sort { get; set; }
        public int? TypeId { get; set; }
        public int? CategoryId { get; set; }
        public string Search { get; set; }
    }
}
