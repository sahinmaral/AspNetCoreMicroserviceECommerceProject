using MultiShop.Catalog.Dtos.FeatureSlider;

namespace MultiShop.Catalog.Services.Abstract
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllAsync();
        Task CreateAsync(CreateFeatureSliderDto dto);
        Task UpdateAsync(UpdateFeatureSliderDto dto);
        Task DeleteAsync(string id);
        Task<GetByFeatureSliderIdDto> GetByIdAsync(string id);
    }
}