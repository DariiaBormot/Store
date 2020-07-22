using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoffeeShopAPI.Models;
using CoffeeShopBL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryData>>> GetCategories()
        {

            var categories = await _categoryService.GetAll();

            var categoriesData = _mapper.Map<IEnumerable<CategoryData>>(categories);

            return Ok(categoriesData);
        }

    }
}
