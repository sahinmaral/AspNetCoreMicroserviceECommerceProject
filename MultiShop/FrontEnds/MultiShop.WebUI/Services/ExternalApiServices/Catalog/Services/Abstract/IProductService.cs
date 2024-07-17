using MultiShop.WebUI.Dtos.Product;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllAsync();
        Task CreateAsync(CreateProductDto dto);
        Task UpdateAsync(ResultProductDto dto);
        Task DeleteAsync(string id);
        Task<ResultProductDto> GetByIdAsync(string id);
        Task<List<ResultProductDto>> GetAllByCategoryId(string id);
        Task AddProductImages(ResultProductImagesDto model);
        Task UpdateProductImages(ResultProductImagesDto model);
        Task<decimal> AveragePriceAsync();
        Task<int> CountAsync();
        Task<ResultProductDto> MostCheapProduct();
        Task<ResultProductDto> MostExpensiveProduct();
    }
}
