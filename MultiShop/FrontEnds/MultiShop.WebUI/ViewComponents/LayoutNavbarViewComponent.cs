using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MultiShop.WebUI.ViewComponents
{
    public class LayoutNavbarViewComponent: ViewComponent
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        public LayoutNavbarViewComponent(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        public IViewComponentResult Invoke()
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            var homeUrl = urlHelper.Action("Index", "Home", null, Request.Scheme);

            ViewData["HomeUrl"] = homeUrl;

            return View();
        }
    }
}
