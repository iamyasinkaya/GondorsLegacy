using System.ComponentModel.DataAnnotations;
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

    public ExchangeRateController(IExchangeRateApi exchangeRateApi)
    {
        _exchangeRateApi = exchangeRateApi;
    }

    /// <summary>
    /// Get currency exchange rates between different countries
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-exchange-rates")]
    public async Task<IActionResult> GetExchangeRates([FromQuery] [Required] string baseCurrency, [FromQuery] string languageCode)
    {
        try
        {
            
            var response = await _exchangeRateApi.GetExchangeRatesAsync(baseCurrency, languageCode);
            if (!string.IsNullOrWhiteSpace(response))
            {
                // API yanıtı JSON formatındaysa işleyin
                var errorResponse = JsonConvert.DeserializeObject<BookingApiErrorResponse>(response);

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
        catch (HttpRequestException ex)
        {
            // Ağ hatası durumu
            return StatusCode(StatusCodes.Status503ServiceUnavailable, $"Booking.com API'ye bağlanırken ağ hatası oluştu. => hata mesaj ayrıntısı: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Diğer istisna durumları
            return StatusCode(StatusCodes.Status500InternalServerError, $"Bir iç hata oluştu. => hata mesaj ayrıntısı: {ex.Message}");
        }
    }
}