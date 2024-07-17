using MultiShop.WebUI.Dtos.Cargo;

namespace MultiShop.WebUI.Services.ExternalApiServices.Cargo.Abstract
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDto>> GetAllAsync();
        Task<ResultCargoCompanyDto> GetByIdAsync(string id);
        Task CreateAsync(CreateCargoCompanyDto dto);
        Task UpdateAsync(ResultCargoCompanyDto dto);
        Task DeleteAsync(string id);
    }
}
