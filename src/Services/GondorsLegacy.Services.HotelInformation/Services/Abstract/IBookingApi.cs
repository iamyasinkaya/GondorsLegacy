using GondorsLegacy.CrossCuttingCorners.Services;
using Refit;

namespace GondorsLegacy.Services.HotelInformation.Services.Abstract;

public interface IBookingApi : IApiService
{
    [Get("/properties/list")]
    Task<string> GetPropertyList(
        [AliasAs("offset")] int offset,
        [AliasAs("arrival_date")] string arrivalDate,
        [AliasAs("departure_date")] string departureDate,
        [AliasAs("guest_qty")] int guestQty,
        [AliasAs("dest_ids")] int destIds,
        [AliasAs("room_qty")] int roomQty,
        [AliasAs("search_type")] string searchType,
        [AliasAs("children_qty")] int childrenQty,
        [AliasAs("children_age")] string childrenAge,
        [AliasAs("search_id")] string searchId,
        [AliasAs("price_filter_currencycode")] string priceFilterCurrencyCode,
        [AliasAs("order_by")] string orderBy,
        [AliasAs("languagecode")] string languageCode,
        [AliasAs("travel_purpose")] string travelPurpose
    );

    [Get("/properties/list-by-map")]
    Task<string> GetPropertyListByMap(
        [AliasAs("arrival_date")] string arrivalDate,
        [AliasAs("departure_date")] string departureDate,
        [AliasAs("room_qty")] int roomQty,
        [AliasAs("guest_qty")] int guestQty,
        [AliasAs("bbox")] string bbox,
        [AliasAs("search_id")] string searchId,
        [AliasAs("children_age")] string childrenAge,
        [AliasAs("price_filter_currencycode")] string priceFilterCurrencyCode,
        [AliasAs("categories_filter")] string categoriesFilter,
        [AliasAs("languagecode")] string languageCode,
        [AliasAs("travel_purpose")] string travelPurpose,
        [AliasAs("children_qty")] int childrenQty,
        [AliasAs("order_by")] string orderBy
    );

    [Get("/properties/detail")]
    Task<string> GetPropertyDetail(
        [AliasAs("hotel_id")] int hotelId,
        [AliasAs("search_id")] string searchId,
        [AliasAs("departure_date")] string departureDate,
        [AliasAs("arrival_date")] string arrivalDate,
        [AliasAs("rec_guest_qty")] int recGuestQty,
        [AliasAs("rec_room_qty")] int recRoomQty,
        [AliasAs("dest_ids")] int destIds,
        [AliasAs("recommend_for")] int recommendFor,
        [AliasAs("languagecode")] string languageCode,
        [AliasAs("currency_code")] string currencyCode,
        [AliasAs("units")] string units
    );

    [Get("/properties/v2/get-rooms")]
    Task<string> GetRooms(
        [AliasAs("hotel_id")] int hotelId,
        [AliasAs("departure_date")] string departureDate,
        [AliasAs("arrival_date")] string arrivalDate,
        [AliasAs("rec_guest_qty")] int recGuestQty,
        [AliasAs("rec_room_qty")] int recRoomQty,
        [AliasAs("currency_code")] string currencyCode,
        [AliasAs("languagecode")] string languageCode,
        [AliasAs("units")] string units
    );

    [Get("/properties/get-description")]
    Task<string> GetDescription(
        [AliasAs("hotel_ids")] int hotelIds,
        [AliasAs("check_out")] string checkOut,
        [AliasAs("languagecode")] string languageCode,
        [AliasAs("check_in")] string checkIn
    );

    [Get("/properties/get-hotel-photos")]
    Task<string> GetHotelPhotos(
        [AliasAs("hotel_ids")] int hotelIds,
        [AliasAs("languagecode")] string languageCode
    );

    [Get("/properties/get-featured-reviews")]
    Task<string> GetFeaturedReviews(
        [AliasAs("hotel_id")] int hotelId,
        [AliasAs("languagecode")] string languageCode
    );

    [Get("/properties/get-policies")]
    Task<string> GetPolicies(
        [AliasAs("hotel_ids")] int hotelIds,
        [AliasAs("languagecode")] string languageCode,
        [AliasAs("currency_code")] string currencyCode,
        [AliasAs("departure_date")] string departureDate
    );

    [Get("/properties/get-facilities")]
    Task<string> GetFacilities(
       [AliasAs("hotel_ids")] int hotelIds,
       [AliasAs("languagecode")] string languageCode
   );

    [Get("/properties/get-static-map")]
    Task<string> GetStaticMap(
    [AliasAs("width")] int width,
    [AliasAs("longitude")] double longitude,
    [AliasAs("zoom")] int zoom,
    [AliasAs("height")] int height,
    [AliasAs("latitude")] double latitude,
    [AliasAs("currency_code")] string currencyCode,
    [AliasAs("languagecode")] string languageCode
    );

    [Get("/reviews/list")]
    Task<string> GetReviewsList(
        [AliasAs("hotel_ids")] int hotelIds,
        [AliasAs("languagecode")] string languageCode,
        [AliasAs("user_sort")] string userSort,
        [AliasAs("rows")] int rows,
        [AliasAs("offset")] int offset,
        [AliasAs("filter_language")] string filterLanguage,
        [AliasAs("filter_customer_type")] string filterCustomerType
    );

    [Get("/reviews/get-scores")]
    Task<string> GetScores(
        [AliasAs("hotel_ids")] int hotelIds,
        [AliasAs("languagecode")] string languageCode
    );
}
