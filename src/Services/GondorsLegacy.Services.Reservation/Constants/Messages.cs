namespace GondorsLegacy.Services.Reservation.Constants;

public class Messages
{
    /// <summary>
    /// Bir hata oluştu. Lütfen daha sonra tekrar deneyin.
    /// </summary>
    public const string DefaultErrorMessage = "Bir hata oluştu";

    /// <summary>
    /// Geçersiz bir rezervasyon isteği gönderildi. Lütfen isteği kontrol edin ve tekrar deneyin.
    /// </summary>
    public const string InvalidReservationRequestMessage = "Rezervasyon isteği doğrulanamadı";

    /// <summary>
    /// Bu işlem için yetkiniz yok. Lütfen giriş yapın veya yöneticiye başvurun.
    /// </summary>
    public const string UnauthorizedOperationMessage = "Yetkisiz işlem";

    /// <summary>
    /// Belirtilen kaynak bulunamadı veya mevcut değil.
    /// </summary>
    public const string ResourceNotFoundMessage = "Kaynak bulunamadı";

    /// <summary>
    /// İstek zaman aşımına uğradı. Lütfen tekrar deneyin.
    /// </summary>
    public const string RequestTimeoutMessage = "İstek zaman aşımına uğradı";

    /// <summary>
    /// İstekteki gerekli alanlar eksik veya hatalı. Lütfen isteği kontrol edin.
    /// </summary>
    public const string InvalidRequestFieldsMessage = "Geçersiz veya eksik alanlar";

    /// <summary>
    /// İşlem başarıyla tamamlandı.
    /// </summary>
    public const string SuccessMessage = "İşlem başarıyla tamamlandı";

    /// <summary>
    /// Kullanıcı girişi gereklidir. Lütfen oturum açın.
    /// </summary>
    public const string LoginRequiredMessage = "Oturum açma gereklidir";

    // Yeni mesajlar
    /// <summary>
    /// Kullanıcı bulunamadı.
    /// </summary>
    public const string UserNotFoundMessage = "Kullanıcı bulunamadı";

    /// <summary>
    /// Erişim reddedildi.
    /// </summary>
    public const string AccessDeniedMessage = "Erişim reddedildi";

    /// <summary>
    /// Yetersiz bakiye.
    /// </summary>
    public const string InsufficientFundsMessage = "Yetersiz bakiye";

    /// <summary>
    /// Girdi zaten mevcut, lütfen farklı bir değer deneyin.
    /// </summary>
    public const string DuplicateEntryMessage = "Girdi zaten mevcut, lütfen farklı bir değer deneyin";

    /// <summary>
    /// Dosya yüklenirken hata oluştu.
    /// </summary>
    public const string FileUploadErrorMessage = "Dosya yüklenirken hata oluştu";

    /// <summary>
    /// Şifre sıfırlama başarıyla tamamlandı.
    /// </summary>
    public const string PasswordResetSuccessMessage = "Şifre sıfırlama başarıyla tamamlandı";

    /// <summary>
    /// E-posta doğrulama başarılı.
    /// </summary>
    public const string EmailConfirmationMessage = "E-posta doğrulama başarılı";
}



