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
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketService(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
           var result = await _basketRepository.DeleteBasketAsync(basketId);
            return result;
        }

        public async Task<CustomerBasketBL> GetBasketAsync(string basketId)
        {
            var basketDAL = await _basketRepository.DeleteBasketAsync(basketId);
            var basketBL = _mapper.Map<CustomerBasketBL>(basketDAL);
            return basketBL;
        }

        public async Task<CustomerBasketBL> UpdateBasketAsync(CustomerBasketBL basket)
        {
            var basketDAL = _mapper.Map<CustomerBasket>(basket);
            var updatedBasketDAL =  await _basketRepository.UpdateBasketAsync(basketDAL);
            var updatedBasketBL = _mapper.Map<CustomerBasketBL>(updatedBasketDAL);
            return updatedBasketBL;
        }
    }
}
