using MultiShop.WebUI.Dtos.Contact;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllAsync();
        Task CreateAsync(CreateContactDto dto);
        Task UpdateAsync(ResultContactDto dto);
        Task DeleteAsync(string id);
        Task<ResultContactDto> GetByIdAsync(string id);
    }
}
