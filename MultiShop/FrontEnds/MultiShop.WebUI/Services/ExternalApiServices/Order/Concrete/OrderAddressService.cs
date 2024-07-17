using MultiShop.WebUI.Dtos.Order;
using MultiShop.WebUI.Services.ExternalApiServices.Order.Abstract;

namespace MultiShop.WebUI.Services.ExternalApiServices.Order.Concrete
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly IOrderApi _orderApi;

        public OrderAddressService(IOrderApi orderApi)
        {
            _orderApi = orderApi;
        }

        public async Task CreateAsync(CreateAddressDto dto)
        {
            await _orderApi.CreateAddress(dto);
        }
    }
}
