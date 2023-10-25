using Newtonsoft.Json;

namespace GondorsLegacy.Services.HotelInformation.Models;


public class GetPropertyListResponseModel
{
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("result")]
    public List<Hotel> Hotels { get; set; }
}

public class Hotel
{
    [JsonProperty("accommodation_type_name")]
    public string AccommodationTypeName { get; set; }

    [JsonProperty("wishlist_count")]
    public int WishlistCount { get; set; }

    [JsonProperty("main_photo_url")]
    public string MainPhotoUrl { get; set; }

    [JsonProperty("review_score")]
    public string? ReviewScore { get; set; }

    [JsonProperty("review_recommendation")]
    public string ReviewRecommendation { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("district_id")]
    public int DistrictId { get; set; }

    [JsonProperty("default_language")]
    public string DefaultLanguage { get; set; }

    [JsonProperty("hotel_name_trans")]
    public string HotelNameTrans { get; set; }

    [JsonProperty("is_mobile_deal")]
    public int IsMobileDeal { get; set; }

    [JsonProperty("preferred")]
    public int Preferred { get; set; }

    [JsonProperty("zip")]
    public string Zip { get; set; }

    [JsonProperty("accommodation_type")]
    public int AccommodationType { get; set; }

    [JsonProperty("is_no_prepayment_block")]
    public int IsNoPrepaymentBlock { get; set; }

    [JsonProperty("class_is_estimated")]
    public int ClassIsEstimated { get; set; }

    [JsonProperty("address_trans")]
    public string AddressTrans { get; set; }

    [JsonProperty("price_is_final")]
    public int PriceIsFinal { get; set; }

    [JsonProperty("hotel_include_breakfast")]
    public int HotelIncludeBreakfast { get; set; }

    [JsonProperty("in_best_district")]
    public int InBestDistrict { get; set; }

    [JsonProperty("cc1")]
    public string CC1 { get; set; }

    [JsonProperty("urgency_room_c")]
    public int UrgencyRoomC { get; set; }

    [JsonProperty("updated_checkout")]
    public DateTime? UpdatedCheckout { get; set; }

    [JsonProperty("hotel_has_vb_boost")]
    public int HotelHasVbBoost { get; set; }

    [JsonProperty("badges")]
    public List<Badge> Badges { get; set; }

    [JsonProperty("is_genius_deal")]
    public int IsGeniusDeal { get; set; }

    [JsonProperty("native_ad_id")]
    public string NativeAdId { get; set; }

    [JsonProperty("country_trans")]
    public string CountryTrans { get; set; }

    [JsonProperty("mobile_discount_percentage")]
    public string MobileDiscountPercentage { get; set; }

    [JsonProperty("distance")]
    public string Distance { get; set; }

    [JsonProperty("longitude")]
    public decimal Longitude { get; set; }

    [JsonProperty("soldout")]
    public int Soldout { get; set; }

    [JsonProperty("district")]
    public string District { get; set; }

    [JsonProperty("is_geo_rate")]
    public string IsGeoRate { get; set; }

    [JsonProperty("native_ads_cpc")]
    public string NativeAdsCpc { get; set; }

    [JsonProperty("has_swimming_pool")]
    public int HasSwimmingPool { get; set; }

    [JsonProperty("cc_required")]
    public int CcRequired { get; set; }

    [JsonProperty("currencycode")]
    public string CurrencyCode { get; set; }

    [JsonProperty("price_breakdown")]
    public PriceBreakdown PriceBreakdown { get; set; }

    [JsonProperty("cant_book")]
    public object CantBook { get; set; }

    [JsonProperty("hotel_facilities")]
    public string HotelFacilities { get; set; }

    [JsonProperty("main_photo_id")]
    public int MainPhotoId { get; set; }

    [JsonProperty("city_in_trans")]
    public string CityInTrans { get; set; }

    [JsonProperty("latitude")]
    public decimal Latitude { get; set; }

    [JsonProperty("selected_review_topic")]
    public object SelectedReviewTopic { get; set; }

    [JsonProperty("is_smart_deal")]
    public int IsSmartDeal { get; set; }

    [JsonProperty("block_ids")]
    public List<string> BlockIds { get; set; }

    [JsonProperty("bwallet")]
    public Bwallet Bwallet { get; set; }

    [JsonProperty("hotel_name")]
    public string HotelName { get; set; }

    [JsonProperty("districts")]
    public string Districts { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("class")]
    public string Class { get; set; }

    [JsonProperty("city_name_en")]
    public string CityNameEn { get; set; }

    [JsonProperty("native_ads_tracking")]
    public string NativeAdsTracking { get; set; }

    [JsonProperty("children_not_allowed")]
    public object ChildrenNotAllowed { get; set; }

    [JsonProperty("review_nr")]
    public int? ReviewNr { get; set; }

    [JsonProperty("checkout")]
    public CheckOut CheckOut { get; set; }

    [JsonProperty("min_total_price")]
    public int MinTotalPrice { get; set; }

    [JsonProperty("distance_to_cc")]
    public string DistanceToCc { get; set; }

    [JsonProperty("city_trans")]
    public string CityTrans { get; set; }

    [JsonProperty("default_wishlist_name")]
    public string DefaultWishlistName { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("timezone")]
    public string Timezone { get; set; }

    [JsonProperty("review_score_word")]
    public string ReviewScoreWord { get; set; }

    [JsonProperty("preferred_plus")]
    public int PreferredPlus { get; set; }

    [JsonProperty("extended")]
    public int Extended { get; set; }

    [JsonProperty("hotel_id")]
    public int HotelId { get; set; }

    [JsonProperty("countrycode")]
    public string CountryCode { get; set; }

    [JsonProperty("has_free_parking")]
    public int HasFreeParking { get; set; }

    [JsonProperty("is_city_center")]
    public int IsCityCenter { get; set; }

    [JsonProperty("deals")]
    public Deals Deals { get; set; }

    [JsonProperty("is_free_cancellable")]
    public int IsFreeCancellable { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("ufi")]
    public int Ufi { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("genius_discount_percentage")]
    public int GeniusDiscountPercentage { get; set; }

    [JsonProperty("matching_units_configuration")]
    public MatchingUnitsConfiguration MatchingUnitsConfiguration { get; set; }

    [JsonProperty("checkin")]
    public CheckIn CheckIn { get; set; }
}

public class Badge
{
    [JsonProperty("badge_variant")]
    public string BadgeVariant { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}

public class PriceBreakdown
{
    [JsonProperty("gross_price")]
    public string GrossPrice { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("has_tax_exceptions")]
    public int HasTaxExceptions { get; set; }

    [JsonProperty("all_inclusive_price")]
    public string AllInclusivePrice { get; set; }

    [JsonProperty("sum_excluded_raw")]
    public string SumExcludedRaw { get; set; }

    [JsonProperty("has_fine_print_charges")]
    public int HasFinePrintCharges { get; set; }

    [JsonProperty("has_incalculable_charges")]
    public int HasIncalculableCharges { get; set; }
}

public class Bwallet
{
    [JsonProperty("hotel_eligibility")]
    public int HotelEligibility { get; set; }
}

public class Deals
{
    [JsonProperty("deal_attributes")]
    public object DealAttributes { get; set; }

    [JsonProperty("deals_available")]
    public DealsAvailable DealsAvailable { get; set; }

    [JsonProperty("deal_events_killswitch")]
    public int DealEventsKillswitch { get; set; }
}

public class DealsAvailable
{
    [JsonProperty("has_flash_deal")]
    public int HasFlashDeal { get; set; }
}

public class MatchingUnitsConfiguration
{
    [JsonProperty("matching_units_common_config")]
    public MatchingUnitsCommonConfig MatchingUnitsCommonConfig { get; set; }
}

public class MatchingUnitsCommonConfig
{
    [JsonProperty("unit_type_id")]
    public int UnitTypeId { get; set; }

    [JsonProperty("localized_area")]
    public object LocalizedArea { get; set; }
}

public class CheckIn
{
    [JsonProperty("until")]
    public string Until { get; set; }

    [JsonProperty("from")]
    public string From { get; set; }
}

public class CheckOut
{
    [JsonProperty("until")]
    public string Until { get; set; }

    [JsonProperty("from")]
    public string From { get; set; }
}
