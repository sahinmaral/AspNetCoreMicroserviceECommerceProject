using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services.Authentication.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Order.Abstract;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IOrderOrderingService _orderOrderingService;

        public MyOrderController(IOrderOrderingService orderOrderingService, IIdentityService identityService)
        {
            _orderOrderingService = orderOrderingService;
            _identityService = identityService;
        }

        [Route("user/my-order")]
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var currentUserId = _identityService.CurrentUserId;
                var orderings = await _orderOrderingService.GetAllByUserIdAsync(currentUserId);
                return View(orderings);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Siparişleri getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
