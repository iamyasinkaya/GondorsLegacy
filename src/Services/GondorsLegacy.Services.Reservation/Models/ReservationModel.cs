using System;
using GondorsLegacy.Services.Reservation.Constants;

namespace GondorsLegacy.Services.Reservation.Models
{
	public class ReservationModel
	{
		public Guid Id { get; set; }
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
    }
}

