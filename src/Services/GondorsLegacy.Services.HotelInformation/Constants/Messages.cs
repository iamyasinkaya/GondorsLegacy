namespace GondorsLegacy.Services.HotelInformation.Constants;

public record Messages(string Message)
{
    public static Messages DefaultErrorMessage { get; } = new Messages("Bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
    public static Messages HotelNotFound { get; } = new Messages("Otel Bulunamadı");
    public static Messages InvalidHotelRequestMessage { get; } = new Messages("Geçersiz bir hotel isteği gönderildi. Lütfen isteği kontrol edin ve tekrar deneyin.");
    public static Messages HotelAddedSuccessfully { get; } = new Messages("Otel başarıyla eklendi");
    public static Messages HotelUpdatedSuccessfully { get; } = new Messages("Otel güncellendi");
    public static Messages HotelDeletedSuccessfully { get; } = new Messages("Otel silindi");
    public static Messages EmptyOrInvalidParameters { get; } = new Messages("Boş veya geçersiz parametrelerle birlikte hotel isteği gönderildi");
    public static Messages RequestProcessedSuccessfully { get; } = new Messages("İstek başarıyla işlendi");
    public static implicit operator string(Messages message) => message.Message;

    public override string ToString() => $"{nameof(Messages)}";
}
