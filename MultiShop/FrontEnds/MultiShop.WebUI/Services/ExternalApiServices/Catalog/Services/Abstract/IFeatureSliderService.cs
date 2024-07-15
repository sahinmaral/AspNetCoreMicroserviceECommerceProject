using MultiShop.WebUI.Dtos.FeatureSlider;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllAsync();
        Task CreateAsync(CreateFeatureSliderDto dto);
        Task UpdateAsync(ResultFeatureSliderDto dto);
        Task DeleteAsync(string id);
        Task<ResultFeatureSliderDto> GetByIdAsync(string id);
    }
}
