using MultiShop.Catalog.Dtos.OfferDiscount;

namespace MultiShop.Catalog.Services.Abstract
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllAsync();
        Task CreateAsync(CreateOfferDiscountDto dto);
        Task UpdateAsync(UpdateOfferDiscountDto dto);
        Task DeleteAsync(string id);
        Task<GetByOfferDiscountIdDto> GetByIdAsync(string id);
    }
}