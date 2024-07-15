using MultiShop.WebUI.Dtos.FeatureSlider;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Concrete
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly ICatalogApi _catalogApiClientCredential;
        private readonly ICatalogApi _catalogApiResourceOwnerPasswordCatalogApi;

        public FeatureSliderService(IHttpClientFactory clientFactory)
        {
            _catalogApiClientCredential = RestService.For<ICatalogApi>(clientFactory.CreateClient("ClientCredentialCatalogApi"));
            _catalogApiResourceOwnerPasswordCatalogApi = RestService.For<ICatalogApi>(clientFactory.CreateClient("ResourceOwnerPasswordCatalogApi"));
        }

        public async Task CreateAsync(CreateFeatureSliderDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.CreateFeatureSlider(dto);
        }
        public async Task DeleteAsync(string id)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.DeleteFeatureSlider(id);
        }
        public async Task<ResultFeatureSliderDto> GetByIdAsync(string id)
        {
            return await _catalogApiClientCredential.GetFeatureSliderById(id);
        }
        public async Task<List<ResultFeatureSliderDto>> GetAllAsync()
        {
            return await _catalogApiClientCredential.GetFeatureSliders();
        }
        public async Task UpdateAsync(ResultFeatureSliderDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.UpdateFeatureSlider(dto);
        }
    }
}
