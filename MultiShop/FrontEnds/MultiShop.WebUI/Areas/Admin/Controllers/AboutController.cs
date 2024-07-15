using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.About;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var abouts = await _aboutService.GetAllAsync();
                return View(abouts);
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
                await _aboutService.CreateAsync(model);

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
                await _aboutService.DeleteAsync(id);

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
                var about = await _aboutService.GetByIdAsync(id);
                return View(about);
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
                await _aboutService.UpdateAsync(model);

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
