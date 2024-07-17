using MultiShop.WebUI.Dtos.Category;
using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface ICatalogCategoryApi
    {
        [Get("/categories")]
        Task<List<ResultCategoryDto>> GetCategories();
        [Get("/categories/count")]
        Task<int> GetCount();

        [Post("/categories")]
        Task CreateCategory(CreateCategoryDto category);

        [Put("/categories")]
        Task UpdateCategory(ResultCategoryDto category);

        [Delete("/categories/{id}")]
        Task DeleteCategory([AliasAs("id")] string id);
        [Get("/categories/{id}")]
        Task<ResultCategoryDto> GetCategoryById(string id);
    }
}
