using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.OfferDiscount;
using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferDiscountController : Controller
    {
        private readonly ICatalogApi _catalogApi;

        public OfferDiscountController(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var specialOffers = await _catalogApi.GetOfferDiscounts();
                return View(specialOffers);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"İndirim fırsatları getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOfferDiscountDto model)
        {
            try
            {
                await _catalogApi.CreateOfferDiscount(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"İndirim fırsatı eklerken hata oluştu: {ex.Message}");
                return View(model);
            }   
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _catalogApi.DeleteOfferDiscount(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"İndirim fırsatı silerken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            try
            {
                var specialOffer = await _catalogApi.GetOfferDiscountById(id);
                return View(specialOffer);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"İndirim fırsatı getirirken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResultOfferDiscountDto model)
        {
            try
            {
                await _catalogApi.UpdateOfferDiscount(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"İndirim fırsatı güncellerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }
    }
}
