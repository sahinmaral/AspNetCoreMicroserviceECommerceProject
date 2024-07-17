using MultiShop.Catalog.Dtos.Category;

namespace MultiShop.Catalog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllAsync();
        Task CreateAsync(CreateCategoryDto dto);
        Task UpdateAsync(UpdateCategoryDto dto);
        Task DeleteAsync(string id);
        Task<GetByCategoryIdDto> GetByIdAsync(string id);
        Task<int> CountAsync();
    }
}