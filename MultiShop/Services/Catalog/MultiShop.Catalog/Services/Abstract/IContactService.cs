using MultiShop.Catalog.Dtos.Contact;

namespace MultiShop.Catalog.Services.Abstract
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllAsync();
        Task CreateAsync(CreateContactDto dto);
        Task UpdateAsync(UpdateContactDto dto);
        Task DeleteAsync(string id);
        Task<GetByContactIdDto> GetByIdAsync(string id);
    }
}