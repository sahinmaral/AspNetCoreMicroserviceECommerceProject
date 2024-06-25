using MultiShop.Catalog.Dtos.ProductDetail;

namespace MultiShop.Catalog.Services.Abstract
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllAsync();
        Task CreateAsync(CreateProductDetailDto dto);
        Task UpdateAsync(UpdateProductDetailDto dto);
        Task DeleteAsync(string id);
        Task<GetByProductDetailIdDto> GetByIdAsync(string id);
    }
}