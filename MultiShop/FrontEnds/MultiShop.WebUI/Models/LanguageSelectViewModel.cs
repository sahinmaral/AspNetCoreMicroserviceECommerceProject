using System.Globalization;

namespace MultiShop.WebUI.Models
{
    public class LanguageSelectViewModel
    {
        public CultureInfo CurrentCulture { get; set; }
        public IList<CultureInfo> SupportedCultures { get; set; }
    }
}
