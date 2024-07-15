using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Brand;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var brands = await _brandService.GetAllAsync();
                return View(brands);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Markaları getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDto model)
        {
            try
            {
                await _brandService.CreateAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Markayı eklerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _brandService.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Markayı silerken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            try
            {
                var brand = await _brandService.GetByIdAsync(id);
                return View(brand);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Markayı getirirken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResultBrandDto model)
        {
            try
            {
                await _brandService.UpdateAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Markayı güncellerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }
    }
}
