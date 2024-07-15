using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents
{
    public class LayoutNavbarCategoriesViewComponent: ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public LayoutNavbarCategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                return View(categories);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Kategorileri getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
