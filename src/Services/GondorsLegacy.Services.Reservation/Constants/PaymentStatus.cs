namespace GondorsLegacy.Services.Reservation.Constants
{
    public enum PaymentStatus
    {
        /// <summary>
        /// Ödeme başarıyla tamamlandığında kullanılır.
        /// </summary>
        Paid,

        /// <summary>
        /// Ödeme işlemi henüz tamamlanmamış, bekliyor.
        /// </summary>
        PendingPayment,

        /// <summary>
        /// Ödeme iade edildi.
        /// </summary>
        Refunded,

        /// <summary>
        /// Ödeme işlemi başarısız oldu.
        /// </summary>
        Failed,

        /// <summary>
        /// Ödeme kısmen yapıldı.
        /// </summary>
        PartiallyPaid,

        /// <summary>
        /// Ödeme işlemi yetkilendirildi, ancak henüz tamamlanmadı.
        /// </summary>
        Authorized,

        /// <summary>
        /// Müşteri geri ödeme talebinde bulundu.
        /// </summary>
        Chargeback,

        /// <summary>
        /// Ödeme işlemi işleniyor.
        /// </summary>
        Processing,

        /// <summary>
        /// Ödeme işlemi beklemeye alındı.
        /// </summary>
        OnHold,

        /// <summary>
        /// Ödeme işlemi ile ilgili bir itiraz bulunuyor.
        /// </summary>
        Disputed,

        /// <summary>
        /// Ödeme süresi geçmiş durumda.
        /// </summary>
        Overdue,

        /// <summary>
        /// Ödeme işlemi iptal edildi.
        /// </summary>
        Voided,

        /// <summary>
        /// Ödeme işlemi başarıyla hesaplandı.
        /// </summary>
        Settled,

        /// <summary>
        /// Ödeme işlemi onay bekliyor.
        /// </summary>
        AwaitingConfirmation,

        /// <summary>
        /// Ödeme işlemi kullanıcı tarafından iptal edildi.
        /// </summary>
        Canceled,

        /// <summary>
        /// Ödeme işlemi reddedildi.
        /// </summary>
        Refused,

        /// <summary>
        /// Ödeme durumu bilinmiyor veya belirtilmemiş.
        /// </summary>
        Unknown

    }

}

