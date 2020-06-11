using AutoMapper;
using CoffeeShopBL.Interfaces;
using CoffeeShopBL.Models;
using CoffeeShopDAL.Entities;
using CoffeeShopDAL.Filters.FilterImplementations;
using CoffeeShopDAL.Filters.FilterModels;
using CoffeeShopDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopBL.Services
{
    public class ProductService : GenericService<ProductBL, Product>, IProductService
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductBL>> GetListByFilter(ProductFilterModelBL filter) 
        {
            var filterModel = _mapper.Map<ProductFilterModel>(filter);
            var filterDAL = new ProductFilter(filterModel);
            var productsDAL = await _repository.GetListByFilter(filterDAL);
            var productsBL = _mapper.Map<IEnumerable<ProductBL>>(productsDAL);
            return productsBL;
        }

        public async Task<ProductBL> GetItemByFilter(ProductFilterModelBL filter)
        {
            var filterModel = _mapper.Map<ProductFilterModel>(filter);
            var filterDAL = new ProductFilter(filterModel);
            var productDAL = await _repository.GetEntityByFilter(filterDAL);
            var productBL = _mapper.Map<ProductBL>(productDAL);
            return productBL;
        }

        public override ProductBL Map(Product entity)
        {
            return _mapper.Map<ProductBL>(entity);
        }

        public override Product Map(ProductBL blmodel)
        {
            return _mapper.Map<Product>(blmodel);
        }

        public override IEnumerable<ProductBL> Map(IList<Product> entities)
        {
            return _mapper.Map<IEnumerable<ProductBL>>(entities);
        }

        public override IEnumerable<Product> Map(IList<ProductBL> models)
        {
            return _mapper.Map<IEnumerable<Product>>(models);
        }
    }
}
