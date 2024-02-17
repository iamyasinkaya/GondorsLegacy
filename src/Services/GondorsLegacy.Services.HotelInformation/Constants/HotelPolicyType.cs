namespace GondorsLegacy.Services.HotelInformation.Constants;

/// <summary>
/// Otel politikalarını temsil eden enum.
/// </summary>
public record HotelPolicyType(int Value, string Name)
{

    public static HotelPolicyType CancellationAllowed { get; } = new HotelPolicyType(1, "İptale İzin Verilir");
    public static HotelPolicyType NoCancellationAllowed { get; } = new HotelPolicyType(2, "İptale İzin Verilmez");
    public static HotelPolicyType PetsAllowed { get; } = new HotelPolicyType(3, "Evcil Hayvanlara İzin Verilir");
    public static HotelPolicyType NoPetsAllowed { get; } = new HotelPolicyType(4, "Evcil Hayvanlara İzin Verilmez");
    public static HotelPolicyType SmokingAllowed { get; } = new HotelPolicyType(5, "Sigara İçmeye İzin Verilir");
    public static HotelPolicyType NoSmokingAllowed { get; } = new HotelPolicyType(6, "Sigara İçmeye İzin Verilmez");
    public static HotelPolicyType BreakfastIncluded { get; } = new HotelPolicyType(7, "Sabah Kahvaltısı Dahil");
    public static HotelPolicyType NoBreakfastIncluded { get; } = new HotelPolicyType(8, "Sabah Kahvaltısı Dahil Değil");
    public static HotelPolicyType FreeCancellationAllowed { get; } = new HotelPolicyType(9, "Ücretsiz İptale İzin Verilir");
    public static HotelPolicyType PaidCancellationAllowed { get; } = new HotelPolicyType(10, "Ücretli İptale İzin Verilir");
    public static HotelPolicyType FreeWiFiAvailable { get; } = new HotelPolicyType(11, "Ücretsiz Wi-Fi Erişimi Mevcut");
    public static HotelPolicyType PaidWiFiAvailable { get; } = new HotelPolicyType(12, "Ücretli Wi-Fi Erişimi Mevcut");
    public static HotelPolicyType ParkingAvailable { get; } = new HotelPolicyType(13, "Otopark Mevcut");
    public static HotelPolicyType AirportTransferAvailable { get; } = new HotelPolicyType(14, "Havaalanı Transferi Mevcut");
    public static HotelPolicyType LaundryServiceAvailable { get; } = new HotelPolicyType(15, "Çamaşırhane Hizmeti Mevcut");
    public static HotelPolicyType RoomServiceAvailable { get; } = new HotelPolicyType(16, "Oda Servisi Mevcut");
    public static HotelPolicyType MiniBarAvailable { get; } = new HotelPolicyType(17, "Minibar Mevcut");
    public static HotelPolicyType GymAvailable { get; } = new HotelPolicyType(18, "Spor Salonu Mevcut");
    public static HotelPolicyType SpaAvailable { get; } = new HotelPolicyType(19, "Spa Hizmeti Mevcut");
    public static HotelPolicyType PoolAvailable { get; } = new HotelPolicyType(20, "Havuz Mevcut");
    public static HotelPolicyType MeetingRoomsAvailable { get; } = new HotelPolicyType(21, "Toplantı Odaları Mevcut");
    public static HotelPolicyType RestaurantAvailable { get; } = new HotelPolicyType(22, "Restoran Mevcut");
    public static HotelPolicyType BarAvailable { get; } = new HotelPolicyType(23, "Bar Mevcut");
    public static HotelPolicyType TwentyFourHourFrontDesk { get; } = new HotelPolicyType(24, "24 Saat Resepsiyon Hizmeti");
    public static HotelPolicyType BusinessCenterAvailable { get; } = new HotelPolicyType(25, "İş Merkezi Mevcut");
    public static HotelPolicyType ChildCareServicesAvailable { get; } = new HotelPolicyType(26, "Çocuk Bakım Hizmetleri Mevcut");
    public static HotelPolicyType ConciergeServiceAvailable { get; } = new HotelPolicyType(27, "Concierge Hizmeti Mevcut");
    public static HotelPolicyType CurrencyExchangeAvailable { get; } = new HotelPolicyType(28, "Döviz Bozdurma Hizmeti Mevcut");
    public static HotelPolicyType DisabilityAccessible { get; } = new HotelPolicyType(29, "Engellilere Uygun");
    public static HotelPolicyType ExpressCheckIn { get; } = new HotelPolicyType(30, "Hızlı Giriş İmkanı");
    public static HotelPolicyType ExpressCheckOut { get; } = new HotelPolicyType(31, "Hızlı Çıkış İmkanı");
    public static HotelPolicyType IndoorPoolAvailable { get; } = new HotelPolicyType(32, "Kapalı Havuz Mevcut");
    public static HotelPolicyType OutdoorPoolAvailable { get; } = new HotelPolicyType(33, "Açık Havuz Mevcut");
    public static HotelPolicyType SaunaAvailable { get; } = new HotelPolicyType(34, "Sauna Hizmeti Mevcut");
    public static HotelPolicyType JacuzziAvailable { get; } = new HotelPolicyType(35, "Jakuzi Mevcut");
    public static HotelPolicyType TerraceAvailable { get; } = new HotelPolicyType(36, "Teras Mevcut");
    public static HotelPolicyType GardenAvailable { get; } = new HotelPolicyType(37, "Bahçe Mevcut");
    public static HotelPolicyType BeachAccessAvailable { get; } = new HotelPolicyType(38, "Plaj Erişimi Mevcut");
    public static HotelPolicyType TennisCourtsAvailable { get; } = new HotelPolicyType(39, "Tenis Kortları Mevcut");
    public static HotelPolicyType GolfCourseAvailable { get; } = new HotelPolicyType(40, "Golf Sahası Mevcut");
    public static HotelPolicyType BikeRentalAvailable { get; } = new HotelPolicyType(41, "Bisiklet Kiralama Mevcut");
    public static HotelPolicyType CarRentalAvailable { get; } = new HotelPolicyType(42, "Araç Kiralama Hizmeti Mevcut");
    public static HotelPolicyType ShuttleServiceAvailable { get; } = new HotelPolicyType(43, "Servis Hizmeti Mevcut");
    public static HotelPolicyType BabysittingServicesAvailable { get; } = new HotelPolicyType(44, "Bebek Bakım Hizmetleri Mevcut");
    public static HotelPolicyType LibraryAvailable { get; } = new HotelPolicyType(45, "Kütüphane Mevcut");
    public static HotelPolicyType GameRoomAvailable { get; } = new HotelPolicyType(46, "Oyun Odası Mevcut");
    public static HotelPolicyType MovieTheaterAvailable { get; } = new HotelPolicyType(47, "Sinema Salonu Mevcut");
    public static HotelPolicyType LiveEntertainmentAvailable { get; } = new HotelPolicyType(48, "Canlı Eğlence Programları Mevcut");
    public static HotelPolicyType KaraokeAvailable { get; } = new HotelPolicyType(49, "Karaoke Hizmeti Mevcut");
    public static HotelPolicyType DanceFloorAvailable { get; } = new HotelPolicyType(50, "Dans Pisti Mevcut");
    public static HotelPolicyType IndoorSportsFacilitiesAvailable { get; } = new HotelPolicyType(51, "Kapalı Spor Tesisleri Mevcut");
    public static HotelPolicyType OutdoorSportsFacilitiesAvailable { get; } = new HotelPolicyType(52, "Açık Spor Tesisleri Mevcut");
    public static HotelPolicyType PetFriendlyRoomsAvailable { get; } = new HotelPolicyType(53, "Evcil Hayvan Dostu Odalar Mevcut");
    public static HotelPolicyType ChildFriendlyFacilities { get; } = new HotelPolicyType(54, "Çocuk Dostu Tesis");
    public static HotelPolicyType EcoFriendlyPolicies { get; } = new HotelPolicyType(55, "Çevre Dostu Politikalar");
    public static HotelPolicyType AllInclusivePackagesAvailable { get; } = new HotelPolicyType(56, "Her Şey Dahil Paketler Mevcut");
    public static HotelPolicyType VeganMenuOptionsAvailable { get; } = new HotelPolicyType(57, "Vejetaryen Menü Seçenekleri Mevcut");
    public static HotelPolicyType HalalMenuOptionsAvailable { get; } = new HotelPolicyType(58, "Helal Menü Seçenekleri Mevcut");
    public static HotelPolicyType KosherMenuOptionsAvailable { get; } = new HotelPolicyType(59, "Koşer Menü Seçenekleri Mevcut");
    public static HotelPolicyType OrganicFoodOptionsAvailable { get; } = new HotelPolicyType(60, "Organik Yiyecek Seçenekleri Mevcut");
    public static implicit operator int(HotelPolicyType hotelPolicyType) => hotelPolicyType.Value;
    public static implicit operator HotelPolicyType(int value) => value switch
    {
        1 => HotelPolicyType.CancellationAllowed,
        2 => HotelPolicyType.NoCancellationAllowed,
        3 => HotelPolicyType.PetsAllowed,
        4 => HotelPolicyType.NoPetsAllowed,
        5 => HotelPolicyType.SmokingAllowed,
        6 => HotelPolicyType.NoSmokingAllowed,
        7 => HotelPolicyType.BreakfastIncluded,
        8 => HotelPolicyType.NoBreakfastIncluded,
        9 => HotelPolicyType.FreeCancellationAllowed,
        10 => HotelPolicyType.PaidCancellationAllowed,
        11 => HotelPolicyType.FreeWiFiAvailable,
        12 => HotelPolicyType.PaidWiFiAvailable,
        13 => HotelPolicyType.ParkingAvailable,
        14 => HotelPolicyType.AirportTransferAvailable,
        15 => HotelPolicyType.LaundryServiceAvailable,
        16 => HotelPolicyType.RoomServiceAvailable,
        17 => HotelPolicyType.MiniBarAvailable,
        18 => HotelPolicyType.GymAvailable,
        19 => HotelPolicyType.SpaAvailable,
        20 => HotelPolicyType.PoolAvailable,
        21 => HotelPolicyType.MeetingRoomsAvailable,
        22 => HotelPolicyType.RestaurantAvailable,
        23 => HotelPolicyType.BarAvailable,
        24 => HotelPolicyType.TwentyFourHourFrontDesk,
        25 => HotelPolicyType.BusinessCenterAvailable,
        26 => HotelPolicyType.ChildCareServicesAvailable,
        27 => HotelPolicyType.ConciergeServiceAvailable,
        28 => HotelPolicyType.CurrencyExchangeAvailable,
        29 => HotelPolicyType.DisabilityAccessible,
        30 => HotelPolicyType.ExpressCheckIn,
        31 => HotelPolicyType.ExpressCheckOut,
        32 => HotelPolicyType.IndoorPoolAvailable,
        33 => HotelPolicyType.OutdoorPoolAvailable,
        34 => HotelPolicyType.SaunaAvailable,
        35 => HotelPolicyType.JacuzziAvailable,
        36 => HotelPolicyType.TerraceAvailable,
        37 => HotelPolicyType.GardenAvailable,
        38 => HotelPolicyType.BeachAccessAvailable,
        39 => HotelPolicyType.TennisCourtsAvailable,
        40 => HotelPolicyType.GolfCourseAvailable,
        41 => HotelPolicyType.BikeRentalAvailable,
        42 => HotelPolicyType.CarRentalAvailable,
        43 => HotelPolicyType.ShuttleServiceAvailable,
        44 => HotelPolicyType.BabysittingServicesAvailable,
        45 => HotelPolicyType.LibraryAvailable,
        46 => HotelPolicyType.GameRoomAvailable,
        47 => HotelPolicyType.MovieTheaterAvailable,
        48 => HotelPolicyType.LiveEntertainmentAvailable,
        49 => HotelPolicyType.KaraokeAvailable,
        50 => HotelPolicyType.DanceFloorAvailable,
        51 => HotelPolicyType.IndoorSportsFacilitiesAvailable,
        52 => HotelPolicyType.OutdoorSportsFacilitiesAvailable,
        53 => HotelPolicyType.PetFriendlyRoomsAvailable,
        54 => HotelPolicyType.ChildFriendlyFacilities,
        55 => HotelPolicyType.EcoFriendlyPolicies,
        56 => HotelPolicyType.AllInclusivePackagesAvailable,
        57 => HotelPolicyType.VeganMenuOptionsAvailable,
        58 => HotelPolicyType.HalalMenuOptionsAvailable,
        59 => HotelPolicyType.KosherMenuOptionsAvailable,
        60 => HotelPolicyType.OrganicFoodOptionsAvailable,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Invalid value")
    };

    public bool IsHotelPolicyType => this == GameRoomAvailable || this == HalalMenuOptionsAvailable; //TODO: countinue

    public override string ToString() => Name;

}
