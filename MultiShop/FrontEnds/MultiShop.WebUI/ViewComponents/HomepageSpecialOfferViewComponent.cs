using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.ViewComponents
{
    public class HomepageSpecialOfferViewComponent : ViewComponent
    {
        private readonly ICatalogApi _catalogApi;

        public HomepageSpecialOfferViewComponent(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var offerDiscounts = await _catalogApi.GetOfferDiscounts();
                return View(offerDiscounts);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"İndirim fırsatlarını getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
