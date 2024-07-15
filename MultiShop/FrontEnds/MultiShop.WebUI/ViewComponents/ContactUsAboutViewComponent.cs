using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents
{
    public class ContactUsAboutViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public ContactUsAboutViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var abouts = await _aboutService.GetAllAsync();
                return View(abouts);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Hakkındaları getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
