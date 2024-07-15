using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents
{
    public class CheckoutPaymentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
