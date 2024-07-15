using MultiShop.WebUI.Dtos.About;
using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface ICatalogAboutApi
    {
        [Get("/abouts")]
        Task<List<ResultAboutDto>> GetAbouts();
        [Put("/abouts")]
        Task UpdateAbout(ResultAboutDto model);
        [Get("/abouts/{id}")]
        Task<ResultAboutDto> GetAboutById(string id);
        [Delete("/abouts/{id}")]
        Task DeleteAbout(string id);
        [Post("/abouts")]
        Task CreateAbout(CreateAboutDto model);
    }
}
