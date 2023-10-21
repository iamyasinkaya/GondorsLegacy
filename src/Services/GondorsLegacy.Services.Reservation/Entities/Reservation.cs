using GondorsLegacy.Domain.Entities;
using GondorsLegacy.Services.Reservation.Constants;

namespace GondorsLegacy.Services.Reservation.Entities;

public class Reservation : Entity<Guid>
{
    
    public Guid CustomerId { get; set; } // Müşteri kimliği
    public string CustomerFirstName { get; set; }  // Müşteri adı
    public string CustomerLastName { get; set; } // Müşteri soyadı
    public Guid HotelId { get; set; } // Otel kimliği
    public string HotelName { get; set; } // Otel adı
    public DateTime CheckInDate { get; set; }  // Giriş tarihi
    public DateTime CheckOutDate { get; set; }  // Çıkış tarihi
    public RoomType RoomType { get; set; }  // Oda tipi
    public int NumberOfGuests { get; set; }  // Konuk sayısı
    public decimal TotalPrice { get; set; }  // Toplam fiyat
    public int RoomNumber { get; set; } // Oda numarası
    public string CustomerEmail { get; set; } // Müşteri e-posta adresi
    public ReservationStatus ReservationStatus { get; set; } // Rezervasyon durumu
    public string SpecialRequests { get; set; } // Özel istekler
    public int NumberOfAdults { get; set; } // Yetişkin kişi sayısı
    public int NumberOfChildren { get; set; } // Çocuk kişi sayısı
    public PaymentStatus PaymentStatus { get; set; } // Ödeme durumu
    public CancellationReason CancellationReason { get; set; } // İptal nedeni
    public bool IsReservationCancelled { get; set; } = false; //iptal durumu


}



