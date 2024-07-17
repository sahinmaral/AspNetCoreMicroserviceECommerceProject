using MultiShop.WebUI.Dtos.Brand;
using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{

    public interface ICatalogBrandApi
    {
        [Get("/brands")]
        Task<List<ResultBrandDto>> GetBrands();
        [Get("/brands/count")]
        Task<int> GetCount();
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
