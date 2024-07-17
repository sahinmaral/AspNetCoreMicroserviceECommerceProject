using MultiShop.WebUI.Dtos.Brand;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllAsync();
        Task CreateAsync(CreateBrandDto dto);
        Task UpdateAsync(ResultBrandDto dto);
        Task DeleteAsync(string id);
        Task<ResultBrandDto> GetByIdAsync(string id);
        Task<int> CountAsync();
    }
}
