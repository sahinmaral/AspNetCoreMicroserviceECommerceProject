using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.ViewComponents
{
    public class LayoutTopbarLanguageSelectViewComponent: ViewComponent
    {
        private readonly IOptions<RequestLocalizationOptions> _localizationOptions;

        public LayoutTopbarLanguageSelectViewComponent(IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _localizationOptions = localizationOptions;
        }

        public IViewComponentResult Invoke()
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var currentCulture = requestCultureFeature?.RequestCulture.Culture;

            var model = new LanguageSelectViewModel
            {
                CurrentCulture = currentCulture,
                SupportedCultures = _localizationOptions.Value.SupportedUICultures
            };

            return View(model);
        }
    }
}
