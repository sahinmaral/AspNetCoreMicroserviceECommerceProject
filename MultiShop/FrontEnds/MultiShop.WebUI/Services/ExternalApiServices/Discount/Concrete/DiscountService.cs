using MultiShop.WebUI.Dtos.Discount;
using MultiShop.WebUI.Services.ExternalApiServices.Discount.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Discount.Services.Abstract;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Discount.Services.Concrete
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountApi _discountApiClientCredential;
        private readonly IDiscountApi _discountApiResourceOwnerPasswordDiscountApi;

        public DiscountService(IHttpClientFactory clientFactory)
        {
            _discountApiClientCredential = RestService.For<IDiscountApi>(clientFactory.CreateClient("ClientCredentialDiscountApi"));
            _discountApiResourceOwnerPasswordDiscountApi = RestService.For<IDiscountApi>(clientFactory.CreateClient("ResourceOwnerPasswordDiscountApi"));
        }

        public async Task<GetCouponByCodeDto> GetCouponByCode(string code)
        {
            return await _discountApiClientCredential.GetCouponByCode(code);
        }
    }
}
