using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.ViewComponents
{
    public class SpecialOfferViewComponent : ViewComponent
    {
        private readonly ICatalogApi _catalogApi;

        public SpecialOfferViewComponent(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var specialOffers = await _catalogApi.GetSpecialOffers();
                return View(specialOffers);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Özel fırsatları getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
