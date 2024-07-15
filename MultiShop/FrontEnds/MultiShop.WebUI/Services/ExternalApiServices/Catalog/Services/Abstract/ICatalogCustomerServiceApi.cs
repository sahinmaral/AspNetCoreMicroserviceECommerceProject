using MultiShop.WebUI.Dtos.CustomerService;
using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{

    public interface ICatalogCustomerServiceApi
    {
        [Get("/customerServices")]
        Task<List<ResultCustomerServiceDto>> GetCustomerServices();
        [Put("/customerServices")]
        Task UpdateCustomerService(ResultCustomerServiceDto model);
        [Get("/customerServices/{id}")]
        Task<ResultCustomerServiceDto> GetCustomerServiceById(string id);
        [Delete("/customerServices/{id}")]
        Task DeleteCustomerService(string id);
        [Post("/customerServices")]
        Task CreateCustomerService(CreateCustomerServiceDto model);
    }
}
