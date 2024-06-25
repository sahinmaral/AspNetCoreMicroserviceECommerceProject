using MultiShop.Catalog.Dtos.ProductImage;

namespace MultiShop.Catalog.Services.Abstract
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllAsync();
        Task CreateAsync(CreateProductImageDto dto);
        Task UpdateAsync(UpdateProductImageDto dto);
        Task DeleteAsync(string id);
        Task<GetByProductImageIdDto> GetByIdAsync(string id);
    }
}