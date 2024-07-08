using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.CustomerService;
using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerServiceController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICatalogApi _catalogApi;

        public CustomerServiceController(IWebHostEnvironment webHostEnvironment, ICatalogApi catalogApi)
        {
            _webHostEnvironment = webHostEnvironment;
            _catalogApi = catalogApi;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var customerServices = await _catalogApi.GetCustomerServices();
                return View(customerServices);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Müşteri hizmetlerini getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCustomerServiceDto model)
        {
            try
            {
                await _catalogApi.CreateCustomerService(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Müşteri hizmetini eklerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _catalogApi.DeleteCustomerService(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Müşteri hizmetini silerken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            try
            {
                var customerService = await _catalogApi.GetCustomerServiceById(id);
                return View(customerService);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Müşteri hizmetini getirirken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResultCustomerServiceDto model)
        {
            try
            {
                await _catalogApi.UpdateCustomerService(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Müşteri hizmetini güncellerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }
    }
}
