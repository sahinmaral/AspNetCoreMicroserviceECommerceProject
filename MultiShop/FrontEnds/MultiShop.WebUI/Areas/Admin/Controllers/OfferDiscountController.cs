using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.OfferDiscount;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var offerDiscounts = await _offerDiscountService.GetAllAsync();
                return View(offerDiscounts);
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
                await _offerDiscountService.CreateAsync(model);
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
                await _offerDiscountService.DeleteAsync(id);

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
                var offerDiscount = await _offerDiscountService.GetByIdAsync(id);
                return View(offerDiscount);
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
                await _offerDiscountService.UpdateAsync(model);

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
