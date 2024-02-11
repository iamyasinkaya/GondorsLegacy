using GondorsLegacy.Domain.Entities;

namespace GondorsLegacy.Services.HotelInformation.Entities;
public sealed class HotelCustomerReview : Entity<Guid>
{
    public Guid CustomerId { get; set; }     // Müşteri Idsi
    public Guid HotelId { get; set; }        // Otel Idsi
    public string? ReviewTitle { get; set; }      // İnceleme Başlığı
    public string? ReviewText { get; set; }       // İnceleme Metni
    public DateTime ReviewDate { get; set; }      // İnceleme Tarihi
    public bool IsRecommended { get; set; }       // Tavsiye Ediliyor mu?

    // İsteğe bağlı ek özellikler
    public bool IsVerified { get; set; }         // Doğrulanmış mı?
    public bool IsHelpful { get; set; }          // Faydalı Bulundu mu?
    public int Likes { get; set; }               // Beğeni Sayısı
    public int Dislikes { get; set; }            // Beğenmeme Sayısı
}
