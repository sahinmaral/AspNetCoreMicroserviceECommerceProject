using MultiShop.Basket.Models;
using MultiShop.Basket.Services.Abstract;
using MultiShop.Basket.Settings;

using System.Text.Json;

namespace MultiShop.Basket.Services.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            var existedBasket = await _redisService.GetDatabase().StringGetAsync(userId);
            if (!existedBasket.HasValue)
                throw new NullReferenceException();
            await _redisService.GetDatabase().StringGetDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            var existedBasket = await _redisService.GetDatabase().StringGetAsync(userId);
            if (!existedBasket.HasValue)
                throw new NullReferenceException();
            return JsonSerializer.Deserialize<BasketTotalDto>(existedBasket);
        }

        public async Task<bool> SaveBasket(BasketTotalDto basketTotalDto)
        {
            var serializedBasketTotalDto = JsonSerializer.Serialize(basketTotalDto);
            return await _redisService.GetDatabase().StringSetAsync(basketTotalDto.UserId, serializedBasketTotalDto);
        }
    }
}
