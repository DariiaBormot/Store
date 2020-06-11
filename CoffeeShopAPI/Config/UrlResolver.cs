using AutoMapper;
using CoffeeShopAPI.Models;
using CoffeeShopBL.Models;
using Microsoft.Extensions.Configuration;

namespace CoffeeShopAPI.Config
{
    public class UrlResolver : IValueResolver<ProductBL, ProductData, string>
    {
        private readonly IConfiguration _config;

        public UrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(ProductBL source, ProductData destination, string destMember, ResolutionContext context)
        {
            if(string.IsNullOrEmpty(source.Image))
            {
                return _config["ApiURL"] + source.Image;
            }
            return null;
        }
    }
}
