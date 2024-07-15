using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.FeatureSlider;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var featureSliders = await _featureSliderService.GetAllAsync();
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
                await _featureSliderService.CreateAsync(model);

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
                await _featureSliderService.DeleteAsync(id);

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
                var featureSlider = await _featureSliderService.GetByIdAsync(id);
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
                await _featureSliderService.UpdateAsync(model);

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
