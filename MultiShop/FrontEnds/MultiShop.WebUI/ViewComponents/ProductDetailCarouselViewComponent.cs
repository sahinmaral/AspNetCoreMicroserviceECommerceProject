using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents
{
    public class ProductDetailCarouselViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<string> productImages)
        {
            return View("Default", productImages);
        }
    }
}
