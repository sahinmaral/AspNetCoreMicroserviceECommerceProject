namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
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
        ICatalogProductDetailApi,
        ICatalogContactApi
    {
    }
}
