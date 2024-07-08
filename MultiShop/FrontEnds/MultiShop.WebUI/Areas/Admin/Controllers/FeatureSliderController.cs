using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.FeatureSlider;
using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureSliderController : Controller
    {
        private readonly ICatalogApi _catalogApi;

        public FeatureSliderController(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var featureSliders = await _catalogApi.GetFeatureSliders();
                return View(featureSliders);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Öne çıkan görselleri getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureSliderDto model)
        {
            try
            {
                await _catalogApi.CreateFeatureSlider(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Öne çıkan görseli eklerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _catalogApi.DeleteFeatureSlider(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Öne çıkan görseli silerken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            try
            {
                var featureSlider = await _catalogApi.GetFeatureSliderById(id);
                return View(featureSlider);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Öne çıkan görseli getirirken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResultFeatureSliderDto model)
        {
            try
            {
                await _catalogApi.UpdateFeatureSlider(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Öne çıkan görseli güncellerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }
    }
}
