using MultiShop.WebUI.Dtos.Cargo;
using MultiShop.WebUI.Services.ExternalApiServices.Cargo.Abstract;

namespace MultiShop.WebUI.Services.ExternalApiServices.Cargo.Concrete
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly ICargoApi _cargoApi;
        public CargoCustomerService(ICargoApi cargoApi)
        {
            _cargoApi = cargoApi;
        }

        public async Task CreateAsync(CreateCargoCustomerDto dto)
        {
            await _cargoApi.CreateCargoCustomer(dto);
        }

        public async Task DeleteAsync(string id)
        {
            await _cargoApi.DeleteCargoCustomer(id);
        }

        public async Task<List<ResultCargoCustomerDto>> GetAllAsync()
        {
            return await _cargoApi.GetAllCargoCustomers();
        }

        public async Task<ResultCargoCustomerDto> GetByIdAsync(string id)
        {
            return await _cargoApi.GetCargoCustomerById(id);
        }

        public async Task<ResultCargoCustomerDto> GetByUserIdAsync(string userId)
        {
            return await _cargoApi.GetCargoCustomerByUserId(userId);
        }

        public async Task UpdateAsync(ResultCargoCustomerDto dto)
        {
            await _cargoApi.UpdateCargoCustomer(dto);
        }
    }
}
