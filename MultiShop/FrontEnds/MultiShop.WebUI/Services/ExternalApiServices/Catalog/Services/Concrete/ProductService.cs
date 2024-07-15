using MultiShop.WebUI.Dtos.Product;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly ICatalogApi _catalogApiClientCredential;
        private readonly ICatalogApi _catalogApiResourceOwnerPasswordCatalogApi;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _catalogApiClientCredential = RestService.For<ICatalogApi>(clientFactory.CreateClient("ClientCredentialCatalogApi"));
            _catalogApiResourceOwnerPasswordCatalogApi = RestService.For<ICatalogApi>(clientFactory.CreateClient("ResourceOwnerPasswordCatalogApi"));
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.CreateProduct(dto);
        }
        public async Task DeleteAsync(string id)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.DeleteProduct(id);
        }
        public async Task<ResultProductDto> GetByIdAsync(string id)
        {
            return await _catalogApiClientCredential.GetProductById(id);
        }
        public async Task<List<ResultProductDto>> GetAllAsync()
        {
            return await _catalogApiClientCredential.GetProducts();
        }
        public async Task UpdateAsync(ResultProductDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.UpdateProduct(dto);
        }

        public async Task<List<ResultProductDto>> GetAllByCategoryId(string id)
        {
            return await _catalogApiClientCredential.GetProductsByCategoryId(id);
        }

        public async Task AddProductImages(ResultProductImagesDto model)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.AddProductImages(model);
        }

        public async Task UpdateProductImages(ResultProductImagesDto model)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.UpdateProductImages(model);
        }
    }
}
