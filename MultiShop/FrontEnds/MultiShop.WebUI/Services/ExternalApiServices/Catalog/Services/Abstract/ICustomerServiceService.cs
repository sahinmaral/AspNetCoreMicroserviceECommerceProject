using MultiShop.WebUI.Dtos.CustomerService;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface ICustomerServiceService
    {
        Task<List<ResultCustomerServiceDto>> GetAllAsync();
        Task CreateAsync(CreateCustomerServiceDto dto);
        Task UpdateAsync(ResultCustomerServiceDto dto);
        Task DeleteAsync(string id);
        Task<ResultCustomerServiceDto> GetByIdAsync(string id);
    }
}
