using MultiShop.WebUI.Dtos.Basket;

namespace MultiShop.WebUI.Services.ExternalApiServices.Basket.Abstract
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket();
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket();
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task RemoveBasketItem(string productId);
        Task RemoveAllBasketItem(string productId);
    }
}
