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
        ICatalogAboutApi
    {

    }
}
