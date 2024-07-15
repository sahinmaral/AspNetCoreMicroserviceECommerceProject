using MultiShop.WebUI.Dtos.About;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly ICatalogApi _catalogApiClientCredential;
        private readonly ICatalogApi _catalogApiResourceOwnerPasswordCatalogApi;

        public AboutService(IHttpClientFactory clientFactory)
        {
            _catalogApiClientCredential = RestService.For<ICatalogApi>(clientFactory.CreateClient("ClientCredentialCatalogApi"));
            _catalogApiResourceOwnerPasswordCatalogApi = RestService.For<ICatalogApi>(clientFactory.CreateClient("ResourceOwnerPasswordCatalogApi"));
        }

        public async Task CreateAsync(CreateAboutDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.CreateAbout(dto);
        }
        public async Task DeleteAsync(string id)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.DeleteAbout(id);
        }
        public async Task<ResultAboutDto> GetByIdAsync(string id)
        {
            return await _catalogApiClientCredential.GetAboutById(id);
        }
        public async Task<List<ResultAboutDto>> GetAllAsync()
        {
            return await _catalogApiClientCredential.GetAbouts();
        }
        public async Task UpdateAsync(ResultAboutDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.UpdateAbout(dto);
        }
    }
}
