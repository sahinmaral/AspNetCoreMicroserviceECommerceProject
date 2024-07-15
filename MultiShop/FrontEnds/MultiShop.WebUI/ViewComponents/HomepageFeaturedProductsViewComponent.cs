using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents
{
    public class HomepageFeaturedProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public HomepageFeaturedProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
