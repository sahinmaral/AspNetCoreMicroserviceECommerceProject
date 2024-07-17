using MultiShop.WebUI.Dtos.Brand;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly ICatalogApi _catalogApiClientCredential;
        private readonly ICatalogApi _catalogApiResourceOwnerPasswordCatalogApi;

        public BrandService(IHttpClientFactory clientFactory)
        {
            _catalogApiClientCredential = RestService.For<ICatalogApi>(clientFactory.CreateClient("ClientCredentialCatalogApi"));
            _catalogApiResourceOwnerPasswordCatalogApi = RestService.For<ICatalogApi>(clientFactory.CreateClient("ResourceOwnerPasswordCatalogApi"));
        }

        public async Task CreateAsync(CreateBrandDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.CreateBrand(dto);
        }
        public async Task DeleteAsync(string id)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.DeleteBrand(id);
        }
        public async Task<ResultBrandDto> GetByIdAsync(string id)
        {
            return await _catalogApiClientCredential.GetBrandById(id);
        }
        public async Task<List<ResultBrandDto>> GetAllAsync()
        {
            return await _catalogApiClientCredential.GetBrands();
        }
        public async Task UpdateAsync(ResultBrandDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.UpdateBrand(dto);
        }

        public async Task<int> CountAsync()
        {
            return await _catalogApiClientCredential.CountOfProducts();
        }
    }
}
