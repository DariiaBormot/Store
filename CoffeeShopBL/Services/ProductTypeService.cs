using AutoMapper;
using CoffeeShopBL.Interfaces;
using CoffeeShopBL.Models;
using CoffeeShopDAL.Entities;
using CoffeeShopDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopBL.Services
{
    public class ProductTypeService : GenericService<ProductTypeBL, ProductType>, IProductTypeService
    {
        private readonly IMapper _mapper;

        public ProductTypeService(IGenericRepository<ProductType> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public override ProductTypeBL Map(ProductType entity)
        {
            return _mapper.Map<ProductTypeBL>(entity);
        }

        public override ProductType Map(ProductTypeBL blmodel)
        {
            return _mapper.Map<ProductType>(blmodel);
        }

        public override IEnumerable<ProductTypeBL> Map(IList<ProductType> entities)
        {
            return _mapper.Map<IEnumerable<ProductTypeBL>>(entities);
        }

        public override IEnumerable<ProductType> Map(IList<ProductTypeBL> models)
        {
            return _mapper.Map<IEnumerable<ProductType>>(models);
        }
    }
}
