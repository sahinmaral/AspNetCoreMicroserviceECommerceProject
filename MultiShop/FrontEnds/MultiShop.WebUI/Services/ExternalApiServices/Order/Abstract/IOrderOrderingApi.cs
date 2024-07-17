using MultiShop.WebUI.Dtos.Order;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Order.Abstract
{
    public interface IOrderOrderingApi
    {
        [Get("/orderings/user/{userId}")]
        Task<List<ResultOrderingByUserIdDto>> GetOrderingsByUserId(string userId);
    }
}
