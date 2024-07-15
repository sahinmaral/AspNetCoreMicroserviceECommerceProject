using MultiShop.WebUI.Dtos.SpecialOffer;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllAsync();
        Task CreateAsync(CreateSpecialOfferDto dto);
        Task UpdateAsync(ResultSpecialOfferDto dto);
        Task DeleteAsync(string id);
        Task<ResultSpecialOfferDto> GetByIdAsync(string id);
    }
}
