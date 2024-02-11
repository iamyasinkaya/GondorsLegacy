using GondorsLegacy.Domain.Entities;

namespace GondorsLegacy.Services.HotelInformation.Entities;

public sealed class Hotel : Entity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<Address>? Addresses { get; set; } // Birden fazla adres
    public string? EmailAddress { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
    public List<HotelRoom>? Rooms { get; set; } // Otelin odaları
    public List<HotelService>? Services { get; set; } // Otelin sunduğu hizmetler
    public List<HotelPolicy>? Policies { get; set; } // Otelin politikaları
    public List<HotelCustomerReview>? HotelCustomerReviews { get; set; } // Otel müşteri yorumları
    public List<HotelRating>? HotelRatings { get; set; }
}
