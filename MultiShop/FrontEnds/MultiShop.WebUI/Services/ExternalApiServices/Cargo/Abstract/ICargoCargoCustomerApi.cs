using MultiShop.WebUI.Dtos.Cargo;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Cargo.Abstract
{
    public interface ICargoCargoCustomerApi
    {
        [Get("/cargoCustomers")]
        Task<List<ResultCargoCustomerDto>> GetAllCargoCustomers();
        [Get("/cargoCustomers/{id}")]
        Task<ResultCargoCustomerDto> GetCargoCustomerById(string id);
        [Get("/cargoCustomers/user/{id}")]
        Task<ResultCargoCustomerDto> GetCargoCustomerByUserId(string id);
        [Post("/cargoCustomers")]
        Task CreateCargoCustomer(CreateCargoCustomerDto dto);
        [Put("/cargoCustomers")]
        Task UpdateCargoCustomer(ResultCargoCustomerDto dto);
        [Delete("/cargoCustomers/{id}")]
        Task DeleteCargoCustomer(string id);
    }
}
