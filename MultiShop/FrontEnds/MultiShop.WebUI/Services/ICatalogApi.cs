using MultiShop.WebUI.Dtos.Product;
using MultiShop.WebUI.Dtos.ProductDetail;

namespace MultiShop.WebUI.Services
{

    public partial interface ICatalogApi :
        ICatalogCategoryApi,
        ICatalogProductApi,
        ICatalogCustomerServiceApi,
        ICatalogFeatureSliderApi,
        ICatalogOfferDiscountApi,
        ICatalogSpecialOfferApi,
        ICatalogBrandApi,
        ICatalogAboutApi,
        ICatalogProductDetailApi
    {

    }
}
