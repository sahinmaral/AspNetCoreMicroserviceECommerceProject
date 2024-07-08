using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.ViewComponents
{
    public class HomepageBrandsViewComponent : ViewComponent
    {
        private readonly ICatalogApi _catalogApi;

        public HomepageBrandsViewComponent(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var brands = await _catalogApi.GetBrands();
                return View(brands);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Markaları getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
