using MultiShop.WebUI.Dtos.Cargo;
using MultiShop.WebUI.Services.ExternalApiServices.Cargo.Abstract;

namespace MultiShop.WebUI.Services.ExternalApiServices.Cargo.Concrete
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly ICargoApi _cargoApi;
        public CargoCompanyService(ICargoApi cargoApi)
        {
            _cargoApi = cargoApi;
        }

        public async Task CreateAsync(CreateCargoCompanyDto dto)
        {
            await _cargoApi.CreateCargoCompany(dto);
        }

        public async Task DeleteAsync(string id)
        {
            await _cargoApi.DeleteCargoCompany(id);
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllAsync()
        {
            return await _cargoApi.GetAllCargoCompanies();
        }

        public async Task<ResultCargoCompanyDto> GetByIdAsync(string id)
        {
            return await _cargoApi.GetCargoCompanyById(id);
        }

        public async Task UpdateAsync(ResultCargoCompanyDto dto)
        {
            await _cargoApi.UpdateCargoCompany(dto);
        }
    }
}
