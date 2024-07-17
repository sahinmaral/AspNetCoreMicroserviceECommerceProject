using MultiShop.WebUI.Dtos.Product;
using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface ICatalogProductApi
    {
        [Get("/products")]
        Task<List<ResultProductDto>> GetProducts();
        [Post("/products")]
        Task CreateProduct(CreateProductDto model);
        [Delete("/products/{id}")]
        Task DeleteProduct(string id);
        [Get("/products/{id}")]
        Task<ResultProductDto> GetProductById(string id);
        [Put("/products")]
        Task UpdateProduct(ResultProductDto model);
        [Get("/products/category/{id}")]
        Task<List<ResultProductDto>> GetProductsByCategoryId(string id);
        [Post("/products/images")]
        Task AddProductImages(ResultProductImagesDto model);
        [Put("/products/images")]
        Task UpdateProductImages(ResultProductImagesDto model);
        [Get("/products/count")]
        Task<int> CountOfProducts();
        [Get("/products/averagePrice")]
        Task<decimal> AveragePriceOfProducts();
        [Get("/products/mostCheap")]
        Task<ResultProductDto> MostCheapProduct();
        [Get("/products/mostExpensive")]
        Task<ResultProductDto> MostExpensiveProduct();
    }
}
