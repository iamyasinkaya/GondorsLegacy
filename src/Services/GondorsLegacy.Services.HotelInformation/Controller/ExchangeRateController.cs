using GondorsLegacy.Services.HotelInformation.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GondorsLegacy.Services.HotelInformation.Controller;

[Route("api/[controller]")]
[ApiController]
public class ExchangeRateController : ControllerBase
{
    private readonly IExchangeRateApi _exchangeRateApi;

    public ExchangeRateController(IExchangeRateApi exchangeRateApi)
    {
        _exchangeRateApi = exchangeRateApi;
    }

    /// <summary>
    /// Get currency exchange rates between different countries
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-exchange-rates")]
    public async Task<IActionResult> GetExchangeRates()
    {
        try
        {
            var baseCurrency = "USD";
            var languageCode = "en-us";
            var response = await _exchangeRateApi.GetExchangeRatesAsync(baseCurrency, languageCode);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }
}