namespace GondorsLegacy.Services.Reservation.Constants;

// İptal Nedeni (CancellationReason) enum'u
public enum CancellationReason
{
    UnforeseenCircumstances, // Beklenmedik durumlar
    ChangeOfPlans, // Plan değişikliği
    FoundAnotherHotel, // Başka bir otel bulundu
    FinancialIssues, // Mali sorunlar
    Other, // Diğer
}
