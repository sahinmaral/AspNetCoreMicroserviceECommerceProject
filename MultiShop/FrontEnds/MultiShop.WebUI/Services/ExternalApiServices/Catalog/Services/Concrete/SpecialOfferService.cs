using MultiShop.WebUI.Dtos.SpecialOffer;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Concrete
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly ICatalogApi _catalogApiClientCredential;
        private readonly ICatalogApi _catalogApiResourceOwnerPasswordCatalogApi;

        public SpecialOfferService(IHttpClientFactory clientFactory)
        {
            _catalogApiClientCredential = RestService.For<ICatalogApi>(clientFactory.CreateClient("ClientCredentialCatalogApi"));
            _catalogApiResourceOwnerPasswordCatalogApi = RestService.For<ICatalogApi>(clientFactory.CreateClient("ResourceOwnerPasswordCatalogApi"));
        }

        public async Task CreateAsync(CreateSpecialOfferDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.CreateSpecialOffer(dto);
        }
        public async Task DeleteAsync(string id)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.DeleteSpecialOffer(id);
        }
        public async Task<ResultSpecialOfferDto> GetByIdAsync(string id)
        {
            return await _catalogApiClientCredential.GetSpecialOfferById(id);
        }
        public async Task<List<ResultSpecialOfferDto>> GetAllAsync()
        {
            return await _catalogApiClientCredential.GetSpecialOffers();
        }
        public async Task UpdateAsync(ResultSpecialOfferDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.UpdateSpecialOffer(dto);
        }
    }
}
