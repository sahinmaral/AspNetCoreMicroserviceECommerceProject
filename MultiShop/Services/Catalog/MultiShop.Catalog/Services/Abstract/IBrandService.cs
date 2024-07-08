using MultiShop.Catalog.Dtos.Brand;

namespace MultiShop.Catalog.Services.Abstract
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllAsync();
        Task CreateAsync(CreateBrandDto dto);
        Task UpdateAsync(UpdateBrandDto dto);
        Task DeleteAsync(string id);
        Task<GetByBrandIdDto> GetByIdAsync(string id);
    }
}