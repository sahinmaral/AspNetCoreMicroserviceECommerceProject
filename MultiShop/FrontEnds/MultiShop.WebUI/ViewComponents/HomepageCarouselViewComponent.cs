using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.ViewComponents
{
    public class HomepageCarouselViewComponent : ViewComponent
    {
        private readonly ICatalogApi _catalogApi;

        public HomepageCarouselViewComponent(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var featureSliders = (await _catalogApi.GetFeatureSliders()).Where((featureSlider) => featureSlider.Status).ToList();
                return View(featureSliders);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Öne çıkan görselleri getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
