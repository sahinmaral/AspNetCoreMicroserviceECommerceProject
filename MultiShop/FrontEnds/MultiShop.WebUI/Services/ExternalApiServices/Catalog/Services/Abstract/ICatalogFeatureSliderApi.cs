using MultiShop.WebUI.Dtos.FeatureSlider;
using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{

    public interface ICatalogFeatureSliderApi
    {
        [Post("/featureSliders")]
        Task CreateFeatureSlider(CreateFeatureSliderDto model);
        [Delete("/featureSliders/{id}")]
        Task DeleteFeatureSlider(string id);
        [Get("/featureSliders/{id}")]
        Task<ResultFeatureSliderDto> GetFeatureSliderById(string id);
        [Put("/featureSliders")]
        Task UpdateFeatureSlider(ResultFeatureSliderDto model);
        [Get("/featureSliders")]
        Task<List<ResultFeatureSliderDto>> GetFeatureSliders();
    }
}
