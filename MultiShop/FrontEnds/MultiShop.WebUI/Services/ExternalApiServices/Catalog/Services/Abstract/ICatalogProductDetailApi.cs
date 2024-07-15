using MultiShop.WebUI.Dtos.ProductDetail;
using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface ICatalogProductDetailApi
    {
        [Get("/productDetails/product/{productId}")]
        Task<ResultProductDetailDto> GetProductDetailByProductId(string productId);
        [Post("/productDetails")]
        Task CreateProductDetail(CreateProductDetailDto model);
        [Get("/productDetails/{id}")]
        Task<ResultProductDetailDto> GetProductDetailById(string id);
        [Put("/productDetails")]
        Task UpdateProductDetail(ResultProductDetailDto model);
        [Delete("/productDetails/{id}")]
        Task DeleteProductDetail(string id);
    }
}
