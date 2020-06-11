using AutoMapper;
using CoffeeShopBL.Interfaces;
using CoffeeShopBL.Models;
using CoffeeShopDAL.Entities;
using CoffeeShopDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopBL.Services
{
    public class CategoryService : GenericService<CategoryBL, Category>, ICategoryService
    {
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IMapper mapper) : base (repository)
        {
            _mapper = mapper;
        }

        public override CategoryBL Map(Category entity)
        {
            return _mapper.Map<CategoryBL>(entity);
        }

        public override Category Map(CategoryBL blmodel)
        {
            return _mapper.Map<Category>(blmodel);
        }

        public override IEnumerable<CategoryBL> Map(IList<Category> entities)
        {
            return _mapper.Map<IEnumerable<CategoryBL>>(entities);
        }

        public override IEnumerable<Category> Map(IList<CategoryBL> models)
        {
            return _mapper.Map<IEnumerable<Category>>(models);
        }
    }
}
