using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> IndexAsync([FromQuery(Name = "categoryId")] string? categoryId)
        {
            try
            {
                if(categoryId is null)
                {
                    var products = await _productService.GetAllAsync();
                    return View(products);
                }
                else
                {
                    var productsByCategory = await _productService.GetAllByCategoryId(categoryId);
                    return View(productsByCategory);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünleri getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }

        [Route("products/{id}")]
        public async Task<IActionResult> DetailAsync(string id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                return View(product);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünü getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
