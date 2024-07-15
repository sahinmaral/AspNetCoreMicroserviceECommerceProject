using MultiShop.WebUI.Dtos.CustomerService;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Concrete
{
    public class CustomerServiceService : ICustomerServiceService
    {
        private readonly ICatalogApi _catalogApiClientCredential;
        private readonly ICatalogApi _catalogApiResourceOwnerPasswordCatalogApi;

        public CustomerServiceService(IHttpClientFactory clientFactory)
        {
            _catalogApiClientCredential = RestService.For<ICatalogApi>(clientFactory.CreateClient("ClientCredentialCatalogApi"));
            _catalogApiResourceOwnerPasswordCatalogApi = RestService.For<ICatalogApi>(clientFactory.CreateClient("ResourceOwnerPasswordCatalogApi"));
        }

        public async Task CreateAsync(CreateCustomerServiceDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.CreateCustomerService(dto);
        }
        public async Task DeleteAsync(string id)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.DeleteCustomerService(id);
        }
        public async Task<ResultCustomerServiceDto> GetByIdAsync(string id)
        {
            return await _catalogApiClientCredential.GetCustomerServiceById(id);
        }
        public async Task<List<ResultCustomerServiceDto>> GetAllAsync()
        {
            return await _catalogApiClientCredential.GetCustomerServices();
        }
        public async Task UpdateAsync(ResultCustomerServiceDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.UpdateCustomerService(dto);
        }
    }
}
