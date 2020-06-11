using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        public async Task<ActionResult<IEnumerable<ProductData>>> GetProducts()
        {
            var tempTestValue = new ProductFilterModelData();
            var testfilter = _mapper.Map<ProductFilterModelBL>(tempTestValue);

            var products = await _productService.GetListByFilter(testfilter);

            var productsData = _mapper.Map<IEnumerable<ProductData>>(products);

            return Ok(productsData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductData>> GetProduct(int id)
        {
            var product = await _productService.GetById(id);

            var productData = _mapper.Map<ProductData>(product);

            return Ok(productData);
        }
    }
}