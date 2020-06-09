using AutoMapper;
using CoffeeShop.Models;
using CoffeeShopBL.Models;

namespace CoffeeShop.Config
{
    public class AutomapperProfileWeb : Profile
    {
        public AutomapperProfileWeb()
        {
            CreateMap<CategoryViewModel, CategoryBL>().ReverseMap();
            CreateMap<ProductTypeViewModel, ProductTypeBL>().ReverseMap();
            CreateMap<ProductViewModel, ProductBL>().ReverseMap();
        }

    }
}
