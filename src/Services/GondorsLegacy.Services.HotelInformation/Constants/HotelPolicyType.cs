namespace GondorsLegacy.Services.HotelInformation.Constants;

/// <summary>
/// Otel politikalarını temsil eden enum.
/// </summary>
public enum HotelPolicyType
{
    CancellationAllowed,            // İptale İzin Verilir
    NoCancellationAllowed,          // İptale İzin Verilmez
    PetsAllowed,                    // Evcil Hayvanlara İzin Verilir
    NoPetsAllowed,                  // Evcil Hayvanlara İzin Verilmez
    SmokingAllowed,                 // Sigara İçmeye İzin Verilir
    NoSmokingAllowed,               // Sigara İçmeye İzin Verilmez
    BreakfastIncluded,              // Sabah Kahvaltısı Dahil
    NoBreakfastIncluded,            // Sabah Kahvaltısı Dahil Değil
    FreeCancellationAllowed,        // Ücretsiz İptale İzin Verilir
    PaidCancellationAllowed,        // Ücretli İptale İzin Verilir
    FreeWiFiAvailable,              // Ücretsiz Wi-Fi Erişimi Mevcut
    PaidWiFiAvailable,              // Ücretli Wi-Fi Erişimi Mevcut
    ParkingAvailable,               // Otopark Mevcut
    AirportTransferAvailable,       // Havaalanı Transferi Mevcut
    LaundryServiceAvailable,        // Çamaşırhane Hizmeti Mevcut
    RoomServiceAvailable,           // Oda Servisi Mevcut
    MiniBarAvailable,               // Minibar Mevcut
    GymAvailable,                   // Spor Salonu Mevcut
    SpaAvailable,                   // Spa Hizmeti Mevcut
    PoolAvailable,                  // Havuz Mevcut
    MeetingRoomsAvailable,           // Toplantı Odaları Mevcut
    RestaurantAvailable,           // Restoran Mevcut
    BarAvailable,                   // Bar Mevcut
    TwentyFourHourFrontDesk,               // 24 Saat Resepsiyon Hizmeti
    BusinessCenterAvailable,       // İş Merkezi Mevcut
    ChildCareServicesAvailable,    // Çocuk Bakım Hizmetleri Mevcut
    ConciergeServiceAvailable,     // Concierge Hizmeti Mevcut
    CurrencyExchangeAvailable,     // Döviz Bozdurma Hizmeti Mevcut
    DisabilityAccessible,          // Engellilere Uygun
    ExpressCheckIn,                // Hızlı Giriş İmkanı
    ExpressCheckOut,               // Hızlı Çıkış İmkanı
    IndoorPoolAvailable,           // Kapalı Havuz Mevcut
    OutdoorPoolAvailable,          // Açık Havuz Mevcut
    SaunaAvailable,                // Sauna Hizmeti Mevcut
    JacuzziAvailable,              // Jakuzi Mevcut
    TerraceAvailable,              // Teras Mevcut
    GardenAvailable,               // Bahçe Mevcut
    BeachAccessAvailable,          // Plaj Erişimi Mevcut
    TennisCourtsAvailable,         // Tenis Kortları Mevcut
    GolfCourseAvailable,           // Golf Sahası Mevcut
    BikeRentalAvailable,           // Bisiklet Kiralama Mevcut
    CarRentalAvailable,            // Araç Kiralama Hizmeti Mevcut
    ShuttleServiceAvailable,       // Servis Hizmeti Mevcut
    BabysittingServicesAvailable,  // Bebek Bakım Hizmetleri Mevcut
    LibraryAvailable,              // Kütüphane Mevcut
    GameRoomAvailable,             // Oyun Odası Mevcut
    MovieTheaterAvailable,         // Sinema Salonu Mevcut
    LiveEntertainmentAvailable,    // Canlı Eğlence Programları Mevcut
    KaraokeAvailable,              // Karaoke Hizmeti Mevcut
    DanceFloorAvailable,           // Dans Pisti Mevcut
    IndoorSportsFacilitiesAvailable,  // Kapalı Spor Tesisleri Mevcut
    OutdoorSportsFacilitiesAvailable, // Açık Spor Tesisleri Mevcut
    PetFriendlyRoomsAvailable,     // Evcil Hayvan Dostu Odalar Mevcut
    ChildFriendlyFacilities,       // Çocuk Dostu Tesis
    EcoFriendlyPolicies,           // Çevre Dostu Politikalar
    AllInclusivePackagesAvailable, // Her Şey Dahil Paketler Mevcut
    VeganMenuOptionsAvailable,     // Vejetaryen Menü Seçenekleri Mevcut
    HalalMenuOptionsAvailable,     // Helal Menü Seçenekleri Mevcut
    KosherMenuOptionsAvailable,    // Koşer Menü Seçenekleri Mevcut
    OrganicFoodOptionsAvailable    // Organik Yiyecek Seçenekleri Mevcut

}