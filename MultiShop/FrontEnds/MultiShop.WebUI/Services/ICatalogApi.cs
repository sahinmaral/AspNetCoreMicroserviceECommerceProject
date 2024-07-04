using MultiShop.WebUI.Dtos.Category;
using MultiShop.WebUI.Dtos.Product;

using Refit;

namespace MultiShop.WebUI.Services
{
    public interface ICatalogApi
    {
        [Get("/categories")]
        Task<List<ResultCategoryDto>> GetCategories();

        [Post("/categories")]
        Task CreateCategory(CreateCategoryDto category);

        [Put("/categories")]
        Task UpdateCategory(ResultCategoryDto category);

        [Delete("/categories/{id}")]
        Task DeleteCategory([AliasAs("id")] string id);
        [Get("/categories/{id}")]
        Task<ResultCategoryDto> GetCategoryById(string id);
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
    }
}
