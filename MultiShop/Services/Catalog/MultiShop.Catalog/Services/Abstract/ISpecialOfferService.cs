using MultiShop.Catalog.Dtos.SpecialOffer;

namespace MultiShop.Catalog.Services.Abstract
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllAsync();
        Task CreateAsync(CreateSpecialOfferDto dto);
        Task UpdateAsync(UpdateSpecialOfferDto dto);
        Task DeleteAsync(string id);
        Task<GetBySpecialOfferIdDto> GetByIdAsync(string id);
    }
}