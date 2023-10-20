namespace GondorsLegacy.Services.Reservation.Validations;

using FluentValidation;

public class ReservationValidator : AbstractValidator<Entities.Reservation>
{
    public ReservationValidator()
    {
        RuleFor(r => r.CustomerId).NotEmpty().WithMessage("Müşteri kimliği boş olamaz");
        RuleFor(r => r.CustomerFirstName).NotEmpty().WithMessage("Müşteri adı boş olamaz");
        RuleFor(r => r.CustomerLastName).NotEmpty().WithMessage("Müşteri soyadı boş olamaz");
        RuleFor(r => r.HotelId).NotEmpty().WithMessage("Otel kimliği boş olamaz");
        RuleFor(r => r.HotelName).NotEmpty().WithMessage("Otel adı boş olamaz");
        RuleFor(r => r.CheckInDate).NotEmpty().WithMessage("Giriş tarihi boş olamaz").GreaterThan(DateTime.Now).WithMessage("Geçersiz giriş tarihi");
        RuleFor(r => r.CheckOutDate).NotEmpty().WithMessage("Çıkış tarihi boş olamaz").GreaterThan(r => r.CheckInDate).WithMessage("Çıkış tarihi giriş tarihinden önce olamaz");
        RuleFor(r => r.RoomType).IsInEnum().WithMessage("Geçersiz oda tipi");
        RuleFor(r => r.NumberOfGuests).NotEmpty().WithMessage("Konuk sayısı boş olamaz").GreaterThan(0).WithMessage("Geçersiz konuk sayısı");
        RuleFor(r => r.TotalPrice).NotEmpty().WithMessage("Toplam fiyat boş olamaz").GreaterThan(0).WithMessage("Geçersiz toplam fiyat");
        RuleFor(r => r.RoomNumber).NotEmpty().WithMessage("Oda numarası boş olamaz");
        RuleFor(r => r.CustomerEmail).NotEmpty().WithMessage("Müşteri e-posta adresi boş olamaz").EmailAddress().WithMessage("Geçersiz e-posta adresi");
        RuleFor(r => r.ReservationStatus).IsInEnum().WithMessage("Geçersiz rezervasyon durumu");
        RuleFor(r => r.SpecialRequests).MaximumLength(1000).WithMessage("Özel istekler 1000 karakteri geçemez");
        RuleFor(r => r.NumberOfAdults).GreaterThanOrEqualTo(0).WithMessage("Geçersiz yetişkin kişi sayısı");
        //RuleFor(r => r.NumberOfChildren).GreaterThanOrEqualTo(0).WithMessage("Geçersiz çocuk kişi sayısı");
        RuleFor(r => r.PaymentStatus).IsInEnum().WithMessage("Geçersiz ödeme durumu");
        RuleFor(r => r.CancellationReason).IsInEnum().WithMessage("Geçersiz iptal nedeni");
    }
}
