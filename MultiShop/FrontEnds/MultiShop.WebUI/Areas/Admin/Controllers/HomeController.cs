using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services.RapidApi.FinanceExchange;
using MultiShop.WebUI.Services.RapidApi.Weather;

using Refit;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IWeatherApi _weatherApi;
        private readonly IFinanceExchangeApi _financeExchangeApi;

        public HomeController(IWeatherApi weatherApi, IFinanceExchangeApi financeExchangeApi)
        {
            _weatherApi = weatherApi;
            _financeExchangeApi = financeExchangeApi;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var currentWeather = await _weatherApi.GetCurrentWeatherByCity("Istanbul");
                var usdToTryExchangeRate = await _financeExchangeApi.GetCurrencyExchangeRate("USD", "TRY");

                ViewBag.CurrentWeather = currentWeather;
                ViewBag.UsdToTryExchangeRate = usdToTryExchangeRate;

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Rapid API servisleri sırasında hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
