using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.ProductDetail;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;
using Refit;

using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;
        private readonly IProductService _productService;
        public ProductDetailController(IProductService productService, IProductDetailService productDetailService)
        {
            _productService = productService;
            _productDetailService = productDetailService;
        }

        [Route("admin/product/detail/{productId}")]
        public async Task<IActionResult> CreateOrUpdateProductDetail(string productId)
        {
            try
            {
                var productDetail = await _productDetailService.GetByProductId(productId);
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
                var product = await _productService.GetByIdAsync(model.ProductId);
                if (product is null)
                {
                    ModelState.AddModelError(string.Empty, $"Böyle bir ürün bulunamaktadır.");
                    return View(model);
                }

                await _productDetailService.CreateAsync(model);
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
                var product = await _productService.GetByIdAsync(model.ProductId);
                if (product is null)
                {
                    ModelState.AddModelError(string.Empty, $"Böyle bir ürün bulunamaktadır.");
                    return View(model);
                }

                await _productDetailService.UpdateAsync(model);
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
                var productDetail = await _productDetailService.GetByProductId(productId);
                await _productDetailService.DeleteAsync(productDetail.Id);
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
