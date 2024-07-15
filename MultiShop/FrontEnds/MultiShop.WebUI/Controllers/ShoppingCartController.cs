using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Basket;
using MultiShop.WebUI.Services.ExternalApiServices.Basket.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Discount.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        public ShoppingCartController(IBasketService basketService, IProductService productService, IDiscountService discountService)
        {
            _basketService = basketService;
            _productService = productService;
            _discountService = discountService;
        }

        [Route("shopping-cart")]
        public async Task<IActionResult> Index()
        {

            var currentBasket = await _basketService.GetBasket();
            return View(currentBasket);
        }

        [Route("shopping-cart/add/{productId}")]
        public async Task<IActionResult> AddBasketItem(string productId)
        {
            var product = await _productService.GetByIdAsync(productId);
            var basketItem = new BasketItemDto
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                ProductImageUrl = product.ThumbnailImageUrl,
                Quantity = 1
            };
            await _basketService.AddBasketItem(basketItem);
            return RedirectToAction(nameof(Index));
        }

        [Route("shopping-cart/remove/{productId}")]
        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            await _basketService.RemoveBasketItem(productId);
            return RedirectToAction(nameof(Index));
        }

        [Route("shopping-cart/removeAll/{productId}")]
        public async Task<IActionResult> RemoveAllBasketItem(string productId)
        {
            await _basketService.RemoveAllBasketItem(productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ApplyCoupon(string code)
        {
            var coupon = await _discountService.GetCouponByCode(code);
            if (coupon is null)
                throw new ArgumentNullException("Böyle bir kupon bulunmadı");

            var currentBasket = await _basketService.GetBasket();

            currentBasket.DiscountRate = coupon.Rate;
            currentBasket.DiscountCode = code;

            await _basketService.SaveBasket(currentBasket);
            return RedirectToAction(nameof(Index));
        }
    }
}
