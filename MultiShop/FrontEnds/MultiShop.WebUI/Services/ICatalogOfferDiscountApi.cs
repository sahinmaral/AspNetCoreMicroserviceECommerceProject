using MultiShop.WebUI.Dtos.OfferDiscount;

using Refit;

namespace MultiShop.WebUI.Services
{

    public interface ICatalogOfferDiscountApi
    {
        [Post("/offerDiscounts")]
        Task CreateOfferDiscount(CreateOfferDiscountDto model);
        [Get("/offerDiscounts")]
        Task<List<ResultOfferDiscountDto>> GetOfferDiscounts();
        [Put("/offerDiscounts")]
        Task UpdateOfferDiscount(ResultOfferDiscountDto model);
        [Get("/offerDiscounts/{id}")]
        Task<ResultOfferDiscountDto> GetOfferDiscountById(string id);
        [Delete("/offerDiscounts/{id}")]
        Task DeleteOfferDiscount(string id);
    }
}
