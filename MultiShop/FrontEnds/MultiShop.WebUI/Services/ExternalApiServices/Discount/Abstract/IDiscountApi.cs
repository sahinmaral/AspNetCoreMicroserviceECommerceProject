using MultiShop.WebUI.Dtos.Discount;
using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Discount.Abstract
{
    public interface IDiscountApi
    {
        [Get("/discounts/code/{code}")]
        Task<GetCouponByCodeDto> GetCouponByCode(string code);
        [Get("/discounts/count")]
        Task<int> Count();
    }
}
