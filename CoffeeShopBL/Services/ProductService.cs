using CofeeShopDAL;
using CofeeShopDAL.Interfaces;
using CofeeShopDAL.Repositories;
using CoffeeShopBL.Interfaces;
using CoffeeShopBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopBL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository) 
        {
            _repository = repository;
        }


        public async Task<IEnumerable<ProductBL>> GetAll()
        {

            var products = await _repository.GetAll();

            var result = products.Select(x => new ProductBL
            {
                Id = x.Id,
                Name = x.Name
            });
            return result;
        }

        public async Task<ProductBL> GetById(int id)
        {
            var product = await _repository.GetById(id);

            var result =  new ProductBL
            {
                Id = product.Id,
                Name = product.Name
            };

            return result;
        }
    }
}
