using MultiShop.WebUI.Dtos.OfferDiscount;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Concrete
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly ICatalogApi _catalogApiClientCredential;
        private readonly ICatalogApi _catalogApiResourceOwnerPasswordCatalogApi;

        public OfferDiscountService(IHttpClientFactory clientFactory)
        {
            _catalogApiClientCredential = RestService.For<ICatalogApi>(clientFactory.CreateClient("ClientCredentialCatalogApi"));
            _catalogApiResourceOwnerPasswordCatalogApi = RestService.For<ICatalogApi>(clientFactory.CreateClient("ResourceOwnerPasswordCatalogApi"));
        }

        public async Task CreateAsync(CreateOfferDiscountDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.CreateOfferDiscount(dto);
        }
        public async Task DeleteAsync(string id)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.DeleteOfferDiscount(id);
        }
        public async Task<ResultOfferDiscountDto> GetByIdAsync(string id)
        {
            return await _catalogApiClientCredential.GetOfferDiscountById(id);
        }
        public async Task<List<ResultOfferDiscountDto>> GetAllAsync()
        {
            return await _catalogApiClientCredential.GetOfferDiscounts();
        }
        public async Task UpdateAsync(ResultOfferDiscountDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.UpdateOfferDiscount(dto);
        }
    }
}
