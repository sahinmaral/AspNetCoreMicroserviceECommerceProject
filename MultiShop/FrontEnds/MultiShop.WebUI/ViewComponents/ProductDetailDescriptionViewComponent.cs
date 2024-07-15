using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.ProductDetail;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;
using Refit;

using System.Net;

namespace MultiShop.WebUI.ViewComponents
{
    public class ProductDetailDescriptionViewComponent : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailDescriptionViewComponent(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            try
            {
                var productDetail = await _productDetailService.GetByProductId(productId);
                return View(productDetail);
            }
            catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return View(new ResultProductDetailDto());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürün detayını getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
