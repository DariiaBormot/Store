using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopBL.Models
{
    public class ProductFilterModelBL
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Sort { get; set; }
        public int? TypeId { get; set; }
        public int? CategoryId { get; set; }
        public string Search { get; set; }
    }
}
