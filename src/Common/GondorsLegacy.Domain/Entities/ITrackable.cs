namespace GondorsLegacy.Domain.Entities;

/// <summary>
/// Bir nesnenin durumu, konumu veya ilerlemesi gibi bilgilerin kaydedilebilir ve takip edilebilir olduğunu belirtir.
/// </summary>
public interface ITrackable
{
    /// <summary>
    /// "RowVersion" özelliği: "byte[]" veri türünde bir dizi (array) olan "RowVersion", nesnenin sürüm bilgisini temsil eder.
    /// </summary>
    byte[] RowVersion { get; set; }

    /// <summary>
    /// "CreatedDateTime" özelliği: "DateTimeOffset" veri türünde olan "CreatedDateTime", nesnenin oluşturulduğu tarih ve saat bilgisini tutar. 
    /// </summary>
    DateTimeOffset CreatedDateTime { get; set; }

    /// <summary>
    /// "UpdatedDateTime" özelliği: "DateTimeOffset?" veri türünde olan "UpdatedDateTime", nesnenin güncellenme tarih ve saat bilgisini tutar. 
    /// </summary>
    DateTimeOffset UpdatedDateTime { get; set; }
}