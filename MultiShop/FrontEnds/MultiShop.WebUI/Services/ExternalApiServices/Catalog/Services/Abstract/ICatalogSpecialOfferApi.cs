using MultiShop.WebUI.Dtos.SpecialOffer;
using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{

    public interface ICatalogSpecialOfferApi
    {
        [Get("/specialOffers")]
        Task<List<ResultSpecialOfferDto>> GetSpecialOffers();
        [Put("/specialOffers")]
        Task UpdateSpecialOffer(ResultSpecialOfferDto model);
        [Get("/specialOffers/{id}")]
        Task<ResultSpecialOfferDto> GetSpecialOfferById(string id);
        [Delete("/specialOffers/{id}")]
        Task DeleteSpecialOffer(string id);
        [Post("/specialOffers")]
        Task CreateSpecialOffer(CreateSpecialOfferDto model);
    }
}
