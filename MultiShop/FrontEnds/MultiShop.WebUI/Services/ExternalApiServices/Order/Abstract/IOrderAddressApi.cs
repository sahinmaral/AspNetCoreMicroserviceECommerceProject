using MultiShop.WebUI.Dtos.Order;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Order.Abstract
{
    public interface IOrderAddressApi
    {
        [Post("/addresses")]
        Task CreateAddress(CreateAddressDto dto);
    }
}
