namespace GondorsLegacy.Services.Reservation.Constants
{
    public enum ReservationStatus
    {
        /// <summary>
        /// Rezervasyon onaylandı ve geçerli.
        /// </summary>
        Confirmed,

        /// <summary>
        /// Rezervasyon hala onay bekliyor.
        /// </summary>
        Pending,

        /// <summary>
        /// Rezervasyon iptal edildi.
        /// </summary>
        Canceled,

        /// <summary>
        /// Rezervasyon tamamlandı ve hizmet sağlandı.
        /// </summary>
        Completed,

        /// <summary>
        /// Rezervasyon değiştirildi ve güncellendi.
        /// </summary>
        Modified,

        /// <summary>
        /// Rezervasyon tarihi geçmiş durumda.
        /// </summary>
        PastDue,

        /// <summary>
        /// Rezervasyon için ödeme bekleniyor.
        /// </summary>
        PaymentPending,

        /// <summary>
        /// Rezervasyon taşındı, başka bir tarihe ertelendi.
        /// </summary>
        Rescheduled,

        /// <summary>
        /// Rezervasyon için çatışma mevcut, başka bir tarih seçilmesi gerekebilir.
        /// </summary>
        Conflict,

        /// <summary>
        /// Rezervasyon durumu belirsiz veya tanımsız.
        /// </summary>
        Unknown
    }

}

