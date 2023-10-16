using GondorsLegacy.Domain.Entities;
using GondorsLegacy.Services.Reservation.Constants;

namespace GondorsLegacy.Services.Reservation.Entities;

public class Reservation : Entity<Guid>
{
    public int ReservationId { get; set; }  // Rezervasyon kimliği
    public string CustomerName { get; set; }  // Müşteri adı
    public DateTime CheckInDate { get; set; }  // Giriş tarihi
    public DateTime CheckOutDate { get; set; }  // Çıkış tarihi
    public RoomType RoomType { get; set; }  // Oda tipi
    public int NumberOfGuests { get; set; }  // Konuk sayısı
    public decimal TotalPrice { get; set; }  // Toplam fiyat
    public int RoomNumber { get; set; } // Oda numarası
    public string CustomerEmail { get; set; } // Müşteri e-posta adresi
    public ReservationStatus ReservationStatus { get; set; } // Rezervasyon durumu
    public string PaymentInformation { get; set; } // Ödeme bilgileri
    public string SpecialRequests { get; set; } // Özel istekler
    public int NumberOfAdults { get; set; } // Yetişkin kişi sayısı
    public int NumberOfChildren { get; set; } // Çocuk kişi sayısı
    public decimal TaxRate { get; set; } // Vergi oranı 
    public decimal ExtraServicePrice { get; set; } // Ekstra hizmet fiyatı
    public List<string> ExtraServices { get; set; } // Ekstra hizmetler listesi
    public PaymentStatus PaymentStatus { get; set; } // Ödeme durumu
    public CancellationReason CancellationReason { get; set; } // İptal nedeni


    

    // Toplam fiyatı hesaplayan bir metot (örnek olarak)
    private decimal CalculateTotalPrice(decimal taxRate, decimal extraServicePrice)
    {
        // Fiyat hesaplama mantığını burada ekleyebilirsiniz.
        // Örneğin, oda tipine, konaklama süresine ve diğer faktörlere bağlı olarak fiyatı hesaplayabilirsiniz.
        // Burada basit bir hesaplama yapılıyor, gerçek projenize uygun şekilde değiştirilebilir.
        decimal basePricePerNight = GetPricePerNight(RoomType);
        int numberOfNights = (int)(CheckOutDate - CheckInDate).TotalDays;

        // Oda fiyatı
        decimal roomPrice = basePricePerNight * numberOfNights;

        // Vergi hesaplama
        decimal taxAmount = roomPrice * taxRate;

        // Ek hizmet fiyatı (örneğin, otopark, kahvaltı, vb.)
        decimal extraServiceAmount = extraServicePrice * numberOfNights;

        // Toplam fiyat hesaplama
        decimal totalPrice = roomPrice + taxAmount + extraServiceAmount;

        return totalPrice;
    }

    // Oda tiplerine göre fiyatları döndüren bir metot (örnek olarak)
    private decimal GetPricePerNight(RoomType roomType)
    {
        switch (roomType)
        {
            case RoomType.Standard:
                return 100;
            case RoomType.Deluxe:
                return 150;
            case RoomType.Suite:
                return 200;
            case RoomType.Villa:
                return 300;
            default:
                return 0; // Bilinmeyen oda tipi
        }
    }

    // Rezervasyonu Onaylama
    public void ConfirmReservation()
    {
        ReservationStatus = ReservationStatus.Confirmed;
    }

    // Rezervasyonu İptal Etme
    public void CancelReservation(CancellationReason reason)
    {
        ReservationStatus = ReservationStatus.Canceled;
        CancellationReason = reason;
    }

    // Müşteri Bilgilerini Güncelleme
    public void UpdateCustomerInfo(string newEmail, string newPaymentInfo)
    {
        CustomerEmail = newEmail;
        PaymentInformation = newPaymentInfo;
    }

    // Ödeme Yapma
    public void MakePayment(decimal amount)
    {
        // Ödeme işlemleri burada işlenir
        PaymentStatus = PaymentStatus.Paid;
    }

    // Oda Temizliği ve Bakımı Yapma
    public void CleanAndMaintainRoom()
    {
        // Oda temizliği ve bakım işlemleri burada işlenir
    }


}



