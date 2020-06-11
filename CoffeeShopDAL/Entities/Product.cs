using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopDAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
