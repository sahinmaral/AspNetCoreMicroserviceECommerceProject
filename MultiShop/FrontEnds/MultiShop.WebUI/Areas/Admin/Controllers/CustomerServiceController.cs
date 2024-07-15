using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.CustomerService;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerServiceController : Controller
    {
        private readonly ICustomerServiceService _customerServiceService;

        public CustomerServiceController(ICustomerServiceService customerServiceService)
        {
            _customerServiceService = customerServiceService;
        }

        public async Task<IActionResult> Index()
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
                await _customerServiceService.CreateAsync(model);

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
                await _customerServiceService.DeleteAsync(id);

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
                var customerService = await _customerServiceService.GetByIdAsync(id);
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
                await _customerServiceService.UpdateAsync(model);

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
