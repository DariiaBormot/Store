using AutoMapper;
using CoffeeShopAPI.Models;
using CoffeeShopBL.Interfaces;
using CoffeeShopBL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoffeeShopAPI.Controllers
{
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _mapper = mapper;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasketData>> GetBasketById(string id)
        {
            var basketBL = await _basketService.GetBasketAsync(id);
            var basketData = basketBL == null ? new CustomerBasketData(id) : _mapper.Map<CustomerBasketData>(basketBL);

            return Ok(basketData);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasketData>> UpdateBasket(CustomerBasketData basket)
        {
            var customerBasketBL = _mapper.Map<CustomerBasketBL>(basket);
            var updatedBasketBL = await _basketService.UpdateBasketAsync(customerBasketBL);
            var updatedBasketData = _mapper.Map<CustomerBasketData>(updatedBasketBL);

            return Ok(updatedBasketData);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketService.DeleteBasketAsync(id);
        }
    }
}
