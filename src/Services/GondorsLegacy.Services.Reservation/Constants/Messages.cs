namespace GondorsLegacy.Services.Reservation.Constants;

public record Messages(string Message)
{
    public static Messages DefaultErrorMessage { get; } = new("Bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
    public static Messages InvalidReservationRequestMessage { get; } = new("Geçersiz bir rezervasyon isteği gönderildi. Lütfen isteği kontrol edin ve tekrar deneyin.");
    public static Messages UnauthorizedOperationMessage { get; } = new("Bu işlem için yetkiniz yok. Lütfen giriş yapın veya yöneticiye başvurun.");
    public static Messages ResourceNotFoundMessage { get; } = new("Belirtilen kaynak bulunamadı veya mevcut değil.");
    public static Messages RequestTimeoutMessage { get; } = new("İstek zaman aşımına uğradı. Lütfen tekrar deneyin.");
    public static Messages InvalidRequestFieldsMessage { get; } = new("İstekteki gerekli alanlar eksik veya hatalı. Lütfen isteği kontrol edin.");
    public static Messages SuccessMessage { get; } = new("İşlem başarıyla tamamlandı.");
    public static Messages LoginRequiredMessage { get; } = new("Kullanıcı girişi gereklidir. Lütfen oturum açın.");
    public static Messages UserNotFoundMessage { get; } = new("Kullanıcı bulunamadı.");
    public static Messages AccessDeniedMessage { get; } = new("Erişim reddedildi.");
    public static Messages InsufficientFundsMessage { get; } = new("Yetersiz bakiye.");
    public static Messages DuplicateEntryMessage { get; } = new("Girdi zaten mevcut, lütfen farklı bir değer deneyin.");
    public static Messages FileUploadErrorMessage { get; } = new("Dosya yüklenirken hata oluştu.");
    public static Messages PasswordResetSuccessMessage { get; } = new("Şifre sıfırlama başarıyla tamamlandı.");
    public static Messages EmailConfirmationMessage { get; } = new("E-posta doğrulama başarılı.");

    public static implicit operator string(Messages message) => message.Message;

    public override string ToString() => Message;
}




