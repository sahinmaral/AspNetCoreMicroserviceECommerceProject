using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Order;
using MultiShop.WebUI.Services.Authentication.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Order.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IIdentityService _identityService;

        public OrderController(IIdentityService identityService, IOrderAddressService orderAddressService)
        {
            _identityService = identityService;
            _orderAddressService = orderAddressService;
        }

        [Route("checkout")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Index(CreateAddressDto dto)
        {
            try
            {
                dto.UserId = _identityService.CurrentUserId;
                await _orderAddressService.CreateAsync(dto);

                return RedirectToAction("Index", "Payment");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
