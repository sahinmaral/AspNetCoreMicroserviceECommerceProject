using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents
{
    public class HomepageCarouselViewComponent : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public HomepageCarouselViewComponent(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var featureSliders = (await _featureSliderService.GetAllAsync()).Where((featureSlider) => featureSlider.Status).ToList();
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
