using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Product;
using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImagesController : Controller
    {
        private readonly ICatalogApi _catalogApi;

        public ProductImagesController(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }

        [Route("admin/product/images/{productId}")]
        public async Task<IActionResult> AddOrUpdateProductImageOfProductAsync(string productId)
        {
            try
            {
                var product = await _catalogApi.GetProductById(productId);
                var productImages = new ResultProductImagesDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    AdditionalImageUrls = product.AdditionalImageUrls
                };

                if (product.AdditionalImageUrls.Count == 0)
                {
                    return View("Create", productImages);
                }
                else
                {
                    return View("Update", productImages);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünü getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ResultProductImagesDto model)
        {
            try
            {
                var product = await _catalogApi.GetProductById(model.Id);
                if(product is null)
                {
                    ModelState.AddModelError(string.Empty, $"Böyle bir ürün bulunamaktadır.");
                    return View(model);
                }

                await _catalogApi.AddProductImages(model);
                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünü güncellerken hata oluştu: {ex.Message}");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResultProductImagesDto model)
        {
            try
            {
                var product = await _catalogApi.GetProductById(model.Id);
                if (product is null)
                {
                    ModelState.AddModelError(string.Empty, $"Böyle bir ürün bulunamaktadır.");
                    return View(model);
                }

                if (model.AdditionalImageUrls is null)
                    model.AdditionalImageUrls = new List<string>();

                await _catalogApi.UpdateProductImages(model);
                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünü güncellerken hata oluştu: {ex.Message}");
                return View(model);
            }
        }
    }
}
