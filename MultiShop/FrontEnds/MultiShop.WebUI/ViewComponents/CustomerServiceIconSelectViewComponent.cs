using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents
{
    public class CustomerServiceIconSelectViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string? selected = null)
        {
            return View("Default", selected);
        }
    }
}
