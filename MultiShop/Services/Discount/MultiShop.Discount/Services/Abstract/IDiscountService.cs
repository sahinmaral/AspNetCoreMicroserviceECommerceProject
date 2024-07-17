using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services.Abstract
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllAsync();
        Task CreateAsync(CreateCouponDto dto);
        Task UpdateAsync(UpdateCouponDto dto);
        Task DeleteAsync(string id);
        Task<GetByCouponIdDto?> GetByIdAsync(string id);
        Task<GetByCouponIdDto?> GetByCodeAsync(string code);
        Task<int> CountAsync();
    }
}
