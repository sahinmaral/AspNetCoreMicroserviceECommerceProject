using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICatalogApi _catalogApi;
        public ProductsController(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }

        public async Task<IActionResult> IndexAsync([FromQuery(Name = "categoryId")] string? categoryId)
        {
            try
            {
                if(categoryId is null)
                {
                    var products = await _catalogApi.GetProducts();
                    return View(products);
                }
                else
                {
                    var productsByCategory = await _catalogApi.GetProductsByCategoryId(categoryId);
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
        public IActionResult Detail(string id)
        {
            return View();
        }
    }
}
