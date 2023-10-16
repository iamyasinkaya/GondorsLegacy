using System.ComponentModel.DataAnnotations;

namespace GondorsLegacy.Domain.Entities;

/// <summary>
///  Bu soyut sınıf, "TKey" türünde bir kimlik değeri içeren bir nesneyi temsil eder ve hem "IHasKey<TKey>" arayüzünü hem de "ITrackable" arayüzünü uygular.
/// </summary>
/// <typeparam name="TKey">"TKey Id" özelliği: "TKey" türündeki bir "Id" özelliği, nesnenin kimlik değerini temsil eder</typeparam>
public class Entity<TKey> : IHasKey<TKey>, ITrackable
{
    /// <summary>
    /// "TKey Id" özelliği: "TKey" türünde bir "Id" özelliği, nesnenin kimlik değerini temsil eder. 
    /// </summary>
    [Key]
    public TKey Id { get; set; }

    /// <summary>
    /// "[Timestamp] byte[] RowVersion" özelliği: "[Timestamp]" niteliği ile işaretlenmiş bir "RowVersion" özelliği, sürüm bilgisini temsil eden bir dizi (array) olan "byte[]" türünde bir özelliği ifade eder. 
    /// </summary>
    [Timestamp]
    public byte[] RowVersion { get; set; }

    /// <summary>
    /// "DateTimeOffset CreatedDateTime" özelliği: "CreatedDateTime", nesnenin oluşturulduğu tarih ve saat bilgisini temsil eder.
    /// </summary>
    public DateTimeOffset CreatedDateTime { get; set; }

    /// <summary>
    /// "DateTimeOffset? UpdatedDateTime" özelliği: "UpdatedDateTime", nesnenin güncellenme tarih ve saat bilgisini temsil eder. 
    /// </summary>
    public DateTimeOffset UpdatedDateTime { get; set; }
}