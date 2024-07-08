using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.ViewComponents
{
    public class LayoutNavbarCategoriesViewComponent: ViewComponent
    {
        private readonly ICatalogApi _catalogApi;

        public LayoutNavbarCategoriesViewComponent(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var categories = await _catalogApi.GetCategories();
                return View(categories);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Kategorileri getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
