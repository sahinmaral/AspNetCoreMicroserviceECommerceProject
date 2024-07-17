using MultiShop.WebUI.Dtos.Product;

namespace MultiShop.WebUI.Services.ExternalApiServices.Statistic.Abstract
{
    public interface IStatisticService
    {
        Task<int> GetCategoryCountAsync();
        Task<int> GetProductCountAsync();
        Task<int> GetBrandCountAsync();
        Task<int> GetUserCountAsync();
        Task<int> GetDiscountCountAsync();
        Task<int> GetCommentCountByStatusAsync(bool status);
        Task<int> GetTotalCommentCountAsync();
        Task<decimal> GetProductAvgPriceAsync();
        Task<ResultProductDto> GetMostExpensiveProductAsync();
        Task<ResultProductDto> GetMostCheapProductAsync();
    }
}
