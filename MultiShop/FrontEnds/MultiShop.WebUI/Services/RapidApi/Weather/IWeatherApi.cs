using MultiShop.WebUI.Models;

using Refit;

namespace MultiShop.WebUI.Services.RapidApi.Weather
{
    public interface IWeatherApi
    {
        [Get("/city/{city}/TR")]
        Task<WeatherApiResponseModel> GetCurrentWeatherByCity(string city);
    }
}
