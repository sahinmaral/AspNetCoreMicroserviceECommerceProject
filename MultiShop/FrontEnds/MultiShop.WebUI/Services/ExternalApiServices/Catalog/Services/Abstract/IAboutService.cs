using MultiShop.WebUI.Dtos.About;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAsync();
        Task CreateAsync(CreateAboutDto dto);
        Task UpdateAsync(ResultAboutDto dto);
        Task DeleteAsync(string id);
        Task<ResultAboutDto> GetByIdAsync(string id);
    }
}
