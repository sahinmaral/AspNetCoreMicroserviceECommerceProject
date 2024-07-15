using MultiShop.WebUI.Dtos.Basket;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Basket.Services.Abstract
{
    public interface IBasketApi
    {
        [Get("/baskets")]
        Task<BasketTotalDto> GetBasket();
        [Delete("/baskets")]
        Task DeleteBasket();
        [Post("/baskets")]
        Task SaveBasket(BasketTotalDto model);
    }
}
