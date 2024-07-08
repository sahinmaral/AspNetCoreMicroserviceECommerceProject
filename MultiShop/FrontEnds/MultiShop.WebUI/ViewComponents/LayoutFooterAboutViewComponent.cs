using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.ViewComponents
{
    public class LayoutFooterAboutViewComponent: ViewComponent
    {
        private readonly ICatalogApi _catalogApi;

        public LayoutFooterAboutViewComponent(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var abouts = await _catalogApi.GetAbouts();
                return View(abouts);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Hakkındaları getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
