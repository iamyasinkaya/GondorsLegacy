namespace GondorsLegacy.Services.Reservation.Constants;

public record CancellationReason(int Value, string Name)
{
    public static CancellationReason UnforeseenCircumstances { get; } = new CancellationReason(1, "Beklenmedik durumlar nedeniyle rezervasyon iptal edildi.");
    public static CancellationReason ChangeOfPlans { get; } = new CancellationReason(2, "Plan değişikliği nedeniyle rezervasyon iptal edildi.");
    public static CancellationReason FoundAnotherHotel { get; } = new CancellationReason(3, "Başka bir otel bulundu ve rezervasyon iptal edildi.");
    public static CancellationReason FinancialIssues { get; } = new CancellationReason(4, "Mali sorunlar nedeniyle rezervasyon iptal edildi.");
    public static CancellationReason Other { get; } = new CancellationReason(5, "Diğer nedenlerle rezervasyon iptal edildi.");
    public static CancellationReason HealthIssues { get; } = new CancellationReason(6, "Sağlık sorunları nedeniyle rezervasyon iptal edildi.");
    public static CancellationReason TravelChange { get; } = new CancellationReason(7, "Seyahat planları değişti ve rezervasyon iptal edildi.");
    public static CancellationReason Emergency { get; } = new CancellationReason(8, "Acil bir durum nedeniyle rezervasyon iptal edildi.");
    public static CancellationReason HolidayChange { get; } = new CancellationReason(9, "Tatil planları değişti ve rezervasyon iptal edildi.");
    public static CancellationReason JobChange { get; } = new CancellationReason(10, "İş değişikliği nedeniyle rezervasyon iptal edildi.");
    public static CancellationReason BadWeather { get; } = new CancellationReason(11, "Kötü hava koşulları nedeniyle rezervasyon iptal edildi.");

    public static implicit operator int(CancellationReason reason) => reason.Value;
    public static implicit operator CancellationReason(int value) => value switch
    {
        1 => CancellationReason.UnforeseenCircumstances,
        2 => CancellationReason.ChangeOfPlans,
        3 => CancellationReason.FoundAnotherHotel,
        4 => CancellationReason.FinancialIssues,
        5 => CancellationReason.Other,
        6 => CancellationReason.HealthIssues,
        7 => CancellationReason.TravelChange,
        8 => CancellationReason.Emergency,
        9 => CancellationReason.HolidayChange,
        10 => CancellationReason.JobChange,
        11 => CancellationReason.BadWeather,

        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Invalid value")
    };

    public bool IsCancellationReason =>
        this == UnforeseenCircumstances ||
        this == ChangeOfPlans ||
        this == FoundAnotherHotel ||
        this == FinancialIssues ||
        this == Other ||
        this == HealthIssues ||
        this == TravelChange ||
        this == Emergency ||
        this == HolidayChange ||
        this == JobChange ||
        this == BadWeather;

    public override string ToString() => Name;

}


