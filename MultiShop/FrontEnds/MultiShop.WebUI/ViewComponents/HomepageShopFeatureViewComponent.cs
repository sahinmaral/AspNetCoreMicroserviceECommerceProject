using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents
{
    public class HomepageShopFeatureViewComponent : ViewComponent
    {
        private readonly ICustomerServiceService _customerServiceService;

        public HomepageShopFeatureViewComponent(ICustomerServiceService customerServiceService)
        {
            _customerServiceService = customerServiceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var customerServices = await _customerServiceService.GetAllAsync();
                return View(customerServices);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Müşteri hizmetlerini getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
