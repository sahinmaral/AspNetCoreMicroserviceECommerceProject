using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.ViewComponents
{
    public class HomepageShopFeatureViewComponent : ViewComponent
    {
        private readonly ICatalogApi _catalogApi;

        public HomepageShopFeatureViewComponent(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var customerServices = await _catalogApi.GetCustomerServices();
                return View(customerServices);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Müşteri hizmetlerini getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
