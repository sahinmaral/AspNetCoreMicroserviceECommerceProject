using MultiShop.WebUI.Dtos.Cargo;

namespace MultiShop.WebUI.Services.ExternalApiServices.Cargo.Abstract
{
    public interface ICargoCustomerService
    {
        Task<List<ResultCargoCustomerDto>> GetAllAsync();
        Task<ResultCargoCustomerDto> GetByIdAsync(string id);
        Task CreateAsync(CreateCargoCustomerDto dto);
        Task UpdateAsync(ResultCargoCustomerDto dto);
        Task DeleteAsync(string id);
        Task<ResultCargoCustomerDto> GetByUserIdAsync(string userId);
    }
}
