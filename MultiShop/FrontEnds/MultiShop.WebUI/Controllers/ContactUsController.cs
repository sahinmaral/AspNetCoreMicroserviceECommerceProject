using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Contact;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactUsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [Route("/contact-us")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactAsync(CreateContactDto dto)
        {
            try
            {
                await _contactService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Mesajınızı gönderirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
