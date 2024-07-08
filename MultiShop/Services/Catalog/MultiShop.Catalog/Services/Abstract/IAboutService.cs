using MultiShop.Catalog.Dtos.About;

namespace MultiShop.Catalog.Services.Abstract
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAsync();
        Task CreateAsync(CreateAboutDto dto);
        Task UpdateAsync(UpdateAboutDto dto);
        Task DeleteAsync(string id);
        Task<GetByAboutIdDto> GetByIdAsync(string id);
    }
}