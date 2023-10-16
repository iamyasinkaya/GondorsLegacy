namespace GondorsLegacy.Domain.Entities;

/// <summary>
///  Bir nesnenin bir kimlik değeri (ID) olduğunu belirtir ve bu kimlik değerini içeren özelliği tanımlar.
/// </summary>
/// <typeparam name="T">"T Id" özelliği: "T" türündeki bir "Id" özelliği, nesnenin kimlik değerini temsil eder.</typeparam>
public interface IHasKey<T>
{
    /// <summary>
    /// "T Id" özelliği: "T" türündeki bir "Id" özelliği, nesnenin kimlik değerini temsil eder.
    /// </summary>
    T Id { get; set; }
}