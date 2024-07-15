using MultiShop.WebUI.Dtos.Contact;
using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface ICatalogContactApi
    {
        [Get("/contacts")]
        Task<List<ResultContactDto>> GetContacts();
        [Put("/contacts")]
        Task UpdateContact(ResultContactDto model);
        [Get("/contacts/{id}")]
        Task<ResultContactDto> GetContactById(string id);
        [Delete("/contacts/{id}")]
        Task DeleteContact(string id);
        [Post("/contacts")]
        Task CreateContact(CreateContactDto model);
    }
}
