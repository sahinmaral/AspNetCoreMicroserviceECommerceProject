using MultiShop.Catalog.Dtos.Product;

namespace MultiShop.Catalog.Services.Abstract
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllAsync();
        Task CreateAsync(CreateProductDto dto);
        Task UpdateAsync(UpdateProductDto dto);
        Task DeleteAsync(string id);
        Task<GetByProductIdDto> GetByIdAsync(string id);
        Task<List<ResultProductDto>> GetAllByCategoryIdAsync(string categoryId);
    }
}