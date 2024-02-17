namespace GondorsLegacy.Services.Reservation.Constants;

public record PaymentStatus(int Value, string Description)
{
    public static PaymentStatus Paid { get; } = new PaymentStatus(1, "Ödeme başarıyla tamamlandı.");
    public static PaymentStatus PendingPayment { get; } = new PaymentStatus(2, "Ödeme işlemi henüz tamamlanmamış, bekliyor.");
    public static PaymentStatus Refunded { get; } = new PaymentStatus(3, "Ödeme iade edildi.");
    public static PaymentStatus Failed { get; } = new PaymentStatus(4, "Ödeme işlemi başarısız oldu.");
    public static PaymentStatus PartiallyPaid { get; } = new PaymentStatus(5, "Ödeme kısmen yapıldı.");
    public static PaymentStatus Authorized { get; } = new PaymentStatus(6, "Ödeme işlemi yetkilendirildi, ancak henüz tamamlanmadı.");
    public static PaymentStatus Chargeback { get; } = new PaymentStatus(7, "Müşteri geri ödeme talebinde bulundu.");
    public static PaymentStatus Processing { get; } = new PaymentStatus(8, "Ödeme işlemi işleniyor.");
    public static PaymentStatus OnHold { get; } = new PaymentStatus(9, "Ödeme işlemi beklemeye alındı.");
    public static PaymentStatus Disputed { get; } = new PaymentStatus(10, "Ödeme işlemi ile ilgili bir itiraz bulunuyor.");
    public static PaymentStatus Overdue { get; } = new PaymentStatus(11, "Ödeme süresi geçmiş durumda.");
    public static PaymentStatus Voided { get; } = new PaymentStatus(12, "Ödeme işlemi iptal edildi.");
    public static PaymentStatus Settled { get; } = new PaymentStatus(13, "Ödeme işlemi başarıyla hesaplandı.");
    public static PaymentStatus AwaitingConfirmation { get; } = new PaymentStatus(14, "Ödeme işlemi onay bekliyor.");
    public static PaymentStatus Canceled { get; } = new PaymentStatus(15, "Ödeme işlemi kullanıcı tarafından iptal edildi.");
    public static PaymentStatus Refused { get; } = new PaymentStatus(16, "Ödeme işlemi reddedildi.");
    public static PaymentStatus Unknown { get; } = new PaymentStatus(17, "Ödeme durumu bilinmiyor veya belirtilmemiş.");

    public static implicit operator int(PaymentStatus status) => status.Value;
    public static implicit operator PaymentStatus(int value) => value switch
    {
        1 => PaymentStatus.Paid,
        2 => PaymentStatus.PendingPayment,
        3 => PaymentStatus.Refunded,
        4 => PaymentStatus.Failed,
        5 => PaymentStatus.PartiallyPaid,
        6 => PaymentStatus.Authorized,
        7 => PaymentStatus.Chargeback,
        8 => PaymentStatus.Processing,
        9 => PaymentStatus.OnHold,
        10 => PaymentStatus.Disputed,
        11 => PaymentStatus.Overdue,
        12 => PaymentStatus.Voided,
        13 => PaymentStatus.Settled,
        14 => PaymentStatus.AwaitingConfirmation,
        15 => PaymentStatus.Canceled,
        16 => PaymentStatus.Refused,
        17 => PaymentStatus.Unknown,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Geçersiz değer")
    };

    public override string ToString() => Description;
}


