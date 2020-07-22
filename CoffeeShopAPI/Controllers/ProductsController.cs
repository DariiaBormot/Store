using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoffeeShopAPI.Errors;
using CoffeeShopAPI.Models;
using CoffeeShopBL.Interfaces;
using CoffeeShopBL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductData>>> GetProducts(
            [FromQuery]ProductFilterModelData filterData)
        {

            var filterBL = _mapper.Map<ProductFilterModelBL>(filterData);

            var products = await _productService.GetProductsByFilter(filterBL);

            var productsData = _mapper.Map<IEnumerable<ProductData>>(products);

            var countProducts = await _productService.GetProductsCount(filterBL);

            var productsToReturn = new Pagination<ProductData>
            {
                Count = countProducts,
                Data = productsData,
                PageIndex = filterData.PageIndex,
                PageSize = filterData.PageSize
            };

            return Ok(productsToReturn);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponce), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductData>> GetProduct(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null) return NotFound(new ApiResponce(404));

            var productData = _mapper.Map<ProductData>(product);

            return Ok(productData);
        }

    }
}