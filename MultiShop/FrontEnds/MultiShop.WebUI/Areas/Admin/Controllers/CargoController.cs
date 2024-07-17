using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Cargo;
using MultiShop.WebUI.Services.ExternalApiServices.Cargo.Abstract;

using System.Reflection;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet("/admin/cargo/company")]
        public IActionResult GetAllCargoCompanies()
        {
            var cargoCompanies = _cargoCompanyService.GetAllAsync();
            return View(cargoCompanies);
        }

        [HttpGet("/admin/cargo/company/create")]
        public IActionResult CreateCargoCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompanyAsync(CreateCargoCompanyDto model)
        {
            try
            {
                await _cargoCompanyService.CreateAsync(model);

                return RedirectToAction(nameof(GetAllCargoCompanies));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Kargo şirketi eklerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCargoCompanyAsync(string id)
        {
            try
            {
                await _cargoCompanyService.DeleteAsync(id);

                return RedirectToAction(nameof(GetAllCargoCompanies));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Kargo şirketini silerken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(GetAllCargoCompanies));
            }

        }

        [HttpGet("/admin/cargo/company/update/{id}")]
        public async Task<IActionResult> UpdateCargoCompanyAsync(string id)
        {
            try
            {
                var cargoCompany = await _cargoCompanyService.GetByIdAsync(id);
                return View(cargoCompany);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Kargo şirketini getirirken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(GetAllCargoCompanies));
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompanyAsync(ResultCargoCompanyDto model)
        {
            try
            {
                await _cargoCompanyService.UpdateAsync(model);

                return RedirectToAction(nameof(GetAllCargoCompanies));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Kargo şirketini güncellerken hata oluştu: {ex.Message}");
            }

            return View(model);
        }
    }
}
