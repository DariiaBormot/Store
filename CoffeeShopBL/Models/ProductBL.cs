﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopBL.Models
{
    public class ProductBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        public ProductTypeBL ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public CategoryBL Category { get; set; }
        public int CategoryId { get; set; }
    }
}
