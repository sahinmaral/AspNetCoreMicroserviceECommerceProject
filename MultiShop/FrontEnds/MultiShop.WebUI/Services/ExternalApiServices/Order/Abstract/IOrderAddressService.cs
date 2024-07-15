using MultiShop.WebUI.Dtos.Order;

namespace MultiShop.WebUI.Services.ExternalApiServices.Order.Abstract
{
    public interface IOrderAddressService
    {
        Task CreateAsync(CreateAddressDto dto);
    }
}
