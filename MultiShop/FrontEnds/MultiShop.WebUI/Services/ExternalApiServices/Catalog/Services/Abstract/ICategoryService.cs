using MultiShop.WebUI.Dtos.Category;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllAsync();
        Task CreateAsync(CreateCategoryDto dto);
        Task UpdateAsync(ResultCategoryDto dto);
        Task DeleteAsync(string id);
        Task<ResultCategoryDto> GetByIdAsync(string id);
    }
}
