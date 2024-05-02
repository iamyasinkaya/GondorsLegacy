namespace GondorsLegacy.Services.Reservation.Models.Requests.Reservation;

public class CancelReservationRequest
{
    public Guid ReservationId { get; set; } // Rezervasyon kimliği
    public Guid CustomerId { get; set; } // Müşteri kimliği
    public bool IsReservationCancelled { get; set; }
}
