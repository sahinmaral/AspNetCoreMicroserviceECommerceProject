using MultiShop.WebUI.Dtos.Order;
using MultiShop.WebUI.Services.ExternalApiServices.Order.Abstract;

namespace MultiShop.WebUI.Services.ExternalApiServices.Order.Concrete
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly IOrderApi _orderApi;

        public OrderOrderingService(IOrderApi orderApi)
        {
            _orderApi = orderApi;
        }
        public async Task<List<ResultOrderingByUserIdDto>> GetAllByUserIdAsync(string userId)
        {
            return await _orderApi.GetOrderingsByUserId(userId);
        }
    }
}
