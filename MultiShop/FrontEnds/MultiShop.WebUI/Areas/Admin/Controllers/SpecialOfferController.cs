using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.SpecialOffer;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var specialOffers = await _specialOfferService.GetAllAsync();
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
                await _specialOfferService.CreateAsync(model);
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
                await _specialOfferService.DeleteAsync(id);

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
                var specialOffer = await _specialOfferService.GetByIdAsync(id);
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
                await _specialOfferService.UpdateAsync(model);

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
