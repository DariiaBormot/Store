using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoffeeShopAPI.Models;
using CoffeeShopBL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeService _typeService;
        private readonly IMapper _mapper;

        public ProductTypesController(IProductTypeService typeService, IMapper mapper)
        {
            _typeService = typeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTypeData>>> GetTypes()
        {
            var types = await _typeService.GetAll();

            var typesData = _mapper.Map<IEnumerable<ProductTypeData>>(types);

            return Ok(typesData);
        }

    }
}