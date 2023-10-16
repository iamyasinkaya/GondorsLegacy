namespace GondorsLegacy.Services.Reservation.DTOs
{
    public class ReservationUpdateDto
	{
        public DateTime CheckInDate { get; set; }  // Giriş tarihi
        public DateTime CheckOutDate { get; set; }  // Çıkış tarihi
        public int NumberOfGuests { get; set; }  // Konuk sayısı

    }
}

