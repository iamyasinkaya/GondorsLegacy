using GondorsLegacy.Services.HotelInformation.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
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
    /// <param name="offset"></param>
    /// <param name="arrivalDate"></param>
    /// <param name="departureDate"></param>
    /// <param name="guestQty"></param>
    /// <param name="destIds"></param>
    /// <param name="roomQty"></param>
    /// <param name="searchType"></param>
    /// <param name="childrenQty"></param>
    /// <param name="childrenAge"></param>
    /// <param name="searchId"></param>
    /// <param name="priceFilterCurrencyCode"></param>
    /// <param name="orderBy"></param>
    /// <param name="languageCode"></param>
    /// <param name="travelPurpose"></param>
    /// <returns></returns>
    [HttpGet("getPropertyList")]
    public async Task<IActionResult> GetPropertyList(
        [FromQuery] int offset,
        [FromQuery] string arrivalDate,
        [FromQuery] string departureDate,
        [FromQuery] int guestQty,
        [FromQuery] int destIds,
        [FromQuery] int roomQty,
        [FromQuery] string searchType,
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

            return Ok(response);
        }
        catch (ApiException ex)
        {
            // Hata işleme kodunu burada ekleyebilirsiniz.
            return StatusCode((int)ex.StatusCode, ex.Content);
        }
    }

    /// <summary>
    /// List properties by coordinate of bounding box
    /// </summary>
    /// <param name="arrivalDate"></param>
    /// <param name="departureDate"></param>
    /// <param name="roomQty"></param>
    /// <param name="guestQty"></param>
    /// <param name="bbox"></param>
    /// <param name="searchId"></param>
    /// <param name="childrenAge"></param>
    /// <param name="priceFilterCurrencyCode"></param>
    /// <param name="categoriesFilter"></param>
    /// <param name="languageCode"></param>
    /// <param name="travelPurpose"></param>
    /// <param name="childrenQty"></param>
    /// <param name="orderBy"></param>
    /// <returns></returns>
    [HttpGet("getPropertyListByMap")]
    public async Task<IActionResult> GetPropertyListByMap(
        [FromQuery] string arrivalDate,
        [FromQuery] string departureDate,
        [FromQuery] int roomQty,
        [FromQuery] int guestQty,
        [FromQuery] string bbox,
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

            return Ok(response);
        }
        catch (ApiException ex)
        {
            // Hata işleme kodunu burada ekleyebilirsiniz.
            return StatusCode((int)ex.StatusCode, ex.Content);
        }
    }

    /// <summary>
    /// Get brief information of a property
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="searchId"></param>
    /// <param name="departureDate"></param>
    /// <param name="arrivalDate"></param>
    /// <param name="recGuestQty"></param>
    /// <param name="recRoomQty"></param>
    /// <param name="destIds"></param>
    /// <param name="recommendFor"></param>
    /// <param name="languageCode"></param>
    /// <param name="currencyCode"></param>
    /// <param name="units"></param>
    /// <returns></returns>
    [HttpGet("getPropertyDetail")]
    public async Task<IActionResult> GetPropertyDetail(
        [FromQuery] int hotelId,
        [FromQuery] string searchId,
        [FromQuery] string departureDate,
        [FromQuery] string arrivalDate,
        [FromQuery] int recGuestQty,
        [FromQuery] int recRoomQty,
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

            return Ok(response);
        }
        catch (ApiException ex)
        {
            // Hata işleme kodunu burada ekleyebilirsiniz.
            return StatusCode((int)ex.StatusCode, ex.Content);
        }
    }

    /// <summary>
    /// Get full details of rooms in the hotel
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="departureDate"></param>
    /// <param name="arrivalDate"></param>
    /// <param name="recGuestQty"></param>
    /// <param name="recRoomQty"></param>
    /// <param name="currencyCode"></param>
    /// <param name="languageCode"></param>
    /// <param name="units"></param>
    /// <returns></returns>
    [HttpGet("getRooms")]
    public async Task<IActionResult> GetRooms(
        [FromQuery] int hotelId,
        [FromQuery] string departureDate,
        [FromQuery] string arrivalDate,
        [FromQuery] int recGuestQty,
        [FromQuery] int recRoomQty,
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

            return Ok(response);
        }
        catch (ApiException ex)
        {
            // Hata işleme kodunu burada ekleyebilirsiniz.
            return StatusCode((int)ex.StatusCode, ex.Content);
        }
    }

    /// <summary>
    /// Get description of property by id
    /// </summary>
    /// <param name="hotelIds"></param>
    /// <param name="checkOut"></param>
    /// <param name="languageCode"></param>
    /// <param name="checkIn"></param>
    /// <returns></returns>
    [HttpGet("getDescription")]
    public async Task<IActionResult> GetDescription(
       [FromQuery] int hotelIds,
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

            return Ok(response);
        }
        catch (ApiException ex)
        {
            // Hata işleme kodunu burada ekleyebilirsiniz.
            return StatusCode((int)ex.StatusCode, ex.Content);
        }
    }

    [HttpGet("getHotelPhotos")]
    public async Task<IActionResult> GetHotelPhotos(
        [FromQuery] int hotelIds,
        [FromQuery] string languageCode)
    {
        try
        {
            var response = await _bookingApi.GetHotelPhotos(
                hotelIds,
                languageCode
            );

            return Ok(response);
        }
        catch (ApiException ex)
        {
            // Hata işleme kodunu burada ekleyebilirsiniz.
            return StatusCode((int)ex.StatusCode, ex.Content);
        }
    }

    [HttpGet("getFeaturedReviews")]
    public async Task<IActionResult> GetFeaturedReviews(
        [FromQuery] int hotelId,
        [FromQuery] string languageCode)
    {
        try
        {
            var response = await _bookingApi.GetFeaturedReviews(
                hotelId,
                languageCode
            );

            return Ok(response);
        }
        catch (ApiException ex)
        {
            // Hata işleme kodunu burada ekleyebilirsiniz.
            return StatusCode((int)ex.StatusCode, ex.Content);
        }
    }

    [HttpGet("getPolicies")]
    public async Task<IActionResult> GetPolicies(
        [FromQuery] int hotelIds,
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

            return Ok(response);
        }
        catch (ApiException ex)
        {
            // Hata işleme kodunu burada ekleyebilirsiniz.
            return StatusCode((int)ex.StatusCode, ex.Content);
        }
    }

    [HttpGet("getFacilities")]
    public async Task<IActionResult> GetFacilities(
       [FromQuery] int hotelIds,
       [FromQuery] string languageCode)
    {
        try
        {
            var response = await _bookingApi.GetFacilities(
                hotelIds,
                languageCode
            );

            return Ok(response);
        }
        catch (ApiException ex)
        {
            // Hata işleme kodunu burada ekleyebilirsiniz.
            return StatusCode((int)ex.StatusCode, ex.Content);
        }
    }

    /// <summary>
    /// List reviews of stayed guests
    /// </summary>
    /// <param name="hotelIds"></param>
    /// <param name="languageCode"></param>
    /// <param name="userSort"></param>
    /// <param name="rows"></param>
    /// <param name="offset"></param>
    /// <param name="filterLanguage"></param>
    /// <param name="filterCustomerType"></param>
    /// <returns></returns>
    [HttpGet("getReviewsList")]
    public async Task<IActionResult> GetReviewsList(
       [FromQuery] int hotelIds,
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

            return Ok(response);
        }
        catch (ApiException ex)
        {
            // Hata işleme kodunu burada ekleyebilirsiniz.
            return StatusCode((int)ex.StatusCode, ex.Content);
        }
    }
    /// <summary>
    /// Get reviewing scores
    /// </summary>
    /// <param name="hotelIds"></param>
    /// <param name="languageCode"></param>
    /// <returns></returns>
    [HttpGet("getScores")]
    public async Task<IActionResult> GetScores(
        [FromQuery] int hotelIds,
        [FromQuery] string languageCode)
    {
        try
        {
            var response = await _bookingApi.GetScores(
                hotelIds,
                languageCode
            );

            return Ok(response);
        }
        catch (ApiException ex)
        {
            // Hata işleme kodunu burada ekleyebilirsiniz.
            return StatusCode((int)ex.StatusCode, ex.Content);
        }
    }
}
