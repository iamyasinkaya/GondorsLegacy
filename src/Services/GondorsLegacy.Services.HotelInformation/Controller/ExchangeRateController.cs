using System.ComponentModel.DataAnnotations;
using Castle.DynamicProxy;
using GondorsLegacy.CrossCuttingCorners.Contracts;
using GondorsLegacy.Infrastructure.Interceptors;
using GondorsLegacy.Services.HotelInformation.Models;
using GondorsLegacy.Services.HotelInformation.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GondorsLegacy.Services.HotelInformation.Controller;

[Route("api/[controller]")]
[ApiController]
public class ExchangeRateController : ControllerBase
{
    private readonly IExchangeRateApi _exchangeRateApi;
    private readonly IProxyGenerator _proxyGenerator;
    private readonly LoggingInterceptor _interceptor;
    private readonly IRetryPolicy<string> _retryPolicy;

    public ExchangeRateController(IExchangeRateApi exchangeRateApi, IProxyGenerator proxyGenerator, LoggingInterceptor interceptor, IRetryPolicy<string> retryPolicy)
    {
        _exchangeRateApi = exchangeRateApi;
        _proxyGenerator = proxyGenerator;
        _interceptor = interceptor;
        _retryPolicy = retryPolicy;
    }

    /// <summary>
    /// Get currency exchange rates between different countries
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-exchange-rates")]
    public async Task<IActionResult> GetExchangeRates([FromQuery][Required] string baseCurrency, [FromQuery] string languageCode)
    {
        var proxy = _proxyGenerator.CreateInterfaceProxyWithTarget(_retryPolicy, _interceptor);

        var response = await proxy.ExecuteAsync(async () =>
        await _exchangeRateApi.GetExchangeRatesAsync(baseCurrency: baseCurrency, languageCode: languageCode), 3);

        if (!string.IsNullOrWhiteSpace(response))
        {
            // API yanıtı JSON formatındaysa işleyin
            var errorResponse = JsonConvert.DeserializeObject<BookingApiErrorResponseModel>(response);

            if (errorResponse != null && !string.IsNullOrWhiteSpace(errorResponse.Message))
            {
                return BadRequest(errorResponse.Message);
            }

            var successResponse = JsonConvert.DeserializeObject<ExchangeRateResponseModel>(response);
            // Başarılı yanıtı işleyin ve istemciye dönün.
            return Ok(successResponse);
        }
        else
        {
            // Yanıt boşsa, bir hata dönün.
            return NotFound("Aranan kayıt bulunamadı.");
        }


    }
}