using MultiShop.WebUI.Dtos.Basket;
using MultiShop.WebUI.Services.ExternalApiServices.Basket.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Basket.Services.Abstract;

namespace MultiShop.WebUI.Services.ExternalApiServices.Basket.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly IBasketApi _basketApi;

        public BasketService(IBasketApi basketApi)
        {
            _basketApi = basketApi;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var currentBasket = await GetBasket();
            if(currentBasket is null)
            {
                currentBasket = new BasketTotalDto();
                currentBasket.BasketItems.Add(basketItemDto);
            }
            else
            {
                var searchedBasketItem = currentBasket.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);
                if (searchedBasketItem is not null)
                {
                    searchedBasketItem.Quantity += 1;
                }
                else
                {
                    currentBasket.BasketItems.Add(basketItemDto);
                }
            }

            await SaveBasket(currentBasket);
        }

        public async Task DeleteBasket()
        {
            await _basketApi.DeleteBasket();
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            var currentBasket = await _basketApi.GetBasket();
            return currentBasket;
        }

        public async Task RemoveAllBasketItem(string productId)
        {
            var currentBasket = await GetBasket();
            var deletedItem = currentBasket.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            var result = currentBasket.BasketItems.Remove(deletedItem);

            await SaveBasket(currentBasket);
        }

        public async Task RemoveBasketItem(string productId)
        {
            var currentBasket = await GetBasket();
            var deletedItem = currentBasket.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            deletedItem.Quantity--;

            await SaveBasket(currentBasket);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _basketApi.SaveBasket(basketTotalDto);
        }
    }
}
