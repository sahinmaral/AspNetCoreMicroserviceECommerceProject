using MultiShop.WebUI.Dtos.ProductDetail;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Concrete
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly ICatalogApi _catalogApiClientCredential;
        private readonly ICatalogApi _catalogApiResourceOwnerPasswordCatalogApi;

        public ProductDetailService(IHttpClientFactory clientFactory)
        {
            _catalogApiClientCredential = RestService.For<ICatalogApi>(clientFactory.CreateClient("ClientCredentialCatalogApi"));
            _catalogApiResourceOwnerPasswordCatalogApi = RestService.For<ICatalogApi>(clientFactory.CreateClient("ResourceOwnerPasswordCatalogApi"));
        }

        public async Task CreateAsync(CreateProductDetailDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.CreateProductDetail(dto);
        }
        public async Task DeleteAsync(string id)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.DeleteProductDetail(id);
        }
        public async Task<ResultProductDetailDto> GetByIdAsync(string id)
        {
            return await _catalogApiClientCredential.GetProductDetailById(id);
        }
        public async Task UpdateAsync(ResultProductDetailDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.UpdateProductDetail(dto);
        }

        public async Task<ResultProductDetailDto> GetByProductId(string productId)
        {
            return await _catalogApiClientCredential.GetProductDetailByProductId(productId);
        }
    }
}
