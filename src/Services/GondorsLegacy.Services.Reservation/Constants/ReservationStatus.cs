namespace GondorsLegacy.Services.Reservation.Constants;

//public record ReservationStatus(int Value, string Description)
//{
//    public static ReservationStatus Confirmed { get; } = new ReservationStatus(1, "Rezervasyon onaylandı ve geçerli.");
//    public static ReservationStatus Pending { get; } = new ReservationStatus(2, "Rezervasyon hala onay bekliyor.");
//    public static ReservationStatus Canceled { get; } = new ReservationStatus(3, "Rezervasyon iptal edildi.");
//    public static ReservationStatus Completed { get; } = new ReservationStatus(4, "Rezervasyon tamamlandı ve hizmet sağlandı.");
//    public static ReservationStatus Modified { get; } = new ReservationStatus(5, "Rezervasyon değiştirildi ve güncellendi.");
//    public static ReservationStatus PastDue { get; } = new ReservationStatus(6, "Rezervasyon tarihi geçmiş durumda.");
//    public static ReservationStatus PaymentPending { get; } = new ReservationStatus(7, "Rezervasyon için ödeme bekleniyor.");
//    public static ReservationStatus Rescheduled { get; } = new ReservationStatus(8, "Rezervasyon taşındı, başka bir tarihe ertelendi.");
//    public static ReservationStatus Conflict { get; } = new ReservationStatus(9, "Rezervasyon için çatışma mevcut, başka bir tarih seçilmesi gerekebilir.");
//    public static ReservationStatus Unknown { get; } = new ReservationStatus(10, "Rezervasyon durumu belirsiz veya tanımsız.");

//    public static implicit operator int(ReservationStatus status) => status.Value;
//    public static implicit operator ReservationStatus(int value) => value switch
//    {
//        1 => ReservationStatus.Confirmed,
//        2 => ReservationStatus.Pending,
//        3 => ReservationStatus.Canceled,
//        4 => ReservationStatus.Completed,
//        5 => ReservationStatus.Modified,
//        6 => ReservationStatus.PastDue,
//        7 => ReservationStatus.PaymentPending,
//        8 => ReservationStatus.Rescheduled,
//        9 => ReservationStatus.Conflict,
//        10 => ReservationStatus.Unknown,
//        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Geçersiz değer")
//    };

//    public override string ToString() => Description;
//}


public enum ReservationStatus
{
    Confirmed,
    Pending,
    Canceled,
    Completed,
    Modified,
    PastDue,
    PaymentPending,
    Rescheduled,
    Conflict,
    Unknown
}
