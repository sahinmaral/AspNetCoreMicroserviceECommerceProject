using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using MultiShop.WebUI.Dtos.Product;
using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ICatalogApi _catalogApi;

        public ProductController(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }

        [HttpGet("admin/product/category/{id}")]
        public async Task<IActionResult> GetAllByCategoryId(string id)
        {
            try
            {
                var category = await _catalogApi.GetCategoryById(id);
                var products = await _catalogApi.GetProductsByCategoryId(id);

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
                var products = await _catalogApi.GetProducts();
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
                var categories = await _catalogApi.GetCategories();
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
                await _catalogApi.CreateProduct(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünü eklerken hata oluştu: {ex.Message}");
                var categories = await _catalogApi.GetCategories();
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
                await _catalogApi.DeleteProduct(id);

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
                var product = await _catalogApi.GetProductById(id);
                var categories = await _catalogApi.GetCategories();
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
                await _catalogApi.UpdateProduct(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünü güncellerken hata oluştu: {ex.Message}");
                var categories = await _catalogApi.GetCategories();
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
