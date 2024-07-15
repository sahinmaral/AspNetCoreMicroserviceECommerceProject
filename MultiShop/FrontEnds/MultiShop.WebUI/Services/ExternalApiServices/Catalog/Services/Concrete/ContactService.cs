using MultiShop.WebUI.Dtos.Contact;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly ICatalogApi _catalogApiClientCredential;
        private readonly ICatalogApi _catalogApiResourceOwnerPasswordCatalogApi;

        public ContactService(IHttpClientFactory clientFactory)
        {
            _catalogApiClientCredential = RestService.For<ICatalogApi>(clientFactory.CreateClient("ClientCredentialCatalogApi"));
            _catalogApiResourceOwnerPasswordCatalogApi = RestService.For<ICatalogApi>(clientFactory.CreateClient("ResourceOwnerPasswordCatalogApi"));
        }

        public async Task CreateAsync(CreateContactDto dto)
        {
            await _catalogApiClientCredential.CreateContact(dto);
        }
        public async Task DeleteAsync(string id)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.DeleteContact(id);
        }
        public async Task<ResultContactDto> GetByIdAsync(string id)
        {
            return await _catalogApiResourceOwnerPasswordCatalogApi.GetContactById(id);
        }
        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            return await _catalogApiResourceOwnerPasswordCatalogApi.GetContacts();
        }
        public async Task UpdateAsync(ResultContactDto dto)
        {
            await _catalogApiResourceOwnerPasswordCatalogApi.UpdateContact(dto);
        }
    }
}
