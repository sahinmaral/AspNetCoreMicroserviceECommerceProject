using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Category;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                return View(categories);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Kategorileri getirirken hata oluştu: {ex.Message}");
                return View(new List<ResultCategoryDto>());
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto model)
        {
            try
            {
                await _categoryService.CreateAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Kategoriyi eklerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Kategoriyi silerken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                return View(category);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Kategoriyi getirirken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResultCategoryDto model)
        {
            try
            {
                await _categoryService.UpdateAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Kategoriyi güncellerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }
    }
}
