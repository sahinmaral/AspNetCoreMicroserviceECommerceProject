using MultiShop.WebUI.Dtos.ProductDetail;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface IProductDetailService
    {
        Task CreateAsync(CreateProductDetailDto dto);
        Task UpdateAsync(ResultProductDetailDto dto);
        Task DeleteAsync(string id);
        Task<ResultProductDetailDto> GetByIdAsync(string id);
        Task<ResultProductDetailDto> GetByProductId(string productId);
    }
}
