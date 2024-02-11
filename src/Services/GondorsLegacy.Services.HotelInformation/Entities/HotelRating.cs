using GondorsLegacy.Domain.Entities;

namespace GondorsLegacy.Services.HotelInformation.Entities;

/// <summary>
/// Bir otel için kullanıcı tarafından verilen bir değerlendirmeyi temsil eder.
/// </summary>
public sealed class HotelRating : Entity<Guid>
{
    /// <summary>
    /// Değerlendirilen otelin benzersiz kimliğini alır veya ayarlar.
    /// </summary>
    public Guid HotelId { get; set; }

    /// <summary>
    /// Otele verilen yıldız sayısını alır veya ayarlar.
    /// </summary>
    public int Stars { get; set; }

    /// <summary>
    /// Değerlendirmeye ek açıklama alır veya ayarlar. (opsiyonel)
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Temizlik yönünden verilen puanı alır veya ayarlar. (0-10 arası)
    /// </summary>
    public float Cleanliness { get; set; }

    /// <summary>
    /// Hizmet kalitesi yönünden verilen puanı alır veya ayarlar. (0-10 arası)
    /// </summary>
    public float ServiceQuality { get; set; }

    /// <summary>
    /// Fiyat performansı yönünden verilen puanı alır veya ayarlar. (0-10 arası)
    /// </summary>
    public float ValueForMoney { get; set; }

    /// <summary>
    /// Konum yönünden verilen puanı alır veya ayarlar. (0-10 arası)
    /// </summary>
    public float Location { get; set; }

    /// <summary>
    /// Olanaklar yönünden verilen puanı alır veya ayarlar. (0-10 arası)
    /// </summary>
    public float Amenities { get; set; }
}
