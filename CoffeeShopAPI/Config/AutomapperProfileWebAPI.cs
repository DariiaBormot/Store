using AutoMapper;
using CoffeeShopAPI.Models;
using CoffeeShopBL.Models;


namespace CoffeeShopAPI.Config
{
    public class AutomapperProfileWebAPI : Profile
    {
        public AutomapperProfileWebAPI()
        {
            CreateMap<CategoryData, CategoryBL>().ReverseMap();
            CreateMap<ProductTypeData, ProductTypeBL>().ReverseMap();
            CreateMap<ProductBL, ProductData>()
                .ForMember(x => x.Category, c => c.MapFrom(s => s.Category.Name))
                .ForMember(x => x.ProductType, c => c.MapFrom(s => s.ProductType.Name));

            CreateMap<ProductFilterModelData, ProductFilterModelBL>().ReverseMap();
            CreateMap<CustomerBasketData, CustomerBasketBL>().ReverseMap();
            CreateMap<BasketItemData, BasketItemBL>().ReverseMap();
        }
    }
}
