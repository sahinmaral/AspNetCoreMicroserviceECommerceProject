using MultiShop.WebUI.Models;

using Refit;

namespace MultiShop.WebUI.Services.RapidApi.FinanceExchange
{
    public interface IFinanceExchangeApi
    {
        [Get("/currency-exchange-rate")]
        Task<FinanceExchangeResponseModel> GetCurrencyExchangeRate(
            [AliasAs("from_symbol")] string fromSymbol,
            [AliasAs("to_symbol")] string toSymbol,
            [AliasAs("language")] string language = "en");
    }
}
