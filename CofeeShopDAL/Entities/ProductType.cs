using System;
using System.Collections.Generic;
using System.Text;

namespace CofeeShopDAL.Entities
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
