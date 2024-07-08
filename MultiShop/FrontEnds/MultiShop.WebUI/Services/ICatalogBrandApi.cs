using MultiShop.WebUI.Dtos.Brand;

using Refit;

namespace MultiShop.WebUI.Services
{

    public interface ICatalogBrandApi
    {
        [Get("/brands")]
        Task<List<ResultBrandDto>> GetBrands();
        [Put("/brands")]
        Task UpdateBrand(ResultBrandDto model);
        [Get("/brands/{id}")]
        Task<ResultBrandDto> GetBrandById(string id);
        [Delete("/brands/{id}")]
        Task DeleteBrand(string id);
        [Post("/brands")]
        Task CreateBrand(CreateBrandDto model);
    }
}
