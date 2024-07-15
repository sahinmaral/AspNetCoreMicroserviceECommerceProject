using MultiShop.WebUI.Dtos.OfferDiscount;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllAsync();
        Task CreateAsync(CreateOfferDiscountDto dto);
        Task UpdateAsync(ResultOfferDiscountDto dto);
        Task DeleteAsync(string id);
        Task<ResultOfferDiscountDto> GetByIdAsync(string id);
    }
}
