using System.ComponentModel.DataAnnotations;
using GondorsLegacy.Services.HotelInformation.Models;
using GondorsLegacy.Services.HotelInformation.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
namespace GondorsLegacy.Services.HotelInformation.Controller;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingApi _bookingApi;

    public BookingController(IBookingApi bookingApi)
    {
        _bookingApi = bookingApi;
    }

    /// <summary>
    /// List properties having type of resorts, hotels, motels, hostels, etc as on official site
    /// </summary>
    /// <param name="offset">The number of items to ignore as offset for paging (fixed 30 items returned per page). You are interested in the optional parameter 'search_id'</param>
    /// <param name="arrivalDate">The check-in date at hotel, the format is yyyy-MM-dd. Ex : 2022-08-14</param>
    /// <param name="departureDate">The check-out date, the format is yyyy-MM-dd. Ex : 2022-08-15</param>
    /// <param name="guestQty">The number of adults</param>
    /// <param name="destIds">Value of dest_id or city_ufi field from locations/auto-complete API (Don't pass this if you use latlong as search_type)</param>
    /// <param name="roomQty">The number of rooms</param>
    /// <param name="searchType">Value of dest_type returned by locations/auto-complete API</param>
    /// <param name="childrenQty">The number of children</param>
    /// <param name="childrenAge">The year old of each child that separated by comma</param>
    /// <param name="searchId">Pass 'none' or value returned right in this API. You need to pass this parameter to get 'offset' working</param>
    /// <param name="priceFilterCurrencyCode">The base currency to calculate exchange rate</param>
    /// <param name="orderBy">One of the followings : popularity|distance|class_descending|class_ascending|deals|review_score|price</param>
    /// <param name="languageCode">One of the followings : en|en-us|ar|bg|ca|cs|da|de|el|es|es-ar|et|fi|fr|he|hr|hu|id|is|it|ja|ko|lt|lv|ms|nl|no|pl|pt|pt-br|ro|ru|sk|sl|sr|sv|th|tl|tr|uk|vi|zh|zh-tw</param>
    /// <param name="travelPurpose">One of the followings : leisure|business</param>
    /// <returns></returns>
    [HttpGet("getPropertyList")]
    public async Task<IActionResult> GetPropertyList(
     [FromQuery][Required] int offset,
     [FromQuery][Required] string arrivalDate,
     [FromQuery][Required] string departureDate,
     [FromQuery][Required] int guestQty,
     [FromQuery][Required] int destIds,
     [FromQuery][Required] int roomQty,
     [FromQuery][Required] string searchType,
     [FromQuery] int childrenQty,
     [FromQuery] string childrenAge,
     [FromQuery] string searchId,
     [FromQuery] string priceFilterCurrencyCode,
     [FromQuery] string orderBy,
     [FromQuery] string languageCode,
     [FromQuery] string travelPurpose)
    {
        try
        {
            var response = await _bookingApi.GetPropertyList(
                offset,
                arrivalDate,
                departureDate,
                guestQty,
                destIds,
                roomQty,
                searchType,
                childrenQty,
                childrenAge,
                searchId,
                priceFilterCurrencyCode,
                orderBy,
                languageCode,
                travelPurpose
            );

            if (!string.IsNullOrWhiteSpace(response))
            {
                // API yanıtı JSON formatındaysa işleyin
                var errorResponse = JsonConvert.DeserializeObject<BookingApiErrorResponse>(response);

                if (errorResponse != null && !string.IsNullOrWhiteSpace(errorResponse.Message))
                {
                    return BadRequest(errorResponse.Message);
                }

                // Başarılı yanıtı işleyin ve istemciye dönün.
                return Ok(response);
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



    /// <summary>
    /// List properties by coordinate of bounding box
    /// </summary>
    /// <param name="arrivalDate">The check-in date at hotel, the format is yyyy-MM-dd. Ex : 2022-08-14</param>
    /// <param name="departureDate">The check-out date, the format is yyyy-MM-dd. Ex : 2022-08-15</param>
    /// <param name="roomQty">The number of rooms</param>
    /// <param name="guestQty">The number of adults</param>
    /// <param name="bbox">Coordinate of bounding box - latitude (bottom left),latitude (top right),longitude (bottom left),longitude (top right)</param>
    /// <param name="searchId">Pass \\"none\\" or value returned right in this API</param>
    /// <param name="childrenAge">The year old of each child that separated by comma</param>
    /// <param name="priceFilterCurrencyCode">The base currency to calculate exchange rate</param>
    /// <param name="categoriesFilter">The id returned by …/filters/list API, values separated by comma</param>
    /// <param name="languageCode">One of the followings : en|en-us|ar|bg|ca|cs|da|de|el|es|es-ar|et|fi|fr|he|hr|hu|id|is|it|ja|ko|lt|lv|ms|nl|no|pl|pt|pt-br|ro|ru|sk|sl|sr|sv|th|tl|tr|uk|vi|zh|zh-tw</param>
    /// <param name="travelPurpose">One of the followings : leisure|business</param>
    /// <param name="childrenQty">The number of children</param>
    /// <param name="orderBy">One of the followings : popularity|distance|class_descending|class_ascending|deals|review_score|price</param>
    /// <returns>List properties by coordinate of bounding box</returns>
    [HttpGet("getPropertyListByMap")]
    public async Task<IActionResult> GetPropertyListByMap(
        [FromQuery][Required] string arrivalDate,
        [FromQuery][Required] string departureDate,
        [FromQuery][Required] int roomQty,
        [FromQuery][Required] int guestQty,
        [FromQuery][Required] string bbox,
        [FromQuery] string searchId,
        [FromQuery] string childrenAge,
        [FromQuery] string priceFilterCurrencyCode,
        [FromQuery] string categoriesFilter,
        [FromQuery] string languageCode,
        [FromQuery] string travelPurpose,
        [FromQuery] int childrenQty,
        [FromQuery] string orderBy)
    {
        try
        {
            var response = await _bookingApi.GetPropertyListByMap(
                arrivalDate,
                departureDate,
                roomQty,
                guestQty,
                bbox,
                searchId,
                childrenAge,
                priceFilterCurrencyCode,
                categoriesFilter,
                languageCode,
                travelPurpose,
                childrenQty,
                orderBy
            );
            if (!string.IsNullOrWhiteSpace(response))
            {
                // API yanıtı JSON formatındaysa işleyin
                var errorResponse = JsonConvert.DeserializeObject<BookingApiErrorResponse>(response);

                if (errorResponse != null && !string.IsNullOrWhiteSpace(errorResponse.Message))
                {
                    return BadRequest(errorResponse.Message);
                }

                // Başarılı yanıtı işleyin ve istemciye dönün.
                return Ok(response);
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



    /// <summary>
    /// Get brief information of a property
    /// </summary>
    /// <param name="hotelId">The value of hotel_id field from properties/list API</param>
    /// <param name="searchId">The value returned in properties/list API having response contains the selected hotel</param>
    /// <param name="departureDate">The check-out date</param>
    /// <param name="arrivalDate">The check-in date at hotel</param>
    /// <param name="recGuestQty">The number of adults separated by comma, and how you arrange them in rooms</param>
    /// <param name="recRoomQty">The number of rooms</param>
    /// <param name="destIds">The value of 'dest_id' field returned in …/locations/auto-complete endpoint</param>
    /// <param name="recommendFor">The recommended number of persons per room</param>
    /// <param name="languageCode">One of the followings : en|en-us|ar|bg|ca|cs|da|de|el|es|es-ar|et|fi|fr|he|hr|hu|id|is|it|ja|ko|lt|lv|ms|nl|no|pl|pt|pt-br|ro|ru|sk|sl|sr|sv|th|tl|tr|uk|vi|zh|zh-tw</param>
    /// <param name="currencyCode">The currency code</param>
    /// <param name="units">One of the following : metric|imperial</param>
    /// <returns></returns>
    [HttpGet("getPropertyDetail")]
    public async Task<IActionResult> GetPropertyDetail(
        [FromQuery][Required] int hotelId,
        [FromQuery][Required] string searchId,
        [FromQuery][Required] string departureDate,
        [FromQuery][Required] string arrivalDate,
        [FromQuery][Required] int recGuestQty,
        [FromQuery][Required] int recRoomQty,
        [FromQuery] int destIds,
        [FromQuery] int recommendFor,
        [FromQuery] string languageCode,
        [FromQuery] string currencyCode,
        [FromQuery] string units)
    {
        try
        {
            var response = await _bookingApi.GetPropertyDetail(
                hotelId,
                searchId,
                departureDate,
                arrivalDate,
                recGuestQty,
                recRoomQty,
                destIds,
                recommendFor,
                languageCode,
                currencyCode,
                units
            );
            if (!string.IsNullOrWhiteSpace(response))
            {
                // API yanıtı JSON formatındaysa işleyin
                var errorResponse = JsonConvert.DeserializeObject<BookingApiErrorResponse>(response);

                if (errorResponse != null && !string.IsNullOrWhiteSpace(errorResponse.Message))
                {
                    return BadRequest(errorResponse.Message);
                }

                // Başarılı yanıtı işleyin ve istemciye dönün.
                return Ok(response);
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

    /// <summary>
    /// Get full details of rooms in the hotel
    /// </summary>
    /// <param name="hotelId">The value of hotel_id field from properties/list API  </param>
    /// <param name="departureDate">The check-out date</param>
    /// <param name="arrivalDate">The check-in date at hotel</param>
    /// <param name="recGuestQty">The number of adults separated by comma, and how you arrange them in rooms</param>
    /// <param name="recRoomQty">The number of rooms</param>
    /// <param name="currencyCode">The currency code</param>
    /// <param name="languageCode">One of the followings : en|en-us|ar|bg|ca|cs|da|de|el|es|es-ar|et|fi|fr|he|hr|hu|id|is|it|ja|ko|lt|lv|ms|nl|no|pl|pt|pt-br|ro|ru|sk|sl|sr|sv|th|tl|tr|uk|vi|zh|zh-tw</param>
    /// <param name="units">One of the following : metric|imperial</param>
    /// <returns></returns>
    [HttpGet("getRooms")]
    public async Task<IActionResult> GetRooms(
        [FromQuery][Required] int hotelId,
        [FromQuery][Required] string departureDate,
        [FromQuery][Required] string arrivalDate,
        [FromQuery][Required] int recGuestQty,
        [FromQuery][Required] int recRoomQty,
        [FromQuery] string currencyCode,
        [FromQuery] string languageCode,
        [FromQuery] string units)
    {
        try
        {
            var response = await _bookingApi.GetRooms(
                hotelId,
                departureDate,
                arrivalDate,
                recGuestQty,
                recRoomQty,
                currencyCode,
                languageCode,
                units
            );

            if (!string.IsNullOrWhiteSpace(response))
            {
                // API yanıtı JSON formatındaysa işleyin
                var errorResponse = JsonConvert.DeserializeObject<BookingApiErrorResponse>(response);

                if (errorResponse != null && !string.IsNullOrWhiteSpace(errorResponse.Message))
                {
                    return BadRequest(errorResponse.Message);
                }

                // Başarılı yanıtı işleyin ve istemciye dönün.
                return Ok(response);
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

    /// <summary>
    /// Get description of property by id
    /// </summary>
    /// <param name="hotelIds">The value of hotel_id from properties/list API</param>
    /// <param name="checkOut">The check-out date</param>
    /// <param name="languageCode">One of the followings : en|en-us|ar|bg|ca|cs|da|de|el|es|es-ar|et|fi|fr|he|hr|hu|id|is|it|ja|ko|lt|lv|ms|nl|no|pl|pt|pt-br|ro|ru|sk|sl|sr|sv|th|tl|tr|uk|vi|zh|zh-tw</param>
    /// <param name="checkIn">The check-in date at hotel</param>
    /// <returns></returns>
    [HttpGet("getDescription")]
    public async Task<IActionResult> GetDescription(
       [FromQuery][Required] int hotelIds,
       [FromQuery] string checkOut,
       [FromQuery] string languageCode,
       [FromQuery] string checkIn)
    {
        try
        {
            var response = await _bookingApi.GetDescription(
                hotelIds,
                checkOut,
                languageCode,
                checkIn
            );

            if (!string.IsNullOrWhiteSpace(response))
            {
                // API yanıtı JSON formatındaysa işleyin
                var errorResponse = JsonConvert.DeserializeObject<BookingApiErrorResponse>(response);

                if (errorResponse != null && !string.IsNullOrWhiteSpace(errorResponse.Message))
                {
                    return BadRequest(errorResponse.Message);
                }

                // Başarılı yanıtı işleyin ve istemciye dönün.
                return Ok(response);
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

    /// <summary>
    /// Get photos of hotel
    /// </summary>
    /// <param name="hotelIds">The value of hotel_id from properties/list API</param>
    /// <param name="languageCode">One of the followings : en|en-us|ar|bg|ca|cs|da|de|el|es|es-ar|et|fi|fr|he|hr|hu|id|is|it|ja|ko|lt|lv|ms|nl|no|pl|pt|pt-br|ro|ru|sk|sl|sr|sv|th|tl|tr|uk|vi|zh|zh-tw</param>
    /// <returns></returns>
    [HttpGet("getHotelPhotos")]
    public async Task<IActionResult> GetHotelPhotos(
        [FromQuery][Required] int hotelIds,
        [FromQuery] string languageCode)
    {
        try
        {
            var response = await _bookingApi.GetHotelPhotos(
                hotelIds,
                languageCode
            );

            if (!string.IsNullOrWhiteSpace(response))
            {
                // API yanıtı JSON formatındaysa işleyin
                var errorResponse = JsonConvert.DeserializeObject<BookingApiErrorResponse>(response);

                if (errorResponse != null && !string.IsNullOrWhiteSpace(errorResponse.Message))
                {
                    return BadRequest(errorResponse.Message);
                }

                // Başarılı yanıtı işleyin ve istemciye dönün.
                return Ok(response);
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

    /// <summary>
    /// Get featured reviews of stayed guests
    /// </summary>
    /// <param name="hotelId">The value of hotel_id from properties/list API</param>
    /// <param name="languageCode">One of the followings : en|en-us|ar|bg|ca|cs|da|de|el|es|es-ar|et|fi|fr|he|hr|hu|id|is|it|ja|ko|lt|lv|ms|nl|no|pl|pt|pt-br|ro|ru|sk|sl|sr|sv|th|tl|tr|uk|vi|zh|zh-tw</param>
    /// <returns></returns>
    [HttpGet("getFeaturedReviews")]
    public async Task<IActionResult> GetFeaturedReviews(
        [FromQuery][Required] int hotelId,
        [FromQuery] string languageCode)
    {
        try
        {
            var response = await _bookingApi.GetFeaturedReviews(
                hotelId,
                languageCode
            );

            if (!string.IsNullOrWhiteSpace(response))
            {
                // API yanıtı JSON formatındaysa işleyin
                var errorResponse = JsonConvert.DeserializeObject<BookingApiErrorResponse>(response);

                if (errorResponse != null && !string.IsNullOrWhiteSpace(errorResponse.Message))
                {
                    return BadRequest(errorResponse.Message);
                }

                // Başarılı yanıtı işleyin ve istemciye dönün.
                return Ok(response);
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

    /// <summary>
    /// Get policies of property by id
    /// </summary>
    /// <param name="hotelIds">The value of hotel_id from properties/list API</param>
    /// <param name="languageCode"></param>
    /// <param name="currencyCode"></param>
    /// <param name="departureDate"></param>
    /// <returns></returns>
    [HttpGet("getPolicies")]
    public async Task<IActionResult> GetPolicies(
        [FromQuery][Required] int hotelIds,
        [FromQuery] string languageCode,
        [FromQuery] string currencyCode,
        [FromQuery] string departureDate)
    {
        try
        {
            var response = await _bookingApi.GetPolicies(
                hotelIds,
                languageCode,
                currencyCode,
                departureDate
            );

            if (!string.IsNullOrWhiteSpace(response))
            {
                // API yanıtı JSON formatındaysa işleyin
                var errorResponse = JsonConvert.DeserializeObject<BookingApiErrorResponse>(response);

                if (errorResponse != null && !string.IsNullOrWhiteSpace(errorResponse.Message))
                {
                    return BadRequest(errorResponse.Message);
                }

                // Başarılı yanıtı işleyin ve istemciye dönün.
                return Ok(response);
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

    /// <summary>
    /// Get facilities of property by id
    /// </summary>
    /// <param name="hotelIds">The value of hotel_id from properties/list API</param>
    /// <param name="languageCode">One of the followings : en|en-us|ar|bg|ca|cs|da|de|el|es|es-ar|et|fi|fr|he|hr|hu|id|is|it|ja|ko|lt|lv|ms|nl|no|pl|pt|pt-br|ro|ru|sk|sl|sr|sv|th|tl|tr|uk|vi|zh|zh-tw</param>
    /// <returns></returns>
    [HttpGet("getFacilities")]
    public async Task<IActionResult> GetFacilities(
       [FromQuery][Required] int hotelIds,
       [FromQuery] string languageCode)
    {
        try
        {
            var response = await _bookingApi.GetFacilities(
                hotelIds,
                languageCode
            );

            if (!string.IsNullOrWhiteSpace(response))
            {
                // API yanıtı JSON formatındaysa işleyin
                var errorResponse = JsonConvert.DeserializeObject<BookingApiErrorResponse>(response);

                if (errorResponse != null && !string.IsNullOrWhiteSpace(errorResponse.Message))
                {
                    return BadRequest(errorResponse.Message);
                }

                // Başarılı yanıtı işleyin ve istemciye dönün.
                return Ok(response);
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

    /// <summary>
    /// List reviews of stayed guests
    /// </summary>
    /// <param name="hotelIds">The value of hotel_id from properties/list API</param>
    /// <param name="languageCode">One of the followings : en|en-us|ar|bg|ca|cs|da|de|el|es|es-ar|et|fi|fr|he|hr|hu|id|is|it|ja|ko|lt|lv|ms|nl|no|pl|pt|pt-br|ro|ru|sk|sl|sr|sv|th|tl|tr|uk|vi|zh|zh-tw</param>
    /// <param name="userSort">One of the followings : sort_most_relevant|sort_recent_desc|sort_recent_asc|sort_score_desc|sort_score_asc</param>
    /// <param name="rows">The number of items per page</param>
    /// <param name="offset">The number of items to ignore as offset for paging</param>
    /// <param name="filterLanguage">One of the followings (separated by comma for multiple values): en|en-us|ar|bg|ca|cs|da|de|el|es|es-ar|et|fi|fr|he|hr|hu|id|is|it|ja|ko|lt|lv|ms|nl|no|pl|pt|pt-br|ro|ru|sk|sl|sr|sv|th|tl|tr|uk|vi|zh|zh-tw</param>
    /// <param name="filterCustomerType">One of the followings (separated by comma for multiple values) : couple|family_with_children|review_category_group_of_friends|solo_traveller</param>
    /// <returns></returns>
    [HttpGet("getReviewsList")]
    public async Task<IActionResult> GetReviewsList(
       [FromQuery][Required] int hotelIds,
       [FromQuery] string languageCode,
       [FromQuery] string userSort,
       [FromQuery] int rows,
       [FromQuery] int offset,
       [FromQuery] string filterLanguage,
       [FromQuery] string filterCustomerType)
    {
        try
        {
            var response = await _bookingApi.GetReviewsList(
                hotelIds,
                languageCode,
                userSort,
                rows,
                offset,
                filterLanguage,
                filterCustomerType
            );

            if (!string.IsNullOrWhiteSpace(response))
            {
                // API yanıtı JSON formatındaysa işleyin
                var errorResponse = JsonConvert.DeserializeObject<BookingApiErrorResponse>(response);

                if (errorResponse != null && !string.IsNullOrWhiteSpace(errorResponse.Message))
                {
                    return BadRequest(errorResponse.Message);
                }

                // Başarılı yanıtı işleyin ve istemciye dönün.
                return Ok(response);
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

    /// <summary>
    /// Get reviewing scores
    /// </summary>
    /// <param name="hotelIds">The value of hotel_id from properties/list API</param>
    /// <param name="languageCode">One of the followings : en|en-us|ar|bg|ca|cs|da|de|el|es|es-ar|et|fi|fr|he|hr|hu|id|is|it|ja|ko|lt|lv|ms|nl|no|pl|pt|pt-br|ro|ru|sk|sl|sr|sv|th|tl|tr|uk|vi|zh|zh-tw</param>
    /// <returns></returns>
    [HttpGet("getScores")]
    public async Task<IActionResult> GetScores(
        [FromQuery][Required] int hotelIds,
        [FromQuery] string languageCode)
    {
        try
        {
            var response = await _bookingApi.GetScores(
                hotelIds,
                languageCode
            );
            if (!string.IsNullOrWhiteSpace(response))
            {
                // API yanıtı JSON formatındaysa işleyin
                var errorResponse = JsonConvert.DeserializeObject<BookingApiErrorResponse>(response);

                if (errorResponse != null && !string.IsNullOrWhiteSpace(errorResponse.Message))
                {
                    return BadRequest(errorResponse.Message);
                }

                // Başarılı yanıtı işleyin ve istemciye dönün.
                return Ok(response);
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
