using MultiShop.Catalog.Dtos.CustomerService;

namespace MultiShop.Catalog.Services.Abstract
{
    public interface ICustomerServiceService
    {
        Task<List<ResultCustomerServiceDto>> GetAllAsync();
        Task CreateAsync(CreateCustomerServiceDto dto);
        Task UpdateAsync(UpdateCustomerServiceDto dto);
        Task DeleteAsync(string id);
        Task<GetByCustomerServiceIdDto> GetByIdAsync(string id);
    }
}