using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.SpecialOffer;
using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialOfferController : Controller
    {
        private readonly ICatalogApi _catalogApi;

        public SpecialOfferController(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }

        public async Task<IActionResult> Index()
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSpecialOfferDto model)
        {
            try
            {
                await _catalogApi.CreateSpecialOffer(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Özel fırsatı eklerken hata oluştu: {ex.Message}");
                return View(model);
            }   
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _catalogApi.DeleteSpecialOffer(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Özel fırsatı silerken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            try
            {
                var specialOffer = await _catalogApi.GetSpecialOfferById(id);
                return View(specialOffer);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Özel fırsatı getirirken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResultSpecialOfferDto model)
        {
            try
            {
                await _catalogApi.UpdateSpecialOffer(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Özel fırsatı güncellerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }
    }
}
