using GondorsLegacy.Services.Reservation.Constants;

namespace GondorsLegacy.Services.Reservation.DTOs
{
    public class ReservationCreateDto
	{
        public string CustomerName { get; set; }  // Müşteri adı
        public DateTime CheckInDate { get; set; }  // Giriş tarihi
        public DateTime CheckOutDate { get; set; }  // Çıkış tarihi
        public RoomType RoomType { get; set; }  // Oda tipi
        public string SpecialRequests { get; set; } // Özel istekler
        public int NumberOfAdults { get; set; } // Yetişkin kişi sayısı
        public int NumberOfChildren { get; set; } // Çocuk kişi sayısı
    }
}

