using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents
{
    public class HomepageBrandsViewComponent : ViewComponent
    {
        private readonly IBrandService _brandService;

        public HomepageBrandsViewComponent(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var brands = await _brandService.GetAllAsync();
                return View(brands);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Markaları getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
