using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Basket.Models;
using MultiShop.Basket.Services.Abstract;

namespace MultiShop.Basket.Controllers
{
    [Authorize(Policy = "BasketFullPermission")]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var values = await _basketService.GetBasket(_loginService.CurrentUserId);
            if (values is null)
                return Ok(new BasketTotalDto());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.CurrentUserId;
            return Ok(await _basketService.SaveBasket(basketTotalDto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.CurrentUserId);
            return Ok();
        }
    }
}
