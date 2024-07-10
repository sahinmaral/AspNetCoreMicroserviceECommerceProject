using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.ProductDetail;
using MultiShop.WebUI.Services;

using Refit;

using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductDetailController : Controller
    {
        private readonly ICatalogApi _catalogApi;

        public ProductDetailController(ICatalogApi catalogApi)
        {
            _catalogApi = catalogApi;
        }

        [Route("admin/product/detail/{productId}")]
        public async Task<IActionResult> CreateOrUpdateProductDetail(string productId)
        {
            try
            {
                var productDetail = await _catalogApi.GetProductDetailByProductId(productId);
                return View("Update", new ResultProductDetailDto()
                {
                    ProductId = productId,
                    Id = productDetail.Id,
                    Description = productDetail.Description,
                    Information = productDetail.Information
                });
            }
            catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return View("Create", new CreateProductDetailDto()
                {
                    ProductId = productId
                });
            }
            catch (ApiException)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDetailDto model)
        {
            try
            {
                var product = await _catalogApi.GetProductById(model.ProductId);
                if (product is null)
                {
                    ModelState.AddModelError(string.Empty, $"Böyle bir ürün bulunamaktadır.");
                    return View(model);
                }

                await _catalogApi.CreateProductDetail(model);
                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünü güncellerken hata oluştu: {ex.Message}");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResultProductDetailDto model)
        {
            try
            {
                var product = await _catalogApi.GetProductById(model.ProductId);
                if (product is null)
                {
                    ModelState.AddModelError(string.Empty, $"Böyle bir ürün bulunamaktadır.");
                    return View(model);
                }

                await _catalogApi.UpdateProductDetail(model);
                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünü güncellerken hata oluştu: {ex.Message}");
                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string productId)
        {
            try
            {
                var productDetail = await _catalogApi.GetProductDetailByProductId(productId);
                await _catalogApi.DeleteProductDetail(productDetail.Id);
                return RedirectToAction("Index", "Product");
            }
            catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                ModelState.AddModelError(string.Empty, $"Bu ürüne ait herhangi bir ürün detayı bulunamaktadır.");
                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürünü silerken hata oluştu: {ex.Message}");
                return RedirectToAction("Index", "Product");
            }

        }
    }
}
