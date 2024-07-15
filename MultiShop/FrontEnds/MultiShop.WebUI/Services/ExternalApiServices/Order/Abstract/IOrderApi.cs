using MultiShop.WebUI.Dtos.Order;
using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Order.Abstract
{
    public interface IOrderApi
    {
        [Post("/addresses")]
        Task CreateAsync(CreateAddressDto dto);
    }
}
