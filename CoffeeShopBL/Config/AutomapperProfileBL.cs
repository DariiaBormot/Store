using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CoffeeShopBL.Models;
using CoffeeShopDAL.Entities;
using CoffeeShopDAL.Filters.FilterModels;

namespace CoffeeShopBL.Config
{
    public class AutomapperProfileBL : Profile
    {
        public AutomapperProfileBL()
        {
            CreateMap<CategoryBL, Category>().ReverseMap();
            CreateMap<ProductTypeBL, ProductType>().ReverseMap();
            CreateMap<ProductBL, Product>().ReverseMap();
            CreateMap<ProductFilterModelBL, ProductFilterModel>().ReverseMap();

        }
    }
}
