using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents
{
    public class SpecialOfferViewComponent : ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferViewComponent(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var specialOffers = await _specialOfferService.GetAllAsync();
                return View(specialOffers);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Özel fırsatları getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
