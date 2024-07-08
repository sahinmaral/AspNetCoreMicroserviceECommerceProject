using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Brand;
using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly ICatalogApi _catalogApi;

        public BrandController(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var brands = await _catalogApi.GetBrands();
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
                await _catalogApi.CreateBrand(model);

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
                await _catalogApi.DeleteBrand(id);

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
                var category = await _catalogApi.GetBrandById(id);
                return View(category);
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
                await _catalogApi.UpdateBrand(model);

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
