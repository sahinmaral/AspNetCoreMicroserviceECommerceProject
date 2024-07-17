using MultiShop.WebUI.Dtos.Order;

namespace MultiShop.WebUI.Services.ExternalApiServices.Order.Abstract
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetAllByUserIdAsync(string userId);
    }
}
