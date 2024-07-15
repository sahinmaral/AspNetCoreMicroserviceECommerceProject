using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents
{
    public class HomepageSpecialOfferViewComponent : ViewComponent
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public HomepageSpecialOfferViewComponent(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var offerDiscounts = await _offerDiscountService.GetAllAsync();
                return View(offerDiscounts);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"İndirim fırsatlarını getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
