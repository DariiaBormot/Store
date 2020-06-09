using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CofeeShopDAL.Entities;
using CoffeeShopBL.Models;

namespace CoffeeShopBL.Config
{
    public class AutomapperProfileBL : Profile
    {
        public AutomapperProfileBL()
        {
            CreateMap<CategoryBL, Category>().ReverseMap();
            CreateMap<ProductTypeBL, ProductType>().ReverseMap();
            CreateMap<ProductBL, Product>().ReverseMap();

        }
    }
}
