using Refit;
namespace GondorsLegacy.Services.HotelInformation.Services.Abstract;


public interface IExchangeRateApi
{
    [Get("/currency/get-exchange-rates")]
    Task<string> GetExchangeRatesAsync([AliasAs("base_currency")] string baseCurrency, [AliasAs("languagecode")] string languageCode);
}

