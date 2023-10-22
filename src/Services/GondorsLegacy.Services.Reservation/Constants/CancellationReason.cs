namespace GondorsLegacy.Services.Reservation.Constants;

public enum CancellationReason
{
    /// <summary>
    /// Beklenmedik durumlar nedeniyle rezervasyon iptal edildi.
    /// </summary>
    UnforeseenCircumstances,

    /// <summary>
    /// Plan değişikliği nedeniyle rezervasyon iptal edildi.
    /// </summary>
    ChangeOfPlans,

    /// <summary>
    /// Başka bir otel bulundu ve rezervasyon iptal edildi.
    /// </summary>
    FoundAnotherHotel,

    /// <summary>
    /// Mali sorunlar nedeniyle rezervasyon iptal edildi.
    /// </summary>
    FinancialIssues,

    /// <summary>
    /// Diğer nedenlerle rezervasyon iptal edildi.
    /// </summary>
    Other,

    /// <summary>
    /// Sağlık sorunları nedeniyle rezervasyon iptal edildi.
    /// </summary>
    HealthIssues,

    /// <summary>
    /// Seyahat planları değişti ve rezervasyon iptal edildi.
    /// </summary>
    TravelChange,

    /// <summary>
    /// Acil bir durum nedeniyle rezervasyon iptal edildi.
    /// </summary>
    Emergency,

    /// <summary>
    /// Tatil planları değişti ve rezervasyon iptal edildi.
    /// </summary>
    HolidayChange,

    /// <summary>
    /// İş değişikliği nedeniyle rezervasyon iptal edildi.
    /// </summary>
    JobChange,

    /// <summary>
    /// Kötü hava koşulları nedeniyle rezervasyon iptal edildi.
    /// </summary>
    BadWeather
}

