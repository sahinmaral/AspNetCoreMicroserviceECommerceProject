using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services.ExternalApiServices.Basket.Abstract;

namespace MultiShop.WebUI.ViewComponents
{
    public class LayoutNavbarShoppingCartViewComponent : ViewComponent
    {
        private readonly IBasketService _basketService;

        public LayoutNavbarShoppingCartViewComponent(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var currentBasket = await _basketService.GetBasket();
                if (currentBasket is null)
                    return View(0);
                return View(currentBasket.BasketItems.Sum(x => x.Quantity));
            }
            catch (Exception)
            {
                return View(0);
            }
        }
    }
}
