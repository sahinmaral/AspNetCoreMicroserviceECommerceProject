using MultiShop.Basket.Models;

namespace MultiShop.Basket.Services.Abstract
{
    public interface IBasketService
    {
        Task<BasketTotalDto?> GetBasket(string userId);
        Task<bool> SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string userId);
    }
}
