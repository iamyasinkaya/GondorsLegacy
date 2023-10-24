using System;
using Newtonsoft.Json;

namespace GondorsLegacy.Services.HotelInformation.Models;

public class ExchangeRateResponseModel
{
    [JsonProperty("base_currency_date")]
    public DateTime BaseCurrencyDate { get; set; }
    [JsonProperty("exchange_rates")]
    public List<ExchangeRate> ExchangeRates { get; set; }
}

public class ExchangeRate
{
    [JsonProperty("currency")]
    public string ExchangeRateBuy { get; set; }
    [JsonProperty("exchange_rate_buy")]
    public string Currency { get; set; }
}