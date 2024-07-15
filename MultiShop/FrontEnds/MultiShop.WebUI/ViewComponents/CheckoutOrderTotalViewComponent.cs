using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services.ExternalApiServices.Basket.Abstract;

namespace MultiShop.WebUI.ViewComponents
{
    public class CheckoutOrderTotalViewComponent : ViewComponent
    {
        private readonly IBasketService _basketService;

        public CheckoutOrderTotalViewComponent(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var currentBasket = await _basketService.GetBasket();
            return View(currentBasket);
        }
    }
}
