using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using MultiShop.WebUI.Dtos.Product;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet("admin/product/category/{id}")]
        public async Task<IActionResult> GetAllByCategoryId(string id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                var products = await _productService.GetAllByCategoryId(id);

                return View(new ResultProductsWithCategoryDto
                {
                    Category = category,
                    Products = products
                });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünleri getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                return View(products);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünleri getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                ViewBag.Categories = categories.Select((category) => new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id
                });

                return View(new CreateProductDto());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Kategorileri getirirken hata oluştu: {ex.Message}");
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto model)
        {
            try
            {
                await _productService.CreateAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünü eklerken hata oluştu: {ex.Message}");
                var categories = await _categoryService.GetAllAsync();
                ViewBag.Categories = categories.Select((category) => new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id
                });
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _productService.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünü silerken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                var categories = await _categoryService.GetAllAsync();
                ViewBag.Categories = categories.Select((category) => new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id
                });
                return View(product);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünü getirirken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResultProductDto model)
        {
            try
            {
                await _productService.UpdateAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünü güncellerken hata oluştu: {ex.Message}");
                var categories = await _categoryService.GetAllAsync();
                ViewBag.Categories = categories.Select((category) => new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id
                });
                return View(model);
            }
        }
    }
}
