using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.About;
using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly ICatalogApi _catalogApi;

        public AboutController(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var brands = await _catalogApi.GetAbouts();
                return View(brands);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Hakkındaları getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto model)
        {
            try
            {
                await _catalogApi.CreateAbout(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Hakkındayı eklerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _catalogApi.DeleteAbout(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Hakkındayı silerken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            try
            {
                var category = await _catalogApi.GetAboutById(id);
                return View(category);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Hakkındayı getirirken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResultAboutDto model)
        {
            try
            {
                await _catalogApi.UpdateAbout(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Hakkındayı güncellerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }
    }
}
