using MultiShop.WebUI.Dtos.Discount;

namespace MultiShop.WebUI.Services.ExternalApiServices.Discount.Services.Abstract
{
    public interface IDiscountService
    {
        Task<GetCouponByCodeDto?> GetCouponByCode(string code);
        Task<int> Count();
    }
}
