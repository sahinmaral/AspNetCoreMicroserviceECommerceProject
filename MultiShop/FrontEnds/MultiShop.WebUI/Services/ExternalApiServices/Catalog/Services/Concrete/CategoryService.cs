using MultiShop.WebUI.Dtos.Category;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICatalogApi _catalogApiClientCredential;
        private readonly ICatalogApi _catalogApiResourceOwnerPasswordCatalogApi;

        public CategoryService(IHttpClientFactory clientFactory)
        {
            _catalogApiClientCredential = RestService.For<ICatalogApi>(clientFactory.CreateClient("ClientCredentialCatalogApi"));
            _catalogApiResourceOwnerPasswordCatalogApi = RestService.For<ICatalogApi>(clientFactory.CreateClient("ResourceOwnerPasswordCatalogApi"));
        }

        public async Task CreateAsync(CreateCategoryDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.CreateCategory(dto);
        }
        public async Task DeleteAsync(string id)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.DeleteCategory(id);
        }
        public async Task<ResultCategoryDto> GetByIdAsync(string id)
        {
            return await _catalogApiClientCredential.GetCategoryById(id);
        }
        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            return await _catalogApiClientCredential.GetCategories();
        }
        public async Task UpdateAsync(ResultCategoryDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.UpdateCategory(dto);
        }

        public async Task<int> CountAsync()
        {
            return await _catalogApiClientCredential.CountOfProducts();
        }

        public async Task<decimal> AveragePriceAsync()
        {
            return await _catalogApiClientCredential.AveragePriceOfProducts();
        }
    }
}
